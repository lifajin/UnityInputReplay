using LetsBuild.Data;
using LetsBuild.Enums;
using LetsBuild.Interfaces;
using UnityEngine;

namespace LetsBuild.Managers
{
    public class PlaybackManager : IInputManager
    {
        private readonly Recording recording;

        public PlaybackManager(Recording recording)
        {
            this.recording = recording;
        }

        public string inputString
        {
            get
            {
                return GetDataString("inputString", InputType.Properties);
            }
        }

        public IMECompositionMode imeCompositionMode
        {
            get
            {
                return (IMECompositionMode)GetDataInt("imeCompositionMode", InputType.Properties);
            }
            set
            {
                // in playback mode do nothing
            }
        }

        public string compositionString
        {
            get
            {
                return GetDataString("compositionString", InputType.Properties);
            }
        }

        public bool imeIsSelected
        {
            get
            {
                return GetDataBit("imeIsSelected", InputType.Properties);
            }
        }

        public Vector2 compositionCursorPos
        {
            get
            {
                return GetDataVector2("compositionCursorPos", InputType.Properties);
            }
            set
            {
                // in playback mode do nothing
            }
        }
        public bool eatKeyPressOnTextFieldFocus
        {
            get
            {
                return GetDataBit("eatKeyPressOnTextFieldFocus", InputType.Properties);
            }
            set
            {
                // in playback mode do nothing
            }
        }

        public bool mousePresent
        {
            get
            {
                return GetDataBit("mousePresent", InputType.Properties);
            }
        }

        public int touchCount
        {
            get
            {
                return GetDataInt("touchCount", InputType.Properties);
            }
        }

        public bool touchPressureSupported
        {
            get
            {
                return GetDataBit("touchPressureSupported", InputType.Properties);
            }
        }


        public bool stylusTouchSupported
        {
            get
            {
                return GetDataBit("stylusTouchSupported", InputType.Properties);
            }
        }

        public bool touchSupported
        {
            get
            {
                return GetDataBit("touchSupported", InputType.Properties);
            }
        }

        public bool multiTouchEnabled
        {
            get
            {
                return GetDataBit("multiTouchEnabled", InputType.Properties);
            }
            set
            {
                // in playback mode do nothing
            }
        }

        public bool isGyroAvailable
        {
            get
            {
                return GetDataBit("isGyroAvailable", InputType.Properties);
            }
        }

        public DeviceOrientation deviceOrientation
        {
            get
            {
                return (DeviceOrientation)GetDataInt("deviceOrientation", InputType.Properties);
            }
        }

        public Vector3 acceleration
        {
            get
            {
                return GetDataVector3("acceleration", InputType.Properties);
            }
        }

        public bool compensateSensors
        {
            get
            {
                return GetDataBit("compensateSensors", InputType.Properties);
            }
            set
            {
                // in playback mode do nothing
            }
        }

        public int accelerationEventCount
        {
            get
            {
                return GetDataInt("accelerationEventCount", InputType.Properties);
            }
        }

        public bool backButtonLeavesApp
        {
            get
            {
                return GetDataBit("backButtonLeavesApp", InputType.Properties);
            }
            set
            {
                // in playback mode do nothing
            }
        }

        public LocationService location
        {
            get
            {
                return JsonUtility.FromJson<LocationService>(GetDataString("location", InputType.LocationService));
            }
        }

        public Compass compass
        {
            get
            {
                return JsonUtility.FromJson<Compass>(GetDataString("compass", InputType.Compass));
            }
        }

        public Gyroscope gyro
        {
            get
            {
                return JsonUtility.FromJson<Gyroscope>(GetDataString("gyro", InputType.Gyro));
            }
        }

        public Vector2 mouseScrollDelta
        {
            get
            {
                return GetDataVector2("mouseScrollDelta", InputType.Properties);
            }
        }

        public Vector3 mousePosition
        {
            get
            {
                return GetDataVector3("mousePosition", InputType.Properties);
            }
        }

        public AccelerationEvent[] accelerationEvents
        {
            get
            {
                return JsonUtility.FromJson<SerializeArray<AccelerationEvent>>(GetDataString("accelerationEvents", InputType.Properties)).data;
            }
        }

        public bool anyKeyDown
        {
            get
            {
                return GetDataBit("anyKeyDown", InputType.Properties);
            }
        }

        public bool anyKey
        {
            get
            {
                return GetDataBit("anyKey", InputType.Properties);
            }
        }

        public bool simulateMouseWithTouches
        {
            get
            {
                return GetDataBit("simulateMouseWithTouches", InputType.Properties);
            }
            set
            {
                // in playback mode do nothing
            }
        }

