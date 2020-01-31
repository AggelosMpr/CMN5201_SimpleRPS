using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class isDragging : MonoBehaviour, IBeginDragHandler,IDragHandler,IEndDragHandler
{
    
    public Transform StartingZone = null;

    public void Start()
    {

    }
    public void OnBeginDrag(PointerEventData cardTransform)
    {
        StartingZone = this.transform.parent;
        this.transform.SetParent(this.transform.parent.parent);
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }
    public void OnDrag(PointerEventData cardTransform)
    {
        this.transform.position = cardTransform.position;
    }
    public void OnEndDrag(PointerEventData cardTransform)
    {
        this.transform.SetParent (StartingZone);
        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }

}
