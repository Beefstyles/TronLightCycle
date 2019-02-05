using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMove : MonoBehaviour {
    
    private enum Orientation
    {
        Horizontal,
        Vertical
    };

    public enum Direction
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
    public bool AICanMove = false;

    public bool MovementPossible = true;

    public Vector2 Input
    {
        get
        {
            return input;
        }

        set
        {
            input = value;
        }
    }


    public Direction BikeDirection
    {
        get
        {
            return bikeDirection;
        }

        set
        {
            bikeDirection = value;
        }
    }

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
        if (playerInformation.IsHuman)
        {
            if (UnityEngine.Input.GetKey(KeyCode.LeftArrow))
            {
                if (BikeDirection != Direction.Right)
                {
                    Input = Vector2.left;
                    BikeDirection = Direction.Left;
                }
            }

            if (UnityEngine.Input.GetKey(KeyCode.RightArrow))
            {
                if (BikeDirection != Direction.Left)
                {
                    Input = Vector2.right;
                    BikeDirection = Direction.Right;
                }
            }
            if (UnityEngine.Input.GetKey(KeyCode.UpArrow))
            {
                if (BikeDirection != Direction.Down)
                {
                    Input = Vector2.up;
                    BikeDirection = Direction.Up;
                }
            }
            if (UnityEngine.Input.GetKey(KeyCode.DownArrow))
            {
                if (BikeDirection != Direction.Up)
                {
                    Input = Vector2.down;
                    BikeDirection = Direction.Down;
                }
            }
        }
    }
            

    void MoveBike()
    {
        if (MovementPossible)
        {
            transform.Translate(Input);
        }
    }

}
