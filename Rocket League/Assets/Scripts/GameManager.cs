using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //----------------------------------------
    // handles
    public UIManager UI;

    //-----------------------------------------
    // function definitions    

    // Use this for initialization
    void Start()
    {
        UI.GetComponentInChildren<Canvas>().enabled = false;
    }

    public void TogglePauseMenu()
    {
        // not the optimal way but for the sake of readability
        if (UI.GetComponentInChildren<Canvas>().enabled)
        {
            UI.GetComponentInChildren<Canvas>().enabled = false;
            Time.timeScale = 1.0f;
        }
        else
        {
            UI.GetComponentInChildren<Canvas>().enabled = true;
            Time.timeScale = 0f;
        }

        Debug.Log("GAMEMANAGER:: TimeScale: " + Time.timeScale);
    }

}
