using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUI : CharacterUI
{
    public MyButton attBtn;
    public MyButton lightBallButton;
    public ETCJoystick joystick;

    public float GetAxisX()
    {
        return joystick.axisX.axisValue;
    }
    public bool IsAttBtnPressed()
    {
        return attBtn.isPressed;
    }
    public float GetAttBtnPressTime()
    {
        return attBtn.pressingTime;
    }
    public bool IsLightBallBtnPressed()
    {
        return lightBallButton.isPressed;
    }

}
