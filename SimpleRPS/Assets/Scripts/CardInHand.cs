using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardInHand : MonoBehaviour
{
    public GameObject Hand;
    public GameObject thisHand;

    // Update is called once per frame
    void Update()
    {
        Hand = GameObject.Find("Hand");
        thisHand.transform.SetParent(Hand.transform);
        thisHand.transform.localScale = Vector3.one;
        thisHand.transform.position = new Vector3(transform.position.x, transform.position.y, -1);
        thisHand.transform.eulerAngles = new Vector3(25, 0, 0);

    }
}
