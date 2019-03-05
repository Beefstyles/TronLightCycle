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

    void Awake()
    {
        gridMove = GetComponentInParent<GridMove>();
        currentVectorDirection = gridMove.Input;
    }

    

    void Update()
    {
        if(gridMove.Input != currentVectorDirection)
        {
            currentVectorDirection = gridMove.Input;

            transform.rotation = Quaternion.LookRotation(Vector3.up, currentVectorDirection);
        }
        
    }
}
