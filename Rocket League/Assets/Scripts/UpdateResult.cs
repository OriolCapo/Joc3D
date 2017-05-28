using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UpdateResult : MonoBehaviour {

	public Text t1, t2;

	// Use this for initialization
	void Start () {
		t1.text = PlayerPrefs.GetInt ("countTeam1").ToString();
		t2.text = PlayerPrefs.GetInt ("countTeam2").ToString();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
