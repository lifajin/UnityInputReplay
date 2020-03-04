using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

namespace LetsBuild.Data
{
    public class Recording
    {
        private StreamWriter writer = null;
        bool isRecording = false;

        public void BeginRecording(string filePath)
        {
            writer = new StreamWriter(filePath, false);
            isRecording = true;
        }

        public void EndRecording(float time)
        {
            if (isRecording)
            {
                writer.WriteLine(JsonUtility.ToJson(new Frame()
                {
                    time = time,
                    data = new List<CapturedInput>(),
                    gameObjects = new List<GameObjectLocation>()
                }));
                isRecording = false;
                writer.Close();
                writer.Dispose();
            }
        }

        private StreamReader reader = null;
        public void LoadFrames(string filePath)
        {
            reader = new StreamReader(filePath, true);

            readerOpen = true;
            endOfFile = false;
            CurrentFrame = EmptyFrame;
            queuedFrame = EmptyFrame;
        }

        public Frame CurrentFrame { get; private set; } = EmptyFrame;
        private Frame previousFrame = EmptyFrame;

        public Frame AddNewFrame(float time)
        {
            var frame = new Frame
            {
                time = time,
                data = new List<CapturedInput>(),
                gameObjects = new List<GameObjectLocation>()
            };

            var previousData = JsonUtility.ToJson(new Frame()
            {
                time = CurrentFrame.time,
                data = previousFrame.data,
                gameObjects = new List<GameObjectLocation>()
            });

            var currentData = JsonUtility.ToJson(CurrentFrame);

            if (previousData != currentData)
            {

                previousFrame = CurrentFrame;
                foreach (var item in objectsToSync)
                {
                    CurrentFrame.gameObjects.Add(new GameObjectLocation()
                    {
                        position = item.transform.localPosition,
                        rotation = item.transform.localRotation,
                        scale = item.transform.localScale
                    });
                }

                writer.WriteLine(JsonUtility.ToJson(CurrentFrame));
            }

            CurrentFrame = frame;
            return frame;
        }

        private bool readerOpen = false;
        private Queue<Frame> queuedFrames = new Queue<Frame>();
        private bool endOfFile = false;
        public void AdvanceCurrentFrame(float time, float deltaTime)
        {
            if (endOfFile && queuedFrames.Count == 0)
            {
                if (!readerOpen)
                {
                    return;
                }

                CurrentFrame = EmptyFrame;
                readerOpen = false;
                reader.Close();
                reader.Dispose();
                Debug.Log("End of Playback");
                return;
            }

            if (queuedFrame.time <= time && !endOfFile)
            {
                var nextLine = reader.ReadLine();

                if (!string.IsNullOrWhiteSpace(nextLine))
                {
                    queuedFrame = JsonUtility.FromJson<Frame>(nextLine);
                    queuedFrames.Enqueue(queuedFrame);
                }
                else
                {
                    endOfFile = true;
                }
            }

            var possibleNextFrame = EmptyFrame;
            if (queuedFrames.Count > 0)
            {
                possibleNextFrame = queuedFrames.Peek();
            }

            if (possibleNextFrame.time <= time)
            {
                if (possibleNextFrame != EmptyFrame)
                {
                    possibleNextFrame = queuedFrames.Dequeue();
                }

                if (possibleNextFrame.gameObjects.Count > 0)
                {
                    for (int i = 0; i < possibleNextFrame.gameObjects.Count; i++)
                    {
                        this.objectsToSync[i].transform.localPosition = possibleNextFrame.gameObjects[i].position;
                        this.objectsToSync[i].transform.localRotation = possibleNextFrame.gameObjects[i].rotation;
                        this.objectsToSync[i].transform.localScale = possibleNextFrame.gameObjects[i].scale;
                    }
                }

                CurrentFrame = possibleNextFrame;
            }
        }

        private Frame queuedFrame = EmptyFrame;

        public static Frame EmptyFrame = new Frame() { time = 0f, data = new List<CapturedInput>(), gameObjects = new List<GameObjectLocation>() };
        private List<GameObject> objectsToSync;

        public Recording(IEnumerable<GameObject> objectsToSync)
        {
            this.objectsToSync = objectsToSync.ToList();
        }
    }

}
