using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Joystick : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private RectTransform joystickMoveArea;
    [SerializeField] private RectTransform background;
    [SerializeField] private RectTransform thumbStick;

    bool bWasDragging;
    bool isTap = false;

    public delegate void OnThumbStickValueChanged(Vector2 inputVal, bool isTap);
    public event OnThumbStickValueChanged onThumbstickValueChanged;
    
    public void OnDrag(PointerEventData eventData)
    {
        Vector2 touchPos = eventData.position;
        Vector2 centerPos = background.position;
        Vector2 localOffset = Vector2.ClampMagnitude(touchPos - centerPos, background.sizeDelta.x / 2);
        thumbStick.position = centerPos + localOffset; 
        Vector2 inputVal = localOffset / (background.sizeDelta.x / 2);  
        bWasDragging = true;
        isTap = false;
        onThumbstickValueChanged?.Invoke(inputVal, isTap);

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        background.position = eventData.position;
        thumbStick.position = background.position;
        bWasDragging = false;
        isTap = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        background.position = joystickMoveArea.position;
        thumbStick.position = background.position;
        bWasDragging = false;
        onThumbstickValueChanged?.Invoke(Vector2.zero,isTap);

        
    }
}
