using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridObject : MonoBehaviour {

    [SerializeField]
    private int xpos;
    [SerializeField]
    private int ypos;

    public int Xpos { get { return xpos; } set { xpos = value; } }
    public int Ypos { get { return ypos; } set { ypos = value; } }

    public bool TrailMade;
    private SpriteRenderer sr;

    private void OnTriggerEnter(Collider coll)
    {
        if (!TrailMade && coll.tag == "Player")
        {
            TrailMade = true;
        }
    }

    private void OnTriggerExit(Collider coll)
    {
        if (!TrailMade && coll.tag == "Player")
        {
            TrailMade = true;

        }
    }
}
