using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartPositions : MonoBehaviour {

	public GameObject[] cars;
	private Vector3[] initPos;

	private Vector3 offset1, offset2;

	// Use this for initialization
	void Start () {
		offset1 = new Vector3 (0, 0, -50);
		offset2 = new Vector3 (0, 0, 50);

		initPos = new Vector3[6];
		//Player, ally1, ally2
		initPos[0] = new Vector3 (0,1,40);
		initPos[1] = new Vector3 (-10,1,50);
		initPos[2] = new Vector3 (10,1,50);
		//enemy1, enemy2, enemy3
		initPos[3] = new Vector3 (0,1,-40);
		initPos[4] = new Vector3 (-10,1,-50);
		initPos[5] = new Vector3 (10,1,-50);

		restartPositions ();
	}

	public void restartPositions(){

		for (int i = 0; i < cars.Length; i++) {
			cars[i].transform.position = initPos [i];
			rotateCar (i);
			restartKinematics (cars[i]);
		}
	}

	void rotateCar(int idx){
		Vector3 relativePos = initPos [idx];
		if (idx < 3)
			relativePos += offset1;
		else
			relativePos += offset2;
		Quaternion rotation = Quaternion.LookRotation(relativePos);
		cars[idx].transform.rotation = rotation;
	}

	void restartKinematics(GameObject g){
		g.gameObject.GetComponent<Rigidbody> ().isKinematic = true;
		g.gameObject.GetComponent<Rigidbody> ().isKinematic = false;
	}

	// Update is called once per frame
	void Update () {
		
	}
}
