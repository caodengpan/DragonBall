using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MyButton : MonoBehaviour,IPointerDownHandler,IPointerUpHandler
{
    public bool isPressed;
    public float pressingTime;
    private Image image;
    private void Awake()
    {
        image = GetComponent<Image>();
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        isPressed = true;
        image.color = Color.gray;
        pressingTime = 0;
    }
    private void Update()
    {
        if (isPressed)
        {
            pressingTime += Time.deltaTime;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isPressed = false;
        image.color = Color.white;
        pressingTime = 0;
    }

    
}
