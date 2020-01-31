﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

//htan monobehavior an xreiastei kapote
public class DropZone : TurnSystem,IDropHandler//,IPointerEnterHandler,IPointerExitHandler
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

    public static bool nextTurn = false;
    public static int turns = 1;

    /*public void OnPointerEnter(PointerEventData pointerEventData)
    {
        


    }
    public void OnPointerExit(PointerEventData pointerEventData)
    {       

    }*/
    public void Update()
    {
        Debug.Log(turns);
        Debug.Log(nextTurn);
    }
    public void OnDrop(PointerEventData pointerEventData)
    {
        Debug.Log("On Drop Running");
        if (this.CompareTag("Field") && turns <= 10)
        {
            
            isDragging d= pointerEventData.pointerDrag.GetComponent<isDragging>();
            //d.StartingZone = this.transform;
           
            
            if (d.CompareTag("ToPaper"))
            {
                TransformToPaper.sprite = Paper;
                d.StartingZone = this.transform.parent.parent;
                if (TurnSystem.state == GameState.PlayerTurn)
                {
                    nextTurn = true;
                    TurnSystem.state = GameState.EnemyTurn;
                    
                }
                else if(TurnSystem.state == GameState.EnemyTurn)
                {
                    nextTurn = true;
                    TurnSystem.state = GameState.PlayerTurn;
                }
                
            }
            else if (d.CompareTag("ToScissors"))
            {
                TransformToScissors.sprite = Scissors;
                d.StartingZone = this.transform.parent.parent;
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
            else if (d.CompareTag("ToRock"))
            {
                TransformToRock.sprite = Rock;
                d.StartingZone = this.transform.parent.parent;
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
    }
}
