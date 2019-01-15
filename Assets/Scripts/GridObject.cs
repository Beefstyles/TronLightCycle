using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class GridObject : MonoBehaviour {

    [SerializeField]
    private int xpos;
    [SerializeField]
    private int ypos;

    public int Xpos { get { return xpos; } set { xpos = value; } }
    public int Ypos { get { return ypos; } set { ypos = value; } }

    public bool TrailMade;
    private SpriteRenderer sr;
    private PlayerInformation pi;
    public PlayerNumber PlayerGridOwner;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter(Collider coll)
    {
        
    }

    private void OnTriggerExit(Collider coll)
    {
        if (!TrailMade && coll.tag == "Player")
        {
            TrailMade = true;
            pi = coll.GetComponentInParent<PlayerInformation>();
            if (pi != null)
            {
                sr.color = new Color(pi.trailColour.r, pi.trailColour.g, pi.trailColour.b, 255);
                PlayerGridOwner = pi.CurrentPlayerNumber;
            }
        }
    }
}
