﻿using System.Collections;
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

    public bool IsWall
    {
        get
        {
            return isWall;
        }

        set
        {
            isWall = value;
        }
    }

    public bool TrailMade;
    private SpriteRenderer sr;
    private PlayerInformation pi;
    private PlayerControl playerControl;
    public PlayerNumber PlayerGridOwner;

    [SerializeField]
    private bool isWall = false;
    public bool IsObstacle;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerExit(Collider coll)
    {
        if (!TrailMade && !isWall && coll.tag == "Player")
        {
            TrailMade = true;
            IsObstacle = true;
            pi = coll.GetComponentInParent<PlayerInformation>();
            if (pi != null)
            {
                sr.color = new Color(pi.trailColour.r, pi.trailColour.g, pi.trailColour.b, 255);
                PlayerGridOwner = pi.CurrentPlayerNumber;
            }
        }
    }

    public void SetWallStatus()
    {
        if (isWall)
        {
            IsObstacle = true;
            sr.color = Color.black;
        }
    }
}
