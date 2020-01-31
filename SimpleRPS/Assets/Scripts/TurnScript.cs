using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//akm den exei kamia leitourgikothta
public class TurnScript : ScriptableObject
{
    //to start as 0 every game
    [System.NonSerialized]
    public int index;


    [System.NonSerialized]
    protected bool playingTurn;
    public bool Execute()
    {
        return true ;
    }


}
