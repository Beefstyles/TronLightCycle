using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour {


    [SerializeField]
    Transform menuPanel;
    Event keyEvent;
    Text buttonText;

    KeyCode newKey;

    bool waitingForKey;

    [SerializeField]
    private GameObject waitForKeyPrompt;


    void Start()
    {
        menuPanel.gameObject.SetActive(false);

        waitingForKey = false;
        waitForKeyPrompt.SetActive(false);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && !menuPanel.gameObject.activeSelf)
        {
            menuPanel.gameObject.SetActive(true);
            Time.timeScale = 0;
        }

        else if (Input.GetKeyDown(KeyCode.Escape) && menuPanel.gameObject.activeSelf)
        {
            menuPanel.gameObject.SetActive(false);
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
            case ("Left"):
                InputManager.instance.ChangeKeyBinding("Left", newKey);
                buttonText.text = newKey.ToString();
                break;
            case ("Right"):
                InputManager.instance.ChangeKeyBinding("Right", newKey);
                buttonText.text = newKey.ToString();
                break;
            case ("Up"):
                InputManager.instance.ChangeKeyBinding("Up", newKey);
                buttonText.text = newKey.ToString();
                break;
            case ("Down"):
                InputManager.instance.ChangeKeyBinding("Down", newKey);
                buttonText.text = newKey.ToString();
                break;
            case ("Boost"):
                InputManager.instance.ChangeKeyBinding("Boost", newKey);
                buttonText.text = newKey.ToString();
                break;
        }

        yield return null;
    }
}
