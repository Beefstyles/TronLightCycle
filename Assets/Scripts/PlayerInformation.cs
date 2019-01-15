using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerNumber
{
    Player1, Player2, Player3, Player4, None
};

public class PlayerInformation : MonoBehaviour {

    public Color trailColour;

    private PlayerNumber currentPlayerNumber;

    public PlayerNumber CurrentPlayerNumber
    {
        get
        {
            return currentPlayerNumber;
        }

        set
        {
            currentPlayerNumber = value;
        }
    }


}
