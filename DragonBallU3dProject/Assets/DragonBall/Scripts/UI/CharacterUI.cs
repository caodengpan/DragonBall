using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterUI : MonoBehaviour
{
    public Sprite charHeadSpr
    {
        set
        {
            charHeadImg.sprite = value;
        }
    }
    public float Hp
    {
        set
        {
            hpStripeImg.fillAmount = value;
        }
    }

    public Image hpStripeImg;
    public Image charHeadImg;
   
}
