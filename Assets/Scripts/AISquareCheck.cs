using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AISquareCheck : MonoBehaviour {

    private AIControl aiControl;
    private GridObject gridObject;

    void Awake()
    {
        aiControl = GetComponentInParent<AIControl>();
    }
	void OnTriggerEnter(Collider coll)
    {
        if(aiControl != null)
        {
            if (coll.gameObject.tag == "Grid")
            {
                gridObject = coll.GetComponent<GridObject>();
                if(gridObject != null)
                {
                    switch (name)
                    {
                        case ("TopCheck"):
                            if (gridObject.IsObstacle)
                            {
                                aiControl.TopSquareSafe = false;
                            }
                            else
                            {
                                aiControl.TopSquareSafe = true;
                            }
                            break;
                        case ("BottomCheck"):
                            if (gridObject.IsObstacle)
                            {
                                aiControl.BottomSquareSafe = false;
                            }
                            else
                            {
                                aiControl.BottomSquareSafe = true;
                            }
                            break;
                        case ("LeftCheck"):
                            if (gridObject.IsObstacle)
                            {
                                aiControl.LeftSquareSafe = false;
                            }
                            else
                            {
                                aiControl.LeftSquareSafe = true;
                            }
                            break;
                        case ("RightCheck"):
                            if (gridObject.IsObstacle)
                            {
                                aiControl.RightSquareSafe = false;
                            }
                            else
                            {
                                aiControl.RightSquareSafe = true;
                            }
                            break;
                    }
                }
            }

        }
    }
}
