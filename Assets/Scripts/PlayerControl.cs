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
    [SerializeField]
    private float boostTimeMax;
    [SerializeField]
    private float currentBoostTime;
    private bool boostEnabled;
    [SerializeField]
    private float boostIncrease;

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

    void Start()
    {
        if (playerInformation.IsHuman)
        {
            SetBikeDirectionAndInput("Up");
        }
        boostEnabled = false;
    }

    public void SetBikeDirectionAndInput(string direction)
    {
        switch (direction)
        {
            case ("Left"):
                gridMove.BikeDirection = GridMove.Direction.Left;
                gridMove.Input = Vector2.left;
                break;
            case ("Right"):
                gridMove.BikeDirection = GridMove.Direction.Right;
                gridMove.Input = Vector2.right;
                break;
            case ("Up"):
                gridMove.BikeDirection = GridMove.Direction.Up;
                gridMove.Input = Vector2.up;
                break;
            case ("Down"):
                gridMove.BikeDirection = GridMove.Direction.Down;
                gridMove.Input = Vector2.down;
                break;

        }
        gridMove.AICanMove = true;

    }

    void Update()
    {
        if (playerInformation.IsHuman)
        {
            if(InputManager.instance.GetKeyDown("Left"))
            {
                if (gridMove.BikeDirection != GridMove.Direction.Right)
                {
                    SetBikeDirectionAndInput("Left");
                }
            }

            if (InputManager.instance.GetKeyDown("Right"))
            {
                if (gridMove.BikeDirection != GridMove.Direction.Left)
                {
                    SetBikeDirectionAndInput("Right");
                }
            }

            if (InputManager.instance.GetKeyDown("Up"))
            {
                if (gridMove.BikeDirection != GridMove.Direction.Down)
                {
                    SetBikeDirectionAndInput("Up");
                }
            }

            if (InputManager.instance.GetKeyDown("Down"))
            {
                if (gridMove.BikeDirection != GridMove.Direction.Up)
                {
                    SetBikeDirectionAndInput("Down");
                }
            }

            if (InputManager.instance.GetKeyDown("Boost"))
            {
                if (!boostEnabled)
                {
                    EnableBoost();
                }
            }

            if (boostEnabled)
            {
                BoostBikeSpeed();
            }
            
        }
    }

    void CheckForPlayerInput()
    {
        switch (playerInformation.CurrentPlayerNumber)
        {
            case (PlayerNumber.Player1):
                break;
            case (PlayerNumber.Player2):
                break;
            case (PlayerNumber.Player3):
                break;
            case (PlayerNumber.Player4):
                break;
        }
    }

    void EnableBoost()
    {
        currentBoostTime = boostTimeMax;
        boostEnabled = true;
        gridMove.BoostFactor = boostIncrease;
        gridMove.UpdateBikeMovement();
    }

    void BoostBikeSpeed()
    {
        if (currentBoostTime >= 0)
        {
            currentBoostTime -= Time.deltaTime;
        }
        else
        {
            gridMove.BoostFactor = 1;
            boostEnabled = false;
            gridMove.UpdateBikeMovement();
        }
        
    }
}
