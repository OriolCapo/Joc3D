using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagePause : MonoBehaviour {

    public GameObject pausepanel;
    public GameObject pauseshade;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown("space"))
        {
            pauseshade.SetActive(true);
            pausepanel.SetActive(true);
            //Time.timeScale = 0;

        }



    }
}
