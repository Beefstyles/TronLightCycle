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
            gridMove.Input = Vector2.up;
        }
	}
	
	void Update ()
    {
		
	}
}
