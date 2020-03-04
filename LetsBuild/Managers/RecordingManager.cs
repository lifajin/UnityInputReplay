using LetsBuild.Data;
using LetsBuild.Enums;
using LetsBuild.Interfaces;
using UnityEngine;

namespace LetsBuild.Managers
{
    public class RecordingManager : IInputManager
    {
        private readonly Recording recording;

        public RecordingManager(Recording recording)
        {
            this.recording = recording ?? throw new System.ArgumentNullException(nameof(recording));
        }

        public string inputString
        {
            get
            {
                var str = Input.inputString;
                AddInputString(str, "inputString", InputType.Properties);
                return str;
            }
        }

        public IMECompositionMode imeCompositionMode
        {
            get
            {

                var mode = Input.imeCompositionMode;
                AddInputInt((int)mode, "imeCompositionMode", InputType.Properties);
                return mode;

            }
            set => Input.imeCompositionMode = value;
        }

        public string compositionString
        {
            get
            {
                var str = Input.compositionString;
                AddInputString(str, "compositionString", InputType.Properties);
                return str;
            }
        }

        public bool imeIsSelected
        {
            get
            {
                var str = Input.imeIsSelected;
                AddInputBit(str, "imeIsSelected", InputType.Properties);
                return str;
            }
        }

        public Vector2 compositionCursorPos
        {
            get
            {
                var inp = Input.compositionCursorPos;
                AddInputString(JsonUtility.ToJson(inp), "compositionCursorPos", InputType.Properties);
                return inp;
            }
            set => Input.compositionCursorPos = value;
        }
        public bool eatKeyPressOnTextFieldFocus
        {
            get
            {
                var inp = Input.eatKeyPressOnTextFieldFocus;
                AddInputBit(inp, "eatKeyPressOnTextFieldFocus", InputType.Properties);
                return inp;
            }
            set => Input.eatKeyPressOnTextFieldFocus = value;
        }

        public bool mousePresent
        {
            get
            {
                var inp = Input.mousePresent;
                AddInputBit(inp, "mousePresent", InputType.Properties);
                return inp;
            }
        }

        public int touchCount
        {
            get
            {
                var inp = Input.touchCount;
                AddInputInt(inp, "touchCount", InputType.Properties);
                return inp;
            }
        }

        public bool touchPressureSupported
        {
            get
            {
                var inp = Input.touchPressureSupported;
                AddInputBit(inp, "touchPressureSupported", InputType.Properties);
                return inp;
            }
        }


        public bool stylusTouchSupported
        {
            get
            {
                var inp = Input.stylusTouchSupported;
                AddInputBit(inp, "stylusTouchSupported", InputType.Properties);
                return inp;
            }
        }

        public bool touchSupported
        {
            get
            {
                var inp = Input.touchSupported;
                AddInputBit(inp, "touchSupported", InputType.Properties);
                return inp;
            }
        }

        public bool multiTouchEnabled
        {
            get
            {
                var inp = Input.multiTouchEnabled;
                AddInputBit(inp, "multiTouchEnabled", InputType.Properties);
                return inp;
            }
            set => Input.multiTouchEnabled = value;
        }

        public bool isGyroAvailable
        {
            get
            {
                var inp = Input.isGyroAvailable;
                AddInputBit(inp, "isGyroAvailable", InputType.Properties);
                return inp;
            }
        }

        public DeviceOrientation deviceOrientation
        {
            get
            {
                var inp = Input.deviceOrientation;
                AddInputInt((int)inp, "deviceOrientation", InputType.Properties);
                return inp;
            }
        }

        public Vector3 acceleration
        {
            get
            {
                var inp = Input.acceleration;
                AddInputString(JsonUtility.ToJson(inp), "acceleration", InputType.Properties);
                return inp;
            }
        }

        public bool compensateSensors
        {
            get
            {
                var inp = Input.compensateSensors;
                AddInputBit(inp, "compensateSensors", InputType.Properties);
                return inp;
            }
            set => Input.compensateSensors = value;
        }

