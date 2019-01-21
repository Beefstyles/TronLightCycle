using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager GM;

    public KeyCode Player1Left { get; set; }
    public KeyCode Player1Right { get; set; }
    public KeyCode Player1Up { get; set; }
    public KeyCode Player1Down { get; set; }

    void Awake()
    {
        Player1Left = KeyCode.LeftArrow;
        Player1Right = KeyCode.RightArrow;
        Player1Up = KeyCode.UpArrow;
        Player1Down = KeyCode.DownArrow;

        PlayerPrefs.SetString("Player1Left", Player1Left.ToString());
        PlayerPrefs.SetString("Player1Right", Player1Right.ToString());
        PlayerPrefs.SetString("Player1Up", Player1Up.ToString());
        PlayerPrefs.SetString("Player1Down", Player1Down.ToString());

        if (GM == null)
        {
            DontDestroyOnLoad(gameObject);
        }
        else if(GM != this)
        {
            Destroy(gameObject);
        }

        Player1Left = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Player1LeftKey", "LeftArrow"));
        Player1Right = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Player1RightKey", "RightArrow"));
        Player1Up = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Player1UpKey", "UpArrow"));
        Player1Down = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Player1DownKey", "DownArrow"));
    }

}
