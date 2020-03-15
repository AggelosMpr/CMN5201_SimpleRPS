using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHand : MonoBehaviour {
    private const int maxCardsAtHand = 5;
    private PlayerDeck myDeck;
    [SerializeField]
    private AudioSource drawCard;

    public void Start() {
        drawCard = GetComponent<AudioSource>();
        myDeck = new PlayerDeck();
        StartCoroutine(StartDraw());
    }
    IEnumerator StartDraw() {
        for (int i = 0; i < maxCardsAtHand; i++) {
            
            GameObject newCard = Instantiate(myDeck.DrawCard(), transform);
            drawCard.Play();
            yield return new WaitForSecondsRealtime(1);
        }
    }
}