        public int accelerationEventCount
        {
            get
            {
                var inp = Input.accelerationEventCount;
                AddInputInt(inp, "accelerationEventCount", InputType.Properties);
                return inp;
            }
        }

        public bool backButtonLeavesApp
        {
            get
            {
                var inp = Input.backButtonLeavesApp;
                AddInputBit(inp, "backButtonLeavesApp", InputType.Properties);
                return inp;
            }
            set => Input.backButtonLeavesApp = value;
        }

        public LocationService location
        {
            get
            {
                var inp = Input.location;
                AddInputString(JsonUtility.ToJson(inp), "location", InputType.LocationService);
                return inp;
            }
        }

        public Compass compass
        {
            get
            {
                var inp = Input.compass;
                AddInputString(JsonUtility.ToJson(inp), "compass", InputType.Compass);
                return inp;
            }
        }

        public Gyroscope gyro
        {
            get
            {
                var inp = Input.gyro;
                AddInputString(JsonUtility.ToJson(inp), "gyro", InputType.Gyro);
                return inp;
            }
        }

        public Vector2 mouseScrollDelta
        {
            get
            {
                var inp = Input.mouseScrollDelta;
                AddInputString(JsonUtility.ToJson(inp), "mouseScrollDelta", InputType.Properties);
                return inp;
            }
        }

        public Vector3 mousePosition
        {
            get
            {
                var inp = Input.mousePosition;
                AddInputString(JsonUtility.ToJson(inp), "mousePosition", InputType.Properties);
                return inp;
            }
        }

        public AccelerationEvent[] accelerationEvents
        {
            get
            {
                var inp = Input.accelerationEvents;
                var data = new SerializeArray<AccelerationEvent>()
                {
                    data = inp
                };

                AddInputString(JsonUtility.ToJson(data), "accelerationEvents", InputType.Properties);
                return inp;
            }
        }

        public bool anyKeyDown
        {
            get
            {
                var inp = Input.anyKeyDown;
                AddInputBit(inp, "anyKeyDown", InputType.Properties);
                return inp;
            }
        }

        public bool anyKey
        {
            get
            {
                var inp = Input.anyKey;
                AddInputBit(inp, "anyKey", InputType.Properties);
                return inp;
            }
        }

        public bool simulateMouseWithTouches
        {
            get
            {
                var inp = Input.simulateMouseWithTouches;
                AddInputBit(inp, "simulateMouseWithTouches", InputType.Properties);
                return inp;
            }
            set => Input.simulateMouseWithTouches = value;
        }

        public Touch[] touches
        {
            get
            {
                var inp = Input.touches;
                var data = new SerializeArray<Touch>()
                {
                    data = inp
                };
                AddInputString(JsonUtility.ToJson(data), "touches", InputType.Properties);
                return inp;
            }
        }

        public float GetAxis(string axisName)
        {
            var input = Input.GetAxis(axisName);

            AddInputFloat(input, axisName, InputType.Axis);

            return input;
        }

        public float GetAxisRaw(string axisName)
        {
            var input = Input.GetAxisRaw(axisName);
            AddInputFloat(input, axisName, InputType.AxisRaw);

            return input;
        }

        public bool GetButton(string buttonName)
        {
            var input = Input.GetButton(buttonName);

            if (input)
            {
                AddInputBit(input, buttonName, InputType.ButtonPressed);
            }

            return input;
        }

        public bool GetButtonDown(string buttonName)
        {
            var input = Input.GetButtonDown(buttonName);

            if (input)
            {
                AddInputBit(input, buttonName, InputType.ButtonDown);
            }

            return input;
        }

        public bool GetButtonUp(string buttonName)
        {
            var input = Input.GetButtonUp(buttonName);
            if (input)
            {
                AddInputBit(input, buttonName, InputType.ButtonUp);
            }

            return input;

        }

        public bool GetKey(string name)
        {
            var input = Input.GetKey(name);
            if (input)
            {
                AddInputBit(input, name, InputType.KeyPressed);
            }

            return input;

        }

