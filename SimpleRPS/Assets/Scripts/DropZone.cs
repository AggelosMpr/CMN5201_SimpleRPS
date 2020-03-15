﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

//htan monobehavior an xreiastei kapote
public class DropZone : TurnSystem, IDropHandler//,IPointerEnterHandler,IPointerExitHandler
{
    [SerializeField]
    int dropZoneIndex;
    [SerializeField]
    private Sprite elementSprite;
    public static bool nextTurn = false;
    public static int turns = 1;

    public void SetSprite(Sprite newSprite) {
        elementSprite = newSprite;
        GetComponent<Image>().sprite = elementSprite;
    }
    public void OnDrop(PointerEventData pointerEventData) {

        isDragging d = pointerEventData.pointerDrag.GetComponent<isDragging>();
        if (this.CompareTag("Discard") && turns <= 10)
        {
            
            PassTurn();
            Destroy(d.gameObject);
        }
        else if (this.CompareTag("BoardElement") && turns <= 10) {

            if (d.fromElement == BoardManager.Instance.GetBoardElement(dropZoneIndex) || d.fromElement == "3") {

                BoardManager.Instance.SetBoardElement(d.toElement, dropZoneIndex);
                PassTurn();
                Destroy(d.gameObject);
            }
        }    
        else {
            return;
        }
    }
    public void PassTurn()
    {
        if (TurnSystem.state == GameState.PlayerTurn)
        {
            nextTurn = true;
            TurnSystem.state = GameState.EnemyTurn;

        }
        else if (TurnSystem.state == GameState.EnemyTurn)
        {
            nextTurn = true;
            TurnSystem.state = GameState.PlayerTurn;
        }
    }
}

