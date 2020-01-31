using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//akm den exei kamia leitourgikothta

public class PlayerControlManager : TurnScript
{
  public bool isComplete()
  {




     return false;
  }

    public void onEndOfTurn()
    {
        if (!playingTurn)
        {
            playingTurn = false;
        }
    }

    public void onStartOfTurn()
    {
        if (playingTurn)
        {
            playingTurn = true;
        }
    }
}
