using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GridMove))]
public class AIControl : MonoBehaviour {

    private GridMove gridMove;

    public bool TopSquareSafe, BottomSquareSafe, LeftSquareSafe, RightSquareSafe;

    public GameObject TopSquare, BottomSquare, LeftSquare, RightSquare;
    private PlayerInformation playerInfo;
    private PlayerControl playerControl;

	void Start ()
    {
        gridMove = GetComponent<GridMove>();
        playerInfo = GetComponent<PlayerInformation>();
        playerControl = GetComponent<PlayerControl>();
        if (playerInfo != null)
        {
            if (playerInfo.IsHuman)
            {
                Destroy(GetComponent<AIControl>());
            }
        }
        else
        {
            Debug.LogError("No player Info Found");
        }
        if (gridMove != null)
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
                    playerControl.SetBikeDirectionAndInput("Left");
                }
                else
                {
                    playerControl.SetBikeDirectionAndInput("Right");
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
                    playerControl.SetBikeDirectionAndInput("Up");
                }
                else
                {
                    playerControl.SetBikeDirectionAndInput("Down");
                }
            }
        }
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
                    if (LeftSquareSafe)
                    {
                        playerControl.SetBikeDirectionAndInput("Left");
                    }
                }
                else
                {
                    if (RightSquareSafe)
                    {
                        playerControl.SetBikeDirectionAndInput("Right");
                    }
                }
                break;
            case ("UpDown"):
                if (randDirection == 0)
                {
                    if (TopSquareSafe)
                    {
                        playerControl.SetBikeDirectionAndInput("Up");
                    }
                        
                }
                else
                {
                    if (BottomSquareSafe)
                    {
                        playerControl.SetBikeDirectionAndInput("Down");
                    }
                }
                break;
            case ("Any"):
                switch (randDirection)
                {
                    case (0):
                        playerControl.SetBikeDirectionAndInput("Up");
                        break;
                    case (1):
                        playerControl.SetBikeDirectionAndInput("Down");
                        break;
                    case (2):
                        playerControl.SetBikeDirectionAndInput("Left");
                        break;
                    case (3):
                        playerControl.SetBikeDirectionAndInput("Right");
                        break;
                }
                break;
                
        }
    }

}
