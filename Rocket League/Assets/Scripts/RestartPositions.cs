using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
	[RequireComponent(typeof (CarController))]
	public class RestartPositions : MonoBehaviour {

		private GameObject[] cars = new GameObject[12];
		private Vector3[] initPos = new Vector3[12];
		private GameObject p2;

		// Use this for initialization
		void Start () {

			initializeCars ();
			initializeInitPos ();
			restartPositions ();
		}

		void initializeCars(){
			cars [0] = GameObject.Find ("/Cars/Player/Player_1");
			cars [1] = GameObject.Find ("/Cars/Player/Player_2");
			cars [2] = GameObject.Find ("/Cars/Player/Player_3");
			cars [3] = GameObject.Find ("/Cars/Allies/Ally1/Ally1_1");
			cars [4] = GameObject.Find ("/Cars/Allies/Ally1/Ally1_2");
			cars [5] = GameObject.Find ("/Cars/Allies/Ally1/Ally1_3");
			cars [6] = GameObject.Find ("/Cars/Allies/Ally2/Ally2_1");
			cars [7] = GameObject.Find ("/Cars/Allies/Ally2/Ally2_2");
			cars [8] = GameObject.Find ("/Cars/Allies/Ally2/Ally2_3");
			cars [9] = GameObject.Find ("/Cars/Enemies/Enemy_1");
			cars [10] = GameObject.Find ("/Cars/Enemies/Enemy_2");
			cars [11] = GameObject.Find ("/Cars/Enemies/Enemy_3");
		}

		void initializeInitPos(){
			//Player, ally1, ally2
			initPos[0] = initPos[1] = initPos[2] = new Vector3 (0,1,40);
			initPos[3] = initPos[4] = initPos[5] = new Vector3 (-10,1,50);
			initPos[6] = initPos[7] = initPos[8] = new Vector3 (10,1,50);
			//enemy1, enemy2, enemy3
			initPos[9] = new Vector3 (0,1,-40);
			initPos[10] = new Vector3 (-10,1,-50);
			initPos[11] = new Vector3 (10,1,-50);
		}

		public void restartPositions(){

			for (int i = 0; i < 12; i++) {
				if(cars[i] != null){
					cars[i].transform.position = initPos [i];
					rotateCar (i);
					restartKinematics (i);
				}
			}
			setStiffness (0.0001f);
		}

		public void setStiffness(float value){
			for (int i = 0; i < 12; i++) {
				if(cars[i] != null){
					if (i < 3) {
						CarController cc = cars [i].gameObject.GetComponent<CarController> ();
						cc.setStiffness (value);
					} else {
						Enemy_Controller ec = cars [i].gameObject.GetComponent<Enemy_Controller> ();
						ec.setStiffness (value);
					}
				}
			}
		}

		void rotateCar(int idx){
			cars [idx].transform.LookAt (Vector3.zero);
		}

		void restartKinematics(int i){
			GameObject car = cars [i];
			car.GetComponent<Rigidbody> ().isKinematic = true;
			car.GetComponent<Rigidbody> ().isKinematic = false;
			if (i < 3) {
				CarController cc = car.GetComponent<CarController> ();
				cc.restartWheels ();
			} else {
				Enemy_Controller ec = car.GetComponent<Enemy_Controller> ();
				ec.restartWheels ();
			}
		}

		// Update is called once per frame
		void Update () {
			
		}
	}
}
