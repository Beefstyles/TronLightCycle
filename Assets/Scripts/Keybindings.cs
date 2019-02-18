using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "KeyBindings", menuName = "KeyBindings")]
public class Keybindings : ScriptableObject {

    public KeyCode left, right, up, down, boost;

    public KeyCode CheckKey(string key)
    {
        switch (key)
        {
            case ("Left"):
                return left;
            case ("Right"):
                return right;
            case ("Up"):
                return up;
            case ("Down"):
                return down;
            case ("Boost"):
                return boost;
            default:
                return KeyCode.None;
        }
    }

    public bool SetKey(string targetKeyToChange, KeyCode key)
    {
        switch (targetKeyToChange)
        {
            case ("Left"):
                left = key;
                return true;
            case ("Right"):
                right = key;
                return true;
            case ("Up"):
                up = key;
                return true;
            case ("Down"):
                down = key;
                return true;
            case ("Boost"):
                boost = key;
                return true;
            default:
                Debug.LogError("Target key to change " + targetKeyToChange + " not found");
                return false;
                
        }
    }
}
