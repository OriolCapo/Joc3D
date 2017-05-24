using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartPositions : MonoBehaviour {
	/*
	public GameObject player;
	public GameObject ally1;
	public GameObject ally2;
	public GameObject enemy1;
	public GameObject enemy2;
	public GameObject enemy3;*/

	public GameObject[] cars;
	private Vector3[] initPos;

	private Vector3 posP, pos_a1, pos_a2, pos_e1, pos_e2, pos_e3;

	// Use this for initialization
	void Start () {
		/*
		cars[0] = player;
		cars[1] = ally1; 
		cars[2] = ally2;
		cars[3] = enemy1;
		cars[4] = enemy2;
		cars[5] = enemy3;
		*/
		initPos = new Vector3[6];
		initPos[0] = new Vector3 (0,5,40);
		initPos[1] = new Vector3 (-10,5,50);
		initPos[2] = new Vector3 (10,5,50);
		initPos[3] = new Vector3 (0,5,-40);
		initPos[4] = new Vector3 (-10,5,-50);
		initPos[5] = new Vector3 (10,5,-50);
		/*
		posP = new Vector3 (0,5,40);
		pos_a1 = new Vector3 (-10,5,50);
		pos_a2 = new Vector3 (10,5,50);

		pos_e1 = new Vector3 (0,5,-40);
		pos_e2 = new Vector3 (-10,5,-50);
		pos_e3 = new Vector3 (10,5,-50);
		*/
	}

	public void restartPositions(){

		for (int i = 0; i < cars.Length; i++) {
			cars[i].transform.position = initPos [i];
			restartKinematics (cars[i]);
		}
		/*
		player.transform.position = posP;
		ally1.transform.position = pos_a1;
		ally2.transform.position = pos_a2;
		enemy1.transform.position = pos_e1;
		enemy2.transform.position = pos_e2;
		enemy3.transform.position = pos_e3;
		*/
	}

	void restartKinematics(GameObject g){
		g.gameObject.GetComponent<Rigidbody> ().isKinematic = true;
		g.gameObject.GetComponent<Rigidbody> ().isKinematic = false;
	}

	// Update is called once per frame
	void Update () {
		
	}
}
