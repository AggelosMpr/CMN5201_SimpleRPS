using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum GameState { Start,PlayerTurn,EnemyTurn,Won, Lost}
public class TurnSystem : MonoBehaviour
{
    public static GameState state;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject enemy;
    private void Start()
    {
        state = GameState.Start;
        StartCoroutine(PlayGame());
        //SetupGame() eventually 8a kaloume edw thn pista
    }
    IEnumerator PlayGame()
    {
          while (DropZone.turns < 10)
        {
        state = GameState.PlayerTurn;
        PlayerTurn();
        yield return new WaitUntil(() => DropZone.nextTurn == true);
            DropZone.turns += 1;
            DropZone.nextTurn = false;
        EnemyTurn();
        yield return new WaitUntil(() => DropZone.nextTurn == true);
            DropZone.turns += 1;
            DropZone.nextTurn = false;
        }
        Debug.Log("Game Ended");
    }
    void PlayerTurn()
    {

      isDragging[] playerCards = player.GetComponentsInChildren<isDragging>();
      isDragging[] enemyCards =  enemy.GetComponentsInChildren<isDragging>();

        foreach (isDragging drag in playerCards)
        {
            drag.enabled = true;
        }
        foreach (isDragging drag in enemyCards)
        {
            drag.enabled = false;
        }
    }
    void EnemyTurn()
    {
        isDragging[] playerCards = player.GetComponentsInChildren<isDragging>();
        isDragging[] enemyCards = enemy.GetComponentsInChildren<isDragging>();

        foreach (isDragging drag in playerCards)
        {
            drag.enabled = false;
        }
        foreach (isDragging drag in enemyCards)
        {
            drag.enabled = true;
        }
    }
}
