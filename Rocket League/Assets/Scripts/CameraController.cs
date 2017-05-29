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
	private bool working = false;

    void Start()
    {
		offset = new Vector3(0, 5, 0);
		selectedCar = car1;
		//idx = 1;
		updateCamera ();
    }

    void FixedUpdate()
    {
		if (working) {
			changePlayer ();
			updateCamera ();
			if (Input.GetKeyDown (KeyCode.C)) {
				followBall = true;
			} else if (Input.GetKeyDown (KeyCode.V)) {
				followBall = false;
			}
		}
    }

	public void setWorking(bool b){
		working = b;
	}

	void changePlayer(){
		GameObject pl;
		if (Input.GetKeyDown ("1")) {
			pl = GameObject.Find ("/Cars/Player/Player_1");
			if (!pl.activeSelf) {
				pl = GameObject.Find ("/Cars/Player/Player_2");
				if (!pl.activeSelf) {
					pl = GameObject.Find ("/Cars/Player/Player_3");
				}
			}
			selectedCar = pl;
		} else if (Input.GetKeyDown ("2")) {
			pl = GameObject.Find ("/Cars/Allies/Ally1/Ally1_1");
			if (!pl.activeSelf) {
				pl = GameObject.Find ("/Cars/Allies/Ally1/Ally1_2");
				if (!pl.activeSelf) {
					pl = GameObject.Find ("/Cars/Allies/Ally1/Ally1_3");
				}
			}
			selectedCar = pl;

		} else if (Input.GetKeyDown ("3")) {
			pl = GameObject.Find ("/Cars/Allies/Ally2/Ally2_1");
			if (!pl.activeSelf) {
				pl = GameObject.Find ("/Cars/Allies/Ally2/Ally2_2");
				if (!pl.activeSelf) {
					pl = GameObject.Find ("/Cars/Allies/Ally2/Ally2_3");
				}
			}
			selectedCar = pl;
		} else if (Input.GetKeyDown ("4")) {
			pl = GameObject.Find ("/Cars/Enemies/Enemy_1");
			if (!pl.activeSelf) {
				pl = GameObject.Find ("/Cars/Enemies/Enemy_2");
				if (!pl.activeSelf) {
					pl = GameObject.Find ("/Cars/Enemies/Enemy_3");
				}
			}
			selectedCar = pl;
		}
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
