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
    private float invokeTime;
    [SerializeField]
    private float repeatTime;

    public float BoostFactor;
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
        UpdateBikeMovement();
    }

    public void UpdateBikeMovement()
    {
        CancelInvoke();
        InvokeRepeating("MoveBike", invokeTime, repeatTime * BoostFactor);
    }

    void MoveBike()
    {
        if (MovementPossible)
        {
            transform.Translate(Input);
        }
    }

}
