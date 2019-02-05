using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

    private GridObject go;
    private PlayerInformation playerInformation;
    [SerializeField]
    private float deathTime = 0.1F;
    private AIControl aiControl;
    private GridMove gridMove;

    void Awake()
    {
        playerInformation = GetComponent<PlayerInformation>();
        gridMove = GetComponent<GridMove>();
    }

    void OnTriggerEnter(Collider coll)
    {
        if(coll.gameObject.tag == "Grid")
        {
            go = coll.gameObject.GetComponent<GridObject>();
            if (go != null)
            {
                if (go.TrailMade && !go.IsWall)
                {
                    StartCoroutine(DestroyBike(go.PlayerGridOwner, playerInformation.CurrentPlayerNumber, hitWall: false));
                }
                if (go.IsWall)
                {
                    StartCoroutine(DestroyBike(go.PlayerGridOwner, playerInformation.CurrentPlayerNumber, hitWall: true));
                }
            }
            go = null;
        }
    }

    IEnumerator DestroyBike(PlayerNumber HitGridOwner, PlayerNumber CurrentPlayerNumber, bool hitWall)
    {
        gridMove.AICanMove = false;
        gridMove.MovementPossible = false;
        yield return new WaitForSeconds(deathTime);
        if (HitGridOwner == CurrentPlayerNumber && !hitWall)
        {
            Debug.Log("You totally hit your own trail you fool");
        }
        else
        {
            if(!hitWall)
            {
                Debug.Log("You hit the trail of somebody else i.e. " + CurrentPlayerNumber);
            }
            else
            {
                Debug.Log("You hit a wall");
            }
            
        }
        Destroy(this.gameObject);
    }
}
