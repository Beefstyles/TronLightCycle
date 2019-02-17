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
            default:
                return KeyCode.None;
        }
    }
}
