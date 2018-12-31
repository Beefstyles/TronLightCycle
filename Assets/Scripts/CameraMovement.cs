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
        StartCoroutine(DelayCameraMovement());
	}
	
    IEnumerator DelayCameraMovement()
    {
        yield return new WaitForSeconds(0.1F);
        cam.orthographicSize = gg.Width / 2;
        cam.transform.position = new Vector3(gg.Width / 2  - 0.5F, gg.Height / 2 - 0.5F, -5F);
    }
}
