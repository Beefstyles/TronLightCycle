using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GridMove))]
public class AIControl : MonoBehaviour {

    private GridMove gridMove;

    public bool TopSquareSafe, BottomSquareSafe, LeftSquareSafe, RightSquareSafe;

	void Start ()
    {
        gridMove = GetComponent<GridMove>();
        if(gridMove != null)
        {
            ChooseRandomDirection("Any", false);
            gridMove.AICanMove = true;
        }
	}

	
	public void SetNewDirection()
    {
        int changeDir = Random.Range(0, 10);
        // Current bike direction
        switch (gridMove.BikeDirection)
        {
            case (GridMove.Direction.Up):
                if (TopSquareSafe)
                {
                    if(changeDir != 1)
                    {
                        return;
                    }
                    else
                    {
                        ChooseRandomDirection("LeftRight", true);
                    }
                }
                else
                {
                    CheckDirection(true);
                }
                break;
            case (GridMove.Direction.Down):
                if (BottomSquareSafe)
                {
                    if (changeDir != 1)
                    {
                        return;
                    }
                    else
                    {
                        ChooseRandomDirection("LeftRight", true);
                    }
                }
                else
                {
                    CheckDirection(true);
                }
                break;
            case (GridMove.Direction.Right):
                if (RightSquareSafe)
                {
                    if (changeDir != 1)
                    {
                        return;
                    }
                    else
                    {
                        ChooseRandomDirection("UpDown", true);
                    }
                }
                else
                {
                    CheckDirection(false);
                }
                break;
            case (GridMove.Direction.Left):
                if (LeftSquareSafe)
                {
                    if (changeDir != 1)
                    {
                        return;
                    }
                    else
                    {
                        ChooseRandomDirection("UpDown", true);
                    }
                }
                else
                {
                    CheckDirection(false);
                }
                break;
        }
    }

    private void CheckDirection(bool leftandRight)
    {
        if (leftandRight)
        {
            if (LeftSquareSafe && RightSquareSafe)
            {
                ChooseRandomDirection("LeftRight", true);
            }
            else
            {
                if (LeftSquareSafe)
                {
                    SetBikeDirectionAndInput("Left");
                }
                else
                {
                    SetBikeDirectionAndInput("Right");
                }
            }
        }
        else
        {
            if (TopSquareSafe && BottomSquareSafe)
            {

                ChooseRandomDirection("UpDown", true);
            }
            else
            {
                if (TopSquareSafe)
                {
                    SetBikeDirectionAndInput("Up");
                }
                else
                {
                    SetBikeDirectionAndInput("Down");
                }
            }
        }
    }

    private void SetBikeDirectionAndInput(string direction)
    {
        switch (direction)
        {
            case ("Left"):
                gridMove.BikeDirection = GridMove.Direction.Left;
                gridMove.Input = Vector2.left;
                break;
            case ("Right"):
                gridMove.BikeDirection = GridMove.Direction.Right;
                gridMove.Input = Vector2.right;
                break;
            case ("Up"):
                gridMove.BikeDirection = GridMove.Direction.Up;
                gridMove.Input = Vector2.up;
                break;
            case ("Down"):
                gridMove.BikeDirection = GridMove.Direction.Down;
                gridMove.Input = Vector2.down;
                break;

        }
        gridMove.AICanMove = true;

    }

    private void ChooseRandomDirection(string directionOrientation, bool directionLimited)
    {
        int randDirection = 0;
        if (directionLimited)
        {
            randDirection = Random.Range(0, 1);
        }
        else
        {
            randDirection = Random.Range(0, 3);
        }
        
        switch (directionOrientation)
        {
            case ("LeftRight"):
                if (randDirection == 0)
                {
                    SetBikeDirectionAndInput("Left");
                }
                else
                {
                    SetBikeDirectionAndInput("Right");
                }
                break;
            case ("UpDown"):
                if (randDirection == 0)
                {
                    SetBikeDirectionAndInput("Up");
                }
                else
                {
                    SetBikeDirectionAndInput("Down");
                }
                break;
            case ("Any"):
                switch (randDirection)
                {
                    case (0):
                        SetBikeDirectionAndInput("Up");
                        break;
                    case (1):
                        SetBikeDirectionAndInput("Down");
                        break;
                    case (2):
                        SetBikeDirectionAndInput("Left");
                        break;
                    case (3):
                        SetBikeDirectionAndInput("Right");
                        break;
                }
                break;
                
        }
    }

}
