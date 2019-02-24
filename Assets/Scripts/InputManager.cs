using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

    public static InputManager instance;

    public Keybindings player1KeyBindings;
    public Keybindings player2KeyBindings;
    public Keybindings player3KeyBindings;
    public Keybindings player4KeyBindings;

    void Awake()
    {
        //If doesn't already exist, make this instance
        if (instance == null)
        {
            instance = this;
        }

        else if (instance != this)
        {
            Destroy(this);
        }

        DontDestroyOnLoad(this);
    }

    public bool GetKeyDown(string key, PlayerNumber playerNumber)
    {
        if(SelectCorrectKeybindings(playerNumber)!= null)
        {
            if (Input.GetKeyDown(SelectCorrectKeybindings(playerNumber).CheckKey(key)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        return false;
    }

    public bool GetKey(string key, PlayerNumber playerNumber)
    {
        if (SelectCorrectKeybindings(playerNumber) != null)
        {
            if (Input.GetKey(SelectCorrectKeybindings(playerNumber).CheckKey(key)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        return false;
    }

    public bool ChangeKeyBinding(string targetControl, KeyCode keyToChangeTo, PlayerNumber playerNumber)
    {
        return (SelectCorrectKeybindings(playerNumber).SetKey(targetControl, keyToChangeTo));
    }

    private Keybindings SelectCorrectKeybindings(PlayerNumber playerNumber)
    {
        switch (playerNumber)
        {
            case (PlayerNumber.Player1):
                return player1KeyBindings;
            case (PlayerNumber.Player2):
                return player2KeyBindings;
            case (PlayerNumber.Player3):
                return player3KeyBindings;
            case (PlayerNumber.Player4):
                return player4KeyBindings;
            default:
                return null;
        }
    }
}
