using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DropZone : MonoBehaviour,IDropHandler//,IPointerEnterHandler,IPointerExitHandler
{
    [SerializeField]
    Image TransformToPaper;
    [SerializeField]
    Sprite Paper;
    [SerializeField]
    Image TransformToScissors;
    [SerializeField]
    Sprite Scissors;
    [SerializeField]
    Image TransformToRock;
    [SerializeField]
    Sprite Rock;

    /*public void OnPointerEnter(PointerEventData pointerEventData)
    {
        


    }
    public void OnPointerExit(PointerEventData pointerEventData)
    {       


    }*/
    public void OnDrop(PointerEventData pointerEventData)
    {       
        if (this.CompareTag("Field"))
        {
            
            isDragging d= pointerEventData.pointerDrag.GetComponent<isDragging>();
            //d.StartingZone = this.transform;
           
            
            if (d.CompareTag("ToPaper"))
            {
                TransformToPaper.sprite = Paper;
                d.StartingZone = this.transform.parent.parent;
            }
            else if (d.CompareTag("ToScissors"))
            {
                TransformToScissors.sprite = Scissors;
                d.StartingZone = this.transform.parent.parent;
            }
            else if (d.CompareTag("ToRock"))
            {
                TransformToRock.sprite = Rock;
                d.StartingZone = this.transform.parent.parent;
            }
        }
    }
}