        public bool GetKey(KeyCode key)
        {
            var input = Input.GetKey(key);
            if (input)
            {
                AddInputBit(input, key.ToString(), InputType.KeyPressed);
            }

            return input;
        }

        public bool GetKeyDown(KeyCode key)
        {
            var input = Input.GetKeyDown(key);
            if (input)
            {
                AddInputBit(input, key.ToString(), InputType.KeyDown);
            }

            return input;

        }

        public bool GetKeyDown(string name)
        {
            var input = Input.GetKeyDown(name);
            if (input)
            {
                AddInputBit(input, name, InputType.KeyDown);
            }

            return input;

        }

        public bool GetKeyUp(KeyCode key)
        {
            var input = Input.GetKeyUp(key);
            if (input)
            {
                AddInputBit(input, key.ToString(), InputType.KeyUp);
            }

            return input;

        }

        public bool GetKeyUp(string name)
        {
            var input = Input.GetKeyUp(name);
            if (input)
            {
                AddInputBit(input, name, InputType.KeyUp);
            }

            return input;

        }

        public bool GetMouseButton(int button)
        {
            var input = Input.GetMouseButton(button);
            if (input)
            {
                AddInputBit(input, button.ToString(), InputType.MousePressed);
            }

            return input;
        }

        public bool GetMouseButtonDown(int button)
        {
            var input = Input.GetMouseButtonDown(button);
            if (input)
            {
                AddInputBit(input, button.ToString(), InputType.ButtonDown);
            }

            return input;
        }

        public bool GetMouseButtonUp(int button)
        {
            var input = Input.GetMouseButtonUp(button);
            if (input)
            {
                AddInputBit(input, button.ToString(), InputType.ButtonUp);
            }

            return input;
        }
        private void AddInputBit(bool input, string key, InputType type)
        {
            if (!this.recording.CurrentFrame.data.Exists(x => x.key == key && x.eventType == type))
            {
                this.recording.CurrentFrame.data.Add(new CapturedInput()
                {
                    eventType = type,
                    key = key,
                    bit = input
                });
            }
        }
        private void AddInputFloat(float input, string key, InputType type)
        {
            if (!this.recording.CurrentFrame.data.Exists(x => x.key == key && x.eventType == type))
            {
                this.recording.CurrentFrame.data.Add(new CapturedInput()
                {
                    eventType = type,
                    key = key,
                    flt = input
                });
            }
        }
        private void AddInputString(string input, string key, InputType type)
        {
            if (!this.recording.CurrentFrame.data.Exists(x => x.key == key && x.eventType == type))
            {
                this.recording.CurrentFrame.data.Add(new CapturedInput()
                {
                    eventType = type,
                    key = key,
                    str = input
                });
            }
        }
        private void AddInputInt(int input, string key, InputType type)
        {
            if (!this.recording.CurrentFrame.data.Exists(x => x.key == key && x.eventType == type))
            {
                this.recording.CurrentFrame.data.Add(new CapturedInput()
                {
                    eventType = type,
                    key = key,
                    flt = input
                });
            }
        }

        public AccelerationEvent GetAccelerationEvent(int index)
        {
            var input = Input.GetAccelerationEvent(index);

            AddInputString(JsonUtility.ToJson(input), index.ToString(), InputType.AccelerationEvent);

            return input;
        }

        public Touch GetTouch(int index)
        {
            var input = Input.GetTouch(index);

            AddInputString(JsonUtility.ToJson(input), index.ToString(), InputType.Touch);

            return input;
        }

        public bool IsJoystickPreconfigured(string joystickName)
        {
            var input = Input.IsJoystickPreconfigured(joystickName);

            AddInputBit(input, joystickName, InputType.JoystickPreConfigured);

            return input;
        }

        public string[] GetJoystickNames()
        {
            var input = Input.GetJoystickNames();
            var data = new SerializeArray<string>()
            {
                data = input
            };
            AddInputString(JsonUtility.ToJson(data), "joystickNames", InputType.JoystickNames);

            return input;
        }

        public void ResetInputAxes()
        {
            Input.ResetInputAxes();
        }
    }

}
