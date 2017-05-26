using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject car1;
	public GameObject car2;
	public GameObject car3;
	public GameObject car4;
	public GameObject car5;
	public GameObject car6;
	public GameObject ball;

	private GameObject selectedCar;
	private Vector3 offset1, offset2;
	private int idx;
	private bool followBall = false;

    void Start()
    {
        offset1 = new Vector3(0, 5, -20);
		offset2 = new Vector3(0, 5, 20);
		selectedCar = car1;
		idx = 1;
		updateCamera ();
		//transform.rotation = selectedCar.transform.rotation;
    }

    void Update()
    {
		
		if(idx > 3)
			transform.position = selectedCar.transform.position + offset1;
		else 
			transform.position = selectedCar.transform.position + offset2;

		if (Input.GetKeyDown ("1")) {
			selectedCar = car1;
			idx = 1;
			transform.rotation = selectedCar.transform.rotation;
		} else if (Input.GetKeyDown ("2")) {
			selectedCar = car2;
			idx = 2;
			transform.rotation = selectedCar.transform.rotation;
		} else if (Input.GetKeyDown ("3")) {
			selectedCar = car3;
			idx = 3;
			transform.rotation = selectedCar.transform.rotation;
		} else if (Input.GetKeyDown ("4")) {
			selectedCar = car4;
			idx = 4;
			transform.rotation = selectedCar.transform.rotation;
		} else if (Input.GetKeyDown ("5")) {
			selectedCar = car5;
			idx = 5;
			transform.rotation = selectedCar.transform.rotation;
		} else if (Input.GetKeyDown ("6")) {
			selectedCar = car6;
			idx = 6;
			transform.rotation = selectedCar.transform.rotation;
		}
		//transform.rotation = selectedCar.transform.rotation;

		updateCamera ();
    }

	void updateCamera(){
		Vector3 posAct = selectedCar.transform.position;
		Vector3 posBall = ball.transform.position;
		if (followBall) {
			Vector3 posCamera = (posBall - posAct);
			posCamera = new Vector3 (posCamera[0], 0, posCamera[2]);
			posCamera = posAct - posCamera.normalized*10;
			posCamera += new Vector3 (0, 4, 0);

			transform.position = posCamera;
			print (posCamera);
			//if(idx<=3) posCamera -= posCamera.normalized * 5;
			//else posCamera += posCamera.normalized * 5;
			transform.rotation = Quaternion.LookRotation (ball.transform.position);
			//print (Time.time + " hola");
		} else {
			if(idx <= 3)
				transform.position = selectedCar.transform.position + offset1;
			else 
				transform.position = selectedCar.transform.position + offset2;
		}
	}
}
