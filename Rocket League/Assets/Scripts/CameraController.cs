using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject car1;
	public GameObject car2;
	public GameObject car3;
	public GameObject ball;

	private GameObject selectedCar;
	private Vector3 offset;
	//private int idx;
	private bool followBall = false;

    void Start()
    {
		offset = new Vector3(0, 5, 0);
		selectedCar = car1;
		//idx = 1;
		updateCamera ();
    }

    void FixedUpdate()
    {
		if (Input.GetKeyDown (KeyCode.C)) {
			followBall = true;
		} else if (Input.GetKeyDown (KeyCode.V)) {
			followBall = false;
		}

		updateCamera ();
    }

	void updateCamera(){
		Vector3 posAct = selectedCar.transform.position;
		Vector3 posBall = ball.transform.position;
		//En aquest mode, la pilota sempre es veu
		if (followBall) {
			Vector3 direction = (posBall-posAct).normalized;
			direction = new Vector3(direction[0], 0, direction[2]);
			Vector3 posCam = posAct - direction * 20;
			transform.position = posCam + offset;
			transform.LookAt(posBall);
		//Aqui la camara sempre segueix els moviments del jugador
		} else {
			Vector3 frwrd = selectedCar.transform.forward;
			Vector3 posCam = posAct - (frwrd.normalized * 20);
			transform.position = posCam + offset;
			transform.rotation = selectedCar.transform.rotation;
		}
	}

    public void changeSelectedCar(int eleccio)
    {
        if (eleccio == 1)
        {
            selectedCar = car1;
            //idx = 1;
        }else if (eleccio == 2)
        {
            selectedCar = car2;
            //idx = 2;
        }else if (eleccio == 3)
        {
            selectedCar = car3;
            //idx = 3;
        }
		updateCamera ();
    }
}
