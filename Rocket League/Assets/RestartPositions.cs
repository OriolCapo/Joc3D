using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartPositions : MonoBehaviour {

	public GameObject player;
	public GameObject aliat1;
	public GameObject aliat2;
	public GameObject enemy1;
	public GameObject enemy2;
	public GameObject enemy3;

	private Vector3 posP, pos_a1, pos_a2, pos_e1, pos_e2, pos_e3;

	// Use this for initialization
	void Start () {
		posP = new Vector3 (0,5,40);
		pos_a1 = new Vector3 (-10,5,50);
		pos_a2 = new Vector3 (10,5,50);

		pos_e1 = new Vector3 (0,5,-40);
		pos_e2 = new Vector3 (-10,5,-50);
		pos_e3 = new Vector3 (10,5,-50);
	}

	public void restartPositions(){
		player.transform.position = posP;
		aliat1.transform.position = pos_a1;
		aliat2.transform.position = pos_a2;
		enemy1.transform.position = pos_e1;
		enemy2.transform.position = pos_e2;
		enemy3.transform.position = pos_e3;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
