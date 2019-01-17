using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMove : MonoBehaviour {
    
    private enum Orientation
    {
        Horizontal,
        Vertical
    };

    private enum Direction
    {
        Up,
        Down,
        Left,
        Right
    };
    
    [SerializeField]
    private Direction bikeDirection = Direction.Up;
    [SerializeField]
    private Vector2 input = Vector2.up;
    [SerializeField]
    private float invokeTime, repeatTime;
    private PlayerInformation playerInformation;
 
    void Start()
    {
        playerInformation = GetComponent<PlayerInformation>();
        InvokeRepeating("MoveBike", invokeTime, repeatTime);
    }

    void CheckForPlayerInput()
    {
        switch (playerInformation.CurrentPlayerNumber)
        {
            case (PlayerNumber.Player1):
                break;
            case (PlayerNumber.Player2):
                break;
            case (PlayerNumber.Player3):
                break;
            case (PlayerNumber.Player4):
                break;
        }
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if(bikeDirection != Direction.Right)
            {
                input = Vector2.left;
                bikeDirection = Direction.Left;
            }
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            if(bikeDirection != Direction.Left)
            {
                input = Vector2.right;
                bikeDirection = Direction.Right;
            }
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (bikeDirection != Direction.Down)
            {
                input = Vector2.up;
                bikeDirection = Direction.Up;
            }
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            if(bikeDirection != Direction.Up)
            {
                input = Vector2.down;
                bikeDirection = Direction.Down;
            }
        }
    }

    void MoveBike()
    {
        transform.Translate(input);
    }

}
