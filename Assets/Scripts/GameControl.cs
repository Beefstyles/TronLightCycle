using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour {

    public Transform playerSpawn;
    public GameObject PlayerObject;
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
        //SpawnAI();
        SpawnHuman();
    }

    private void SpawnHuman()
    {
        playerSpawn = GameObject.Find("2,2").transform;
        playerSpawnLoc = new Vector3(playerSpawn.position.x, playerSpawn.position.y, 0F);
        GameObject po = Instantiate(PlayerObject, playerSpawnLoc, Quaternion.identity);
        po.GetComponent<GridMove>().IsHuman = true;
    }

    private void SpawnAI()
    {
        playerSpawn = GameObject.Find("2,2").transform;
        playerSpawnLoc = new Vector3(playerSpawn.position.x, playerSpawn.position.y, 0F);
        GameObject po = Instantiate(PlayerObject, playerSpawnLoc, Quaternion.identity);
        po.GetComponent<GridMove>().IsHuman = false;
    }
	
}
