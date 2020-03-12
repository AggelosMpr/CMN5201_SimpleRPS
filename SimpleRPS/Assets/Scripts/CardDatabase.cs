using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CardDatabase",menuName = "Assets/CardDatabase",order =0)]

public class CardDatabase : ScriptableObject {
    public List<GameObject> cardList = new List<GameObject>();
}
