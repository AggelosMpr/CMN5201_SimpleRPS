using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHand : MonoBehaviour {
    private const int maxCardsAtHand = 5;
    private PlayerDeck myDeck;

    public void Start() {

        myDeck = new PlayerDeck();
        StartCoroutine(StartDraw());
    }
    IEnumerator StartDraw() {
        for (int i = 0; i < maxCardsAtHand; i++) {
            GameObject newCard = Instantiate(myDeck.DrawCard(), transform);
            yield return new WaitForSecondsRealtime(1);
        }
    }
}
