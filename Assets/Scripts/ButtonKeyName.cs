using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonKeyName : MonoBehaviour
{
    public string KeyName;
    private Text buttonText;
    Button btn;

    private void Awake()
    {
        btn = this.GetComponent<Button>(); ;
        buttonText = btn.GetComponentInChildren<Text>();
        switch (KeyName)
        {
            case ("Left"):
                buttonText.text = InputManager.instance.keybindings.left.ToString();
                break;
            case ("Right"):
                buttonText.text = InputManager.instance.keybindings.right.ToString();
                break;
            case ("Up"):
                buttonText.text = InputManager.instance.keybindings.up.ToString();
                break;
            case ("Down"):
                buttonText.text = InputManager.instance.keybindings.down.ToString();
                break;
            case ("Boost"):
                buttonText.text = InputManager.instance.keybindings.boost.ToString();
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