        public Touch[] touches
        {
            get
            {
                return JsonUtility.FromJson<SerializeArray<Touch>>(GetDataString("touches", InputType.Properties)).data;
            }
        }

        public float GetAxis(string axisName)
        {
            return GetDataFloat(axisName, InputType.Axis);
        }

        public float GetAxisRaw(string axisName)
        {
            return GetDataFloat(axisName, InputType.AxisRaw);
        }

        public bool GetButton(string buttonName)
        {
            return GetDataBit(buttonName, InputType.ButtonPressed);
        }

        public bool GetButtonDown(string buttonName)
        {
            return GetDataBit(buttonName, InputType.ButtonDown);
        }

        public bool GetButtonUp(string buttonName)
        {
            return GetDataBit(buttonName, InputType.ButtonUp);
        }

        public bool GetKey(string name)
        {
            return GetDataBit(name, InputType.KeyPressed);
        }

        public bool GetKey(KeyCode key)
        {
            return GetDataBit(key.ToString(), InputType.KeyPressed);
        }

        public bool GetKeyDown(KeyCode key)
        {
            return GetDataBit(key.ToString(), InputType.KeyDown);
        }

        public bool GetKeyDown(string name)
        {
            return GetDataBit(name, InputType.KeyDown);
        }

        public bool GetKeyUp(KeyCode key)
        {
            return GetDataBit(key.ToString(), InputType.KeyUp);
        }

        public bool GetKeyUp(string name)
        {
            return GetDataBit(name, InputType.KeyUp);
        }

        public bool GetMouseButton(int button)
        {
            return GetDataBit(button.ToString(), InputType.MousePressed);
        }

        public bool GetMouseButtonDown(int button)
        {
            return GetDataBit(button.ToString(), InputType.MouseDown);
        }

        public bool GetMouseButtonUp(int button)
        {
            return GetDataBit(button.ToString(), InputType.MouseUp);
        }

        private float GetDataFloat(string key, InputType type)
        {
            if (!this.recording.CurrentFrame.data.Exists(x => x.eventType == type && x.key == key))
            {
                return 0f;
            }

            var data = this.recording.CurrentFrame.data.FindLast(x => x.eventType == type && x.key == key);

            return data.flt;
        }

        private bool GetDataBit(string key, InputType type)
        {
            if (!this.recording.CurrentFrame.data.Exists(x => x.eventType == type && x.key == key))
            {
                return false;
            }

            var data = this.recording.CurrentFrame.data.FindLast(x => x.eventType == type && x.key == key);

            return data.bit;
        }
        private string GetDataString(string key, InputType type)
        {
            if (!this.recording.CurrentFrame.data.Exists(x => x.eventType == type && x.key == key))
            {
                return string.Empty;
            }

            var data = this.recording.CurrentFrame.data.FindLast(x => x.eventType == type && x.key == key);

            return data.str;
        }

        private Vector2 GetDataVector2(string key, InputType type)
        {
            if (!this.recording.CurrentFrame.data.Exists(x => x.eventType == type && x.key == key))
            {
                return Vector2.zero;
            }

            var data = this.recording.CurrentFrame.data.FindLast(x => x.eventType == type && x.key == key);

            return JsonUtility.FromJson<Vector2>(data.str);
        }

        private Vector3 GetDataVector3(string key, InputType type)
        {
            if (!this.recording.CurrentFrame.data.Exists(x => x.eventType == type && x.key == key))
            {
                return Vector3.zero;
            }

            var data = this.recording.CurrentFrame.data.FindLast(x => x.eventType == type && x.key == key);

            return JsonUtility.FromJson<Vector3>(data.str);
        }
        private int GetDataInt(string key, InputType type)
        {
            if (!this.recording.CurrentFrame.data.Exists(x => x.eventType == type && x.key == key))
            {
                return 0;
            }

            var data = this.recording.CurrentFrame.data.FindLast(x => x.eventType == type && x.key == key);

            return (int)data.flt;
        }

        public AccelerationEvent GetAccelerationEvent(int index)
        {
            return JsonUtility.FromJson<AccelerationEvent>(GetDataString(index.ToString(), InputType.AccelerationEvent));
        }

        public Touch GetTouch(int index)
        {
            return JsonUtility.FromJson<Touch>(GetDataString(index.ToString(), InputType.Touch));
        }

        public bool IsJoystickPreconfigured(string joystickName)
        {
            return GetDataBit(joystickName, InputType.JoystickPreConfigured);
        }

        public string[] GetJoystickNames()
        {
            return JsonUtility.FromJson<SerializeArray<string>>(GetDataString("joystickNames", InputType.JoystickNames)).data;
        }

        public void ResetInputAxes()
        {
            // do nothing since this is a recording
        }
    }

}
