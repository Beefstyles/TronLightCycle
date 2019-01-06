using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMove : MonoBehaviour {

    [SerializeField]
    private float _moveSpeed = 5F;
    private float _gridSize = 1F;
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
    private Direction bikeDirection = Direction.Up;
    [SerializeField]
    private bool allowDiagonals = false;
    private bool correctDiagonalSpeed = true;
    [SerializeField]
    private Vector2 input = Vector2.up;
    private bool isMoving = true;
    private Vector3 startPosition;
    private Vector3 endPosition;
    private float t;
    private float factor;
    private int xMovement, yMovement;

    void Update()
    {
        if (!isMoving)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                input = Vector2.left;
                bikeDirection = Direction.Left;
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                input = Vector2.right;
                bikeDirection = Direction.Right;
            }
            if (Input.GetKey(KeyCode.UpArrow))
            {
                input = Vector2.up;
                bikeDirection = Direction.Up;
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                input = Vector2.down;
                bikeDirection = Direction.Down;
            }
            /*if (!_allowDiagonals)
            {
                if(Mathf.Abs(input.x) > Mathf.Abs(input.y))
                {
                    input.y = 0;
                }
                else
                {
                    input.x = 0;
                }
            }
            */


            if (input != Vector2.zero)
            {
                StartCoroutine(Move(transform));
            }
        }
    }

    private IEnumerator Move(Transform transform)
    {
        isMoving = true;
        startPosition = transform.position;
        t = 0;
        switch (bikeDirection)
        {
            case Direction.Up:
                xMovement = 0;
                yMovement = 1;
                break;
            case Direction.Down:
                xMovement = 0;
                yMovement = -1;
                break;
            case Direction.Left:
                xMovement = -1;
                yMovement = 0;
                break;
            case Direction.Right:
                xMovement = 1;
                yMovement = 0;
                break;
        }
        endPosition = new Vector3(startPosition.x + xMovement * _gridSize,
        startPosition.y + yMovement * _gridSize, startPosition.z);

        if(allowDiagonals && correctDiagonalSpeed)
        {
            factor = 0.707F;
        }
        else
        {
            factor = 1F;
        }

        while (t < 1F)
        {
            t += Time.deltaTime * (_moveSpeed / _gridSize) * factor;
            transform.position = Vector3.Lerp(startPosition, endPosition, t);
            yield return null;
        }
        isMoving = false;
        yield return 0;
    }

}
