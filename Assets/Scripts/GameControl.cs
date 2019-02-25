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
        SpawnAI();
        SpawnHuman("20,20", PlayerNumber.Player1);
        //SpawnHuman("40,40", PlayerNumber.Player2);
        //SpawnHuman("50,50", PlayerNumber.Player3);
        //SpawnHuman("60,60", PlayerNumber.Player4);
    }

    private void SpawnHuman(string transformXY, PlayerNumber playerNumber)
    {
        playerSpawn = GameObject.Find(transformXY).transform;
        playerSpawnLoc = new Vector3(playerSpawn.position.x, playerSpawn.position.y, 0F);
        GameObject po = Instantiate(PlayerObject, playerSpawnLoc, Quaternion.identity);
        po.GetComponent<PlayerInformation>().IsHuman = true;
        po.GetComponent<PlayerInformation>().CurrentPlayerNumber = playerNumber;
    }

    private void SpawnAI()
    {
        playerSpawn = GameObject.Find("2,2").transform;
        playerSpawnLoc = new Vector3(playerSpawn.position.x, playerSpawn.position.y, 0F);
        GameObject po = Instantiate(PlayerObject, playerSpawnLoc, Quaternion.identity);
        po.GetComponent<PlayerInformation>().IsHuman = false;
        po.GetComponent<PlayerInformation>().CurrentPlayerNumber = PlayerNumber.None;
    }
	
}
