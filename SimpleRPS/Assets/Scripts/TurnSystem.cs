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
        
        state = GameState.PlayerTurn;
        PlayerTurn();
        yield return new WaitUntil(() => DropZone.nextTurn = true);
        EnemyTurn();
    }
    void PlayerTurn()
    {
        player.GetComponentInChildren<isDragging>(false);
        enemy.GetComponentInChildren<isDragging>(false);
    }
    void EnemyTurn()
    {
        player.GetComponentInChildren<isDragging>(false);
        enemy.GetComponentInChildren<isDragging>(false);
    }
}
