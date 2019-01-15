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
    
    private Orientation gridOrientation = Orientation.Horizontal;
    [SerializeField]
    private Direction bikeDirection = Direction.Up;
    [SerializeField]
    private Vector2 input = Vector2.up;
    [SerializeField]
    private float invokeTime, repeatTime;
 
    void Start()
    {
        InvokeRepeating("MoveBike", invokeTime, repeatTime);
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
