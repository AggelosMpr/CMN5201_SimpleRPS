using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class PlayerDeck {
    public List<GameObject> deck;
    public const int deckSize = 30;
    private CardDatabase db;

    public PlayerDeck() {
        Init();
    }
    public void Init() {        
        db = (CardDatabase)Resources.Load("CardDatabase", typeof(CardDatabase));
        deck = new List<GameObject>();
        for (int i = 0; i < deckSize; i++) {
            deck.Add(db.cardList[Random.Range(0, db.cardList.Count)]);
        }
        
    }

    public GameObject DrawCard() {
        GameObject go = deck[0];
        deck.RemoveAt(0);
        return go;
    }
}
