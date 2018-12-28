using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    [SerializeField]
    private float speed;
    private Vector3 pos;
    private Transform tr;
    private Vector2 dir;
    private Rigidbody rb;
    [SerializeField]
    private float maxSpeed;
    private float currentVelocity;
    [SerializeField]
    private Vector2 startDirection;
 

	void Start ()
    {
        pos = transform.position;
        tr = transform;
        rb = GetComponent<Rigidbody>();
        dir = Vector2.right;
    }
	
	void Update ()
    {
        currentVelocity = rb.velocity.magnitude;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            dir = Vector2.left;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            dir = Vector2.right;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            dir = Vector2.up;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            dir = Vector2.down;
        }

        rb.AddForce(dir, ForceMode.VelocityChange);
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
    }
}
