using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class isDragging : MonoBehaviour,IDragHandler
{
  public void OnDrag(PointerEventData cardTransform)
    {
        this.transform.position = cardTransform.position;
    }
}
