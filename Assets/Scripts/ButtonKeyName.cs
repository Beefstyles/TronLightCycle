using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonKeyName : MonoBehaviour
{
    public string KeyName;
    private Text buttonText;
    Button btn;
    EventSystem UIEventSystem;

    private void Awake()
    {
        UIEventSystem = EventSystem.current;
        btn = this.GetComponent<Button>(); ;
        buttonText = btn.GetComponentInChildren<Text>();
        switch (KeyName)
        {
            case ("Left"):
                buttonText.text = InputManager.instance.ReturnKeyBindings("Left", PlayerNumber.Player1);
                break;
            case ("Right"):
                buttonText.text = InputManager.instance.ReturnKeyBindings("Right", PlayerNumber.Player1);
                break;
            case ("Up"):
                buttonText.text = InputManager.instance.ReturnKeyBindings("Up", PlayerNumber.Player1);
                break;
            case ("Down"):
                buttonText.text = InputManager.instance.ReturnKeyBindings("Down", PlayerNumber.Player1);
                break;
            case ("Boost"):
                buttonText.text = InputManager.instance.ReturnKeyBindings("Boost", PlayerNumber.Player1);
                break;
            default:
                Debug.LogError("Error in setting " + KeyName);
                break;
        }
    }

    private void UpdateKeyBindingsDisplay()
    {
        
    }
}
