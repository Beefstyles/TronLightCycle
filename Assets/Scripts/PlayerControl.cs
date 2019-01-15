using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

    private GridObject go;
    private PlayerInformation pi;
    [SerializeField]
    private float deathTime = 0.1F;

    void Awake()
    {
        pi = GetComponent<PlayerInformation>();
    }

    void OnTriggerEnter(Collider coll)
    {
        if(coll.gameObject.tag == "Grid")
        {
            go = coll.gameObject.GetComponent<GridObject>();
            if (go != null)
            {
                if (go.TrailMade)
                {
                    StartCoroutine(DestroyBike(go.PlayerGridOwner, pi.CurrentPlayerNumber));
                }
            }
        }
    }

    IEnumerator DestroyBike(PlayerNumber HitGridOwner, PlayerNumber CurrentPlayerNumber)
    {
        yield return new WaitForSeconds(deathTime);
        if (HitGridOwner == CurrentPlayerNumber)
        {
            Debug.Log("You totally hit your own trail you fool");
        }
        else
        {
            Debug.Log("You hit the trail of somebody else i.e. " + CurrentPlayerNumber);
        }
        Destroy(this.gameObject);
    }
}
