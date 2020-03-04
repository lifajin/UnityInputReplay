using LetsBuild.Data;
using LetsBuild.Enums;
using LetsBuild.Interfaces;
using LetsBuild.Managers;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace LetsBuild.Components
{
    public class UnityInputReplay : MonoBehaviour
    {
        private Recording recording;
        public RecordMode Mode = RecordMode.None;
        internal IInputManager manager;
        public string RecordingDirectory = "C:\\";
        public string PlaybackFilePath;
        public UpdateCycle UpdateCycle = UpdateCycle.FixedUpdate;
        public List<GameObject> objectsToSync = new List<GameObject>();

        // Start is called before the first frame update
        void Start()
        {
            recording = new Recording(objectsToSync);

            if (Mode == RecordMode.Record)
            {
                if (!RecordingDirectory.EndsWith("\\"))
                    RecordingDirectory += "\\";

                var now = DateTimeOffset.UtcNow;
                var RecordingFilePath = RecordingDirectory + now.Year.ToString() + now.Month.ToString() + now.Day.ToString() + now.Hour.ToString() + now.Minute.ToString() + now.Second.ToString() + now.Millisecond.ToString() + ".json";

                recording.BeginRecording(RecordingFilePath);
                manager = new RecordingManager(recording);
            }
            else if (Mode == RecordMode.Playback)
            {
                if (String.IsNullOrWhiteSpace(PlaybackFilePath))
                    Debug.LogError("No Playback File Path Configured");

                recording.LoadFrames(PlaybackFilePath);
                manager = new PlaybackManager(recording);
            }
            else
            {
                manager = new PassThroughManager();
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (UpdateCycle != UpdateCycle.Update)
            {
                return;
            }

            if (Mode == RecordMode.Record)
            {
                recording.AddNewFrame(Time.time);
            }
            else if (Mode == RecordMode.Playback)
            {
                recording.AdvanceCurrentFrame(Time.time, Time.deltaTime);
            }
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            if (UpdateCycle != UpdateCycle.FixedUpdate)
            {
                return;
            }

            if (Mode == RecordMode.Record)
            {
                recording.AddNewFrame(Time.time);
            }
            else if (Mode == RecordMode.Playback)
            {
                recording.AdvanceCurrentFrame(Time.time, Time.fixedDeltaTime);
            }
        }

        private void OnDestroy()
        {
            EndRecording();
        }

        public void EndRecording()
        {
            if (Mode == RecordMode.Record)
            {
                recording.EndRecording(Time.time);
            }
        }
    }
}