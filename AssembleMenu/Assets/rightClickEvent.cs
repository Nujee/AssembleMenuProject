using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class rightClickEvent : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
            Debug.Log(name + " Left!!!");

        else if (eventData.button == PointerEventData.InputButton.Right)
            Debug.Log(name + " Right!!!");
    }
}
