using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ButtonKeyName : MonoBehaviour
{
    public string KeyName;
    private Text buttonText;
    Button btn;
    MenuScript menuScript;

    private void Awake()
    {
        menuScript = FindObjectOfType<MenuScript>();
        btn = this.GetComponent<Button>(); ;
        buttonText = btn.GetComponentInChildren<Text>();
        UpdateKeyBindingsDisplay();
    }

    public void UpdateKeyBindingsDisplay()
    {
        switch (KeyName)
        {
            case ("Left"):
                buttonText.text = InputManager.instance.ReturnKeyBindings("Left", menuScript.MenuPlayerNumber);
                break;
            case ("Right"):
                buttonText.text = InputManager.instance.ReturnKeyBindings("Right", menuScript.MenuPlayerNumber);
                break;
            case ("Up"):
                buttonText.text = InputManager.instance.ReturnKeyBindings("Up", menuScript.MenuPlayerNumber);
                break;
            case ("Down"):
                buttonText.text = InputManager.instance.ReturnKeyBindings("Down", menuScript.MenuPlayerNumber);
                break;
            case ("Boost"):
                buttonText.text = InputManager.instance.ReturnKeyBindings("Boost", menuScript.MenuPlayerNumber);
                break;
            default:
                Debug.LogError("Error in setting " + KeyName);
                break;
        }
    }
}
