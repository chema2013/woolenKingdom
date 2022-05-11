using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class PenCanvas : MonoBehaviour, IPointerClickHandler
{
    public Action OnPenCanvasLeftClickEvent;
    public Action OnPenCanvasRightClickEvent;

    public void OnPointerClick(PointerEventData eventData) {
        if (eventData.pointerId == -1) {
            OnPenCanvasLeftClickEvent?.Invoke();
        }
        else if (eventData.pointerId == -2)
        {
            OnPenCanvasRightClickEvent?.Invoke();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
