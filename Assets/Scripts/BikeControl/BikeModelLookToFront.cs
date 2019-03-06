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
                    Quaternion rotation = Quaternion.LookRotation(aiControl.TopSquare.transform.position
                        - transform.position, transform.TransformDirection(Vector3.up));
                    transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);
                    break;
                case (GridMove.Direction.Down):
                    transform.forward = transform.position - aiControl.BottomSquare.transform.position;
                    break;
                case (GridMove.Direction.Left):
                    transform.forward = transform.position - aiControl.LeftSquare.transform.position;
                    break;
                case (GridMove.Direction.Right):
                    transform.forward = transform.position - aiControl.RightSquare.transform.position;
                    break;
            }
            
        }
        
    }
}
