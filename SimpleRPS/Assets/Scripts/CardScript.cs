//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;

//public class CardScript : MonoBehaviour
//{
//    //title gia cards ???
//    public Text title;
//    public Text text;
//    public Image art;

//    public Card card;

//    public void Start()
//    {
//        LoadCard(card);
//    }
//    public void LoadCard(Card c)
//    {
//        //for non assigned cards- will delete later ??
//        if (c == null)
//        {
//            return;
//        }
//        card = c;
        
//        art.sprite = c.artwork;
//        //for the cards that dont have title === basic cards
//        if (string.IsNullOrEmpty(c.cardText))
//        {
//            text.gameObject.SetActive(false);
//        }
//        else
//        {
//            text.gameObject.SetActive(true);
//            title.text = c.cardName;
//        }
//        //for the cards that dont have text === basic cards
//        if (string.IsNullOrEmpty(c.cardText))
//        {
//            text.gameObject.SetActive(false);
//        }
//        else
//        {
//            text.gameObject.SetActive(true);
//            text.text = c.cardText;
//        }
//    }
//}
