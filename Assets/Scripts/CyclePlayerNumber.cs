using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CyclePlayerNumber : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Text CyclePlayerText;
    private PlayerNumber playerNumber;
    private string[] playerNumbers;
    private string currentPlayerNumber;
    private int playerNumberIndex;
    private Button cyclePlayerButton;
    [SerializeField]
    private bool buttonIsSelected;
    private MenuScript menuScript;
     

    void Start()
    {
        menuScript = FindObjectOfType<MenuScript>();
        cyclePlayerButton = GetComponent<Button>();
        CyclePlayerText = GetComponentInChildren<Text>();
        SetPlayerNumber(1);
        playerNumberIndex = 1;
        playerNumbers = System.Enum.GetNames(typeof(PlayerNumber));
        
    }

    // On highlight add ability to change player number
    public void OnPointerEnter(PointerEventData eventData)
    {
        if(buttonIsSelected != true)
        {
            buttonIsSelected = true;
        }
    }

    // On de-highlight remove ability to change player number
    public void OnPointerExit(PointerEventData eventData)
    {
        if (buttonIsSelected != false)
        {
            buttonIsSelected = false;
        }
    }

    private void Update()
    {
        CheckForInput();
    }
    private void CheckForInput()
    {
        if (buttonIsSelected)
        {
            if (InputManager.instance.GetKeyDown("Left", PlayerNumber.Player1))
            {
                OnDirectionChange("Left");
            }
            if (InputManager.instance.GetKeyDown("Right", PlayerNumber.Player1))
            {
                OnDirectionChange("Right");
            }
        }
        
    }
    public void OnDirectionChange(string direction)
    {
        switch (direction)
        {
            case ("Left"):
                if(playerNumberIndex > 1)
                {
                    playerNumberIndex--;
                }
                else
                {
                    playerNumberIndex = playerNumbers.Length - 1;
                }
                break;
            case ("Right"):
                if (playerNumberIndex < playerNumbers.Length - 1)
                {
                    playerNumberIndex++;
                }
                else
                {
                    playerNumberIndex = 1;
                }
                break;
            default:
                Debug.LogError("Messed up OnDirectionChange with " + direction);
                break;
        }
        SetPlayerNumber(playerNumberIndex);
    }
    private void SetPlayerNumber(int index)
    {
        switch (index)
        {
            case (1):
                playerNumber = PlayerNumber.Player1;
                break;
            case (2):
                playerNumber = PlayerNumber.Player2;
                break;
            case (3):
                playerNumber = PlayerNumber.Player3;
                break;
            case (4):
                playerNumber = PlayerNumber.Player4;
                break;
        }
        CyclePlayerText.text = playerNumber.ToString();
        menuScript.MenuPlayerNumber = playerNumber;
    }
   
}
