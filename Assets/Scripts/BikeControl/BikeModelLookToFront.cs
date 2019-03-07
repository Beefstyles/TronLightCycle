using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BikeModelLookToFront : MonoBehaviour
{
    private Vector3 vectorToTarget;
    [SerializeField]
    private float rotationSpeed;
    GridMove gridMove;
    private Vector2 currentVectorDirection;
    private AIControl aiControl;
    private Vector3 lookDirection;
    public GameObject Model;

    void Awake()
    {
        gridMove = GetComponentInParent<GridMove>();
        currentVectorDirection = gridMove.Input;
        aiControl = GetComponentInParent<AIControl>();
    }

    

    void Update()
    {
        if(gridMove.Input != currentVectorDirection)
        {
            currentVectorDirection = gridMove.Input;
            switch (gridMove.BikeDirection)
            {
                case (GridMove.Direction.Up):

                    //transform.forward = transform.position - aiControl.TopSquare.transform.position;
                    lookDirection = new Vector3(-180F, -90F, 90F);
                    Model.transform.rotation = Quaternion.LookRotation(lookDirection);
                    Debug.Log("Rotating up");
                    break;
                case (GridMove.Direction.Down):
                    transform.rotation = Quaternion.Euler(0, -90, 90);
                    transform.forward = transform.position - aiControl.BottomSquare.transform.position;
                    Debug.Log("Rotating down");
                    break;
                case (GridMove.Direction.Left):
                    transform.rotation = Quaternion.Euler(-90, 0, -0);
                    Debug.Log("Rotating left");
                    //transform.forward = transform.position - aiControl.LeftSquare.transform.position;
                    break;
                case (GridMove.Direction.Right):
                    //transform.forward = transform.position - aiControl.RightSquare.transform.position;
                    Debug.Log("Rotating right");
                    transform.rotation = Quaternion.Euler(90, 90, -90);
                    break;
            }
            
        }
        
    }
}
