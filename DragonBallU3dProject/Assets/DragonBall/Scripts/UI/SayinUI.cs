using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SayinUI : PlayerUI
{
    public MyButton superSayin1Btn;
    
    public bool IsSuperSayin1BtnPressed()
    {
        return superSayin1Btn.isPressed;
    }
    public virtual void TurnToSuperSayin1()
    {
        superSayin1Btn.gameObject.SetActive(false);
    }
}
