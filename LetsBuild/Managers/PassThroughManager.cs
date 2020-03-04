using LetsBuild.Interfaces;
using UnityEngine;

namespace LetsBuild.Managers
{
    public class PassThroughManager : IInputManager
    {
        public string inputString => Input.inputString;

        public IMECompositionMode imeCompositionMode { get => Input.imeCompositionMode; set => Input.imeCompositionMode = value; }

        public string compositionString => Input.compositionString;

        public bool imeIsSelected => Input.imeIsSelected;

        public Vector2 compositionCursorPos { get => Input.compositionCursorPos; set => Input.compositionCursorPos = value; }
        public bool eatKeyPressOnTextFieldFocus { get => Input.eatKeyPressOnTextFieldFocus; set => Input.eatKeyPressOnTextFieldFocus = value; }

        public bool mousePresent => Input.mousePresent;

        public int touchCount => Input.touchCount;

        public bool touchPressureSupported => Input.touchPressureSupported;

        public bool stylusTouchSupported => Input.stylusTouchSupported;

        public bool touchSupported => Input.touchSupported;

        public bool multiTouchEnabled { get => Input.multiTouchEnabled; set => Input.multiTouchEnabled = value; }

        public bool isGyroAvailable => Input.isGyroAvailable;

        public DeviceOrientation deviceOrientation => Input.deviceOrientation;

        public Vector3 acceleration => Input.acceleration;

        public bool compensateSensors { get => Input.compensateSensors; set => Input.compensateSensors = value; }

        public int accelerationEventCount => Input.accelerationEventCount;

        public bool backButtonLeavesApp { get => Input.backButtonLeavesApp; set => Input.backButtonLeavesApp = value; }

        public LocationService location => Input.location;

        public Compass compass => Input.compass;

        public Gyroscope gyro => Input.gyro;

        public Vector2 mouseScrollDelta => Input.mouseScrollDelta;

        public Vector3 mousePosition => Input.mousePosition;

        public AccelerationEvent[] accelerationEvents => Input.accelerationEvents;

        public bool anyKeyDown => Input.anyKeyDown;

        public bool anyKey => Input.anyKey;

        public bool simulateMouseWithTouches { get => Input.simulateMouseWithTouches; set => Input.simulateMouseWithTouches = value; }

        public Touch[] touches => Input.touches;

        public AccelerationEvent GetAccelerationEvent(int index)
        {
            return Input.GetAccelerationEvent(index);
        }

        public float GetAxis(string axisName)
        {
            return Input.GetAxis(axisName);
        }

        public float GetAxisRaw(string axisName)
        {
            return Input.GetAxisRaw(axisName);
        }

        public bool GetButton(string buttonName)
        {
            return Input.GetButton(buttonName);
        }

        public bool GetButtonDown(string buttonName)
        {
            return Input.GetButtonDown(buttonName);
        }

        public bool GetButtonUp(string buttonName)
        {
            return Input.GetButtonUp(buttonName);
        }

        public string[] GetJoystickNames()
        {
            return Input.GetJoystickNames();
        }

        public bool GetKey(string name)
        {
            return Input.GetKey(name);
        }

        public bool GetKey(KeyCode key)
        {
            return Input.GetKey(key);
        }

        public bool GetKeyDown(KeyCode key)
        {
            return Input.GetKeyDown(key);
        }

        public bool GetKeyDown(string name)
        {
            return Input.GetKeyDown(name);
        }

        public bool GetKeyUp(KeyCode key)
        {
            return Input.GetKeyUp(key);
        }

        public bool GetKeyUp(string name)
        {
            return Input.GetKeyUp(name);
        }

        public bool GetMouseButton(int button)
        {
            return Input.GetMouseButton(button);
        }

        public bool GetMouseButtonDown(int button)
        {
            return Input.GetMouseButtonDown(button);
        }

        public bool GetMouseButtonUp(int button)
        {
            return Input.GetMouseButtonUp(button);
        }

        public Touch GetTouch(int index)
        {
            return Input.GetTouch(index);
        }

        public bool IsJoystickPreconfigured(string joystickName)
        {
            return Input.IsJoystickPreconfigured(joystickName);
        }

        public void ResetInputAxes()
        {
            Input.ResetInputAxes();
        }
    }

}
