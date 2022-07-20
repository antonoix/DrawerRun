using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class DrawCanvas : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public LineDrawer _drawer;

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Mouse enter");
        _drawer.EnableDrawing(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("Mouse exit");
        _drawer.EnableDrawing(false);
    }
}