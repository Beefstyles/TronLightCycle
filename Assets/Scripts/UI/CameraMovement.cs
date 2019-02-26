using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    public Camera cam;
    private GridGenerator gg;

	void Start ()
    {
        cam = Camera.main;
        gg = FindObjectOfType<GridGenerator>();
        if (cam.orthographic)
        {
            StartCoroutine(DelayCameraMovementOrtho());
        }
        else
        {
            StartCoroutine(DelayCameraMovementPerspective());
        }
        
	}
	
    IEnumerator DelayCameraMovementOrtho()
    {
        yield return new WaitForSeconds(seconds: 0.01F);
        cam.orthographicSize = gg.Width / 2;
        cam.transform.position = new Vector3(gg.Width / 2  - 0.5F, gg.Height / 2 - 0.5F, -5F);
    }
    IEnumerator DelayCameraMovementPerspective()
    {
        yield return new WaitForSeconds(seconds: 0.01F);
        cam.transform.position = new Vector3(gg.Width / 2, gg.Height / 2 - 0.5F, -gg.Width - 8);
        cam.fieldOfView = gg.Width / 2;
    }
}
