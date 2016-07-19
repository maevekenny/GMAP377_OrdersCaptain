using UnityEngine;
using System;
using System.Collections;

[Serializable]
public class InputScheme {
    public KeyCode Jump;
    public KeyCode Left;
    public KeyCode Right;
    public KeyCode Shoot;
    public KeyCode Punch;
	public KeyCode Pause;
    public KeyCode PauseKeyBoard;
    public bool IsController;
    public Color color;
    public string name;

    //public String RightTriggerAxis; Trigger(Axis) or Button?? for controller
    public String ControllerHorizontalAxisStick_1;
    public String ControllerVerticalAxisStick_1;
    public String ControllerHorizontalAxisStick_2;
    public String ControllerVerticalAxisStick_2;
}
