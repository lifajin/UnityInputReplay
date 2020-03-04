using System;
using UnityEngine;

namespace LetsBuild.Interfaces
{
    public interface IInputManager
    {
        string inputString { get; }
        IMECompositionMode imeCompositionMode { get; set; }
        string compositionString { get; }
        bool imeIsSelected { get; }
        Vector2 compositionCursorPos { get; set; }
        [Obsolete("eatKeyPressOnTextFieldFocus property is deprecated, and only provided to support legacy behavior.")]
        bool eatKeyPressOnTextFieldFocus { get; set; }
        bool mousePresent { get; }
        int touchCount { get; }
        bool touchPressureSupported { get; }
        bool stylusTouchSupported { get; }
        bool touchSupported { get; }
        bool multiTouchEnabled { get; set; }
        [Obsolete("isGyroAvailable property is deprecated. Please use SystemInfo.supportsGyroscope instead.")]
        bool isGyroAvailable { get; }
        DeviceOrientation deviceOrientation { get; }
        Vector3 acceleration { get; }
        bool compensateSensors { get; set; }
        int accelerationEventCount { get; }
        bool backButtonLeavesApp { get; set; }
        LocationService location { get; }
        Compass compass { get; }
        Gyroscope gyro { get; }
        Vector2 mouseScrollDelta { get; }
        Vector3 mousePosition { get; }
        AccelerationEvent[] accelerationEvents { get; }
        bool anyKeyDown { get; }
        bool anyKey { get; }
        bool simulateMouseWithTouches { get; set; }
        Touch[] touches { get; }

        float GetAxis(string axisName);
        float GetAxisRaw(string axisName);
        bool GetButton(string buttonName);
        bool GetButtonDown(string buttonName);
        bool GetButtonUp(string buttonName);
        bool GetKey(string name);
        bool GetKey(KeyCode key);
        bool GetKeyDown(KeyCode key);
        bool GetKeyDown(string name);
        bool GetKeyUp(KeyCode key);
        bool GetKeyUp(string name);
        bool GetMouseButton(int button);
        bool GetMouseButtonDown(int button);
        bool GetMouseButtonUp(int button);
        AccelerationEvent GetAccelerationEvent(int index);
        Touch GetTouch(int index);
        bool IsJoystickPreconfigured(string joystickName);
        string[] GetJoystickNames();
        void ResetInputAxes();
    }

}
