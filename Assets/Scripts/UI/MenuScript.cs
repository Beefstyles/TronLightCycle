using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MenuScript : MonoBehaviour {


    [SerializeField]
    Transform menuPanel;
    Event keyEvent;
    Text buttonText;

    KeyCode newKey;

    bool waitingForKey;

    [SerializeField]
    private GameObject waitForKeyPrompt;
    EventSystem UIEventSystem;
    [SerializeField]
    private GameObject firstSelectedObject;
    [SerializeField]
    private GameObject inputButtonsParent;
    private ButtonKeyName[] inputButtons;

    private PlayerNumber menuPlayerNumber;

    public PlayerNumber MenuPlayerNumber
    {
        get
        {
            return menuPlayerNumber;
        }

        set
        {
            menuPlayerNumber = value;
            foreach(var inputButton in inputButtons)
            {
                inputButton.UpdateKeyBindingsDisplay();
            }
        }
    }

    void Start()
    {
        menuPanel.gameObject.SetActive(false);
        UIEventSystem = EventSystem.current;
        waitingForKey = false;
        waitForKeyPrompt.SetActive(false);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && !menuPanel.gameObject.activeSelf)
        {
            menuPanel.gameObject.SetActive(true);
            inputButtons = inputButtonsParent.GetComponentsInChildren<ButtonKeyName>();
            UIEventSystem.SetSelectedGameObject(firstSelectedObject);
            Time.timeScale = 0;
        }

        else if (Input.GetKeyDown(KeyCode.Escape) && menuPanel.gameObject.activeSelf)
        {
            menuPanel.gameObject.SetActive(false);
            inputButtons = null;
            Time.timeScale = 1;
        }
    }

    void OnGUI()
    {
        // Key event dictates what key our user presses - using Event.current to detect the current event

        keyEvent = Event.current;

        // Executes if a button gets pressed and the user presses a key

        if(keyEvent.isKey && waitingForKey)
        {
            newKey = keyEvent.keyCode; // assigns new key to the key user presses
            waitingForKey = false;
        }
    }

    public void StartAssignment(string keyName)
    {
        if (!waitingForKey)
        {
            StartCoroutine(AssignKey(keyName));
        }
    }

    //Assigns buttonText to the text component of the button that was pressed
    public void SendText(Text text)
    {
        buttonText = text;
    }

    // Control the flow of the below coroutine
    IEnumerator WaitForKey()
    {
        while (!keyEvent.isKey)
        {
            yield return null;
        }
    }

    /* AssigKey takes a keyname as a parameter with the keyname checked in a switch statement
     * Each cases assigns the command that keyName represents to the new key that the user presses, which is grabbed in the OnGUI function above
    */ 
    public IEnumerator AssignKey(string keyName)
    {
        waitingForKey = true;
        if (waitForKeyPrompt != null)
        {
            waitForKeyPrompt.SetActive(true);
            waitForKeyPrompt.GetComponentInChildren<Text>().text = string.Format("Set a button for {0}", keyName);
        }
        else
        {
            Debug.LogError("Missing waitForKeyPrompt gameobject");
        }

        yield return WaitForKey(); // Executes endlessly until user presses a key

        waitForKeyPrompt.SetActive(false);
        switch (keyName)
        {
            //TODO - Update the player number to actually change
            case ("Left"):
                InputManager.instance.ChangeKeyBinding("Left", newKey, PlayerNumber.Player1);
                buttonText.text = newKey.ToString();
                break;
            case ("Right"):
                InputManager.instance.ChangeKeyBinding("Right", newKey, PlayerNumber.Player1);
                buttonText.text = newKey.ToString();
                break;
            case ("Up"):
                InputManager.instance.ChangeKeyBinding("Up", newKey, PlayerNumber.Player1);
                buttonText.text = newKey.ToString();
                break;
            case ("Down"):
                InputManager.instance.ChangeKeyBinding("Down", newKey, PlayerNumber.Player1);
                buttonText.text = newKey.ToString();
                break;
            case ("Boost"):
                InputManager.instance.ChangeKeyBinding("Boost", newKey, PlayerNumber.Player1);
                buttonText.text = newKey.ToString();
                break;
        }

        yield return null;
    }

}
