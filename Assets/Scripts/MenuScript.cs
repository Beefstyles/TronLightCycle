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


    void Start()
    {
        menuPanel.gameObject.SetActive(false);

        waitingForKey = false;

        for(int i = 0; i < menuPanel.childCount; i++)
        {
            switch (menuPanel.GetChild(i).name)
            {
                case ("LeftKey"):
                    menuPanel.GetChild(i).GetComponentInChildren<Text>().text = GameManager.GM.Player1Left.ToString();
                    break;
                case ("RightKey"):
                    menuPanel.GetChild(i).GetComponentInChildren<Text>().text = GameManager.GM.Player1Right.ToString();
                    break;
                case ("UpKey"):
                    menuPanel.GetChild(i).GetComponentInChildren<Text>().text = GameManager.GM.Player1Up.ToString();
                    break;
                case ("DownKey"):
                    menuPanel.GetChild(i).GetComponentInChildren<Text>().text = GameManager.GM.Player1Down.ToString();
                    break;
                case ("BoostKey"):
                    menuPanel.GetChild(i).GetComponentInChildren<Text>().text = GameManager.GM.Player1Boost.ToString();
                    break;
            }
        }
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && !menuPanel.gameObject.activeSelf)
        {
            menuPanel.gameObject.SetActive(true);
            Time.timeScale = 0F;
        }

        else if (Input.GetKeyDown(KeyCode.Escape) && menuPanel.gameObject.activeSelf)
        {
            menuPanel.gameObject.SetActive(false);
            Time.timeScale = 1F;
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

        yield return WaitForKey(); // Executes endlessly until user presses a key

        switch (keyName)
        {
            case ("Player1Left"):
                GameManager.GM.Player1Left = newKey;
                buttonText.text = GameManager.GM.Player1Left.ToString();
                PlayerPrefs.SetString("Player1Left", GameManager.GM.Player1Left.ToString());
                break;
            case ("Player1Right"):
                GameManager.GM.Player1Right = newKey;
                buttonText.text = GameManager.GM.Player1Right.ToString();
                PlayerPrefs.SetString("Player1Right", GameManager.GM.Player1Right.ToString());
                break;
            case ("Player1Up"):
                GameManager.GM.Player1Up = newKey;
                buttonText.text = GameManager.GM.Player1Right.ToString();
                PlayerPrefs.SetString("Player1Up", GameManager.GM.Player1Right.ToString());
                break;
            case ("Player1Down"):
                GameManager.GM.Player1Down = newKey;
                buttonText.text = GameManager.GM.Player1Right.ToString();
                PlayerPrefs.SetString("Player1Down", GameManager.GM.Player1Right.ToString());
                break;
        }

        yield return null;
    }
}
