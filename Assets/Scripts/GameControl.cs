using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour {

    public Transform playerSpawn;
    public GameObject PlayerObject;
    private GameObject po;
    private Vector3 playerSpawnLoc;

	void Start ()
    {
        StartCoroutine("DelaySpawn");
    }

    IEnumerator DelaySpawn()
    {
        yield return new WaitForSeconds(0.1F);
        FindSpawnLocAndSpawn();

    }

    private void FindSpawnLocAndSpawn()
    {
        playerSpawn = GameObject.Find("0,0").transform;
        playerSpawnLoc = new Vector3(playerSpawn.position.x, playerSpawn.position.y, 0F);
        po = Instantiate(PlayerObject, playerSpawnLoc, Quaternion.identity);
    }
	
}
