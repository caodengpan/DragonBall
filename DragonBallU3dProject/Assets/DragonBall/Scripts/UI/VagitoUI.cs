using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VagitoUI : SayinUI
{
    public MyButton airBladeBtn;
    public MyButton kameBtn;
    protected void Awake()
    {
        airBladeBtn.gameObject.SetActive(false);
        kameBtn.gameObject.SetActive(false);
    }

    public bool IsAirBladeBtnPreesed()
    {
        return airBladeBtn.isPressed;
    }
    public float GetKameBtnPressingTime()
    {
        return kameBtn.pressingTime;
    }
    public bool IsKameBtnPressed()
    {
        return kameBtn.isPressed;
    }
    public override void TurnToSuperSayin1()
    {
        base.TurnToSuperSayin1();
        airBladeBtn.gameObject.SetActive(true);
        kameBtn.gameObject.SetActive(true);
    }
}
