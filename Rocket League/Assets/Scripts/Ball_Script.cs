using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace UnityStandardAssets.Vehicles.Car
{
	[RequireComponent(typeof (CarController))]
	public class Ball_Script : MonoBehaviour {

		private int count_t1, count_t2;
		private Rigidbody rb;
		private float totalTime = 181.0f;
		private bool scored = false;
		private bool onPlay;

		public Text t1;
		public Text t2;
		public Text time;

	    //public AudioSource audio_hit_car;
	    public AudioSource audio_hit_field;
		private gameTransitions gameTransition;

		// Use this for initialization
		void Start () {
			count_t1 = 0;
			count_t2 = 0;
			rb = GetComponent<Rigidbody> ();
			gameTransition = GetComponent<gameTransitions>();
			updateText (true);
		}

		// Update is called once per frame
		void FixedUpdate () {
			if (PlayerPrefs.GetInt ("startGame") == 1) {
				PlayerPrefs.SetInt ("startGame", 0);
				gameTransition.getReady ();
			} else {
				onPlay = PlayerPrefs.GetInt ("onPlay") == 1;
				if (onPlay) {
					if (transform.position [2] < -170 && !scored) {
						scoreGoal (1);
					} else if (transform.position [2] > 170 && !scored) {
						scoreGoal (2);
					}

					if (Input.GetKeyDown ("r")) {
						setBallToCenter ();
						RestartPositions rp = GameObject.Find ("Stadium3").gameObject.GetComponent<RestartPositions> ();
						rp.setStiffness (3.0f);
					}
					if (Input.GetKeyDown (KeyCode.Plus)) {
						totalTime += 20.0f;
					}
					if (Input.GetKeyDown ("o")) {
						++count_t1;
					}
					if (Input.GetKeyDown ("p")) {
						++count_t2;
					}
					updateText (false);

				}
			}
		}

		void scoreGoal(int team){
			scored = true;
			if (team == 1)
				++count_t1;
			else
				++count_t2;
			PlayerPrefs.SetInt ("onPlay", 0);
			Explote ps = GetComponent<Explote> ();
			ps.playIt ();
			Invoke ("setBallToCenter", 3);
			Invoke ("getReady", 3);
		}

		void updateText(bool b) {
			t1.text = count_t1.ToString ();
			t2.text = count_t2.ToString ();
			if (onPlay || b && !scored) {
				totalTime -= Time.deltaTime;
				if (totalTime <= 0.0f) {
					onPlay = false;
					PlayerPrefs.SetInt ("onPlay", 0);
					finishGame ();
				} else {
					int current = (int)totalTime;
					int min = current / 60;
					int sec = current % 60;
					time.text = min.ToString () + ":";
					if (sec < 10)
						time.text += "0";
					time.text += sec.ToString ();
				}
			}
		}

		public void getReady(){
			gameTransition.getReady ();
		}

		void setBallToCenter(){
			gameObject.SetActive (true);
			transform.position = new Vector3 (0, 5, 0);
			rb.isKinematic = true;
			rb.isKinematic = false;
			RestartPositions rp = GameObject.Find ("Stadium3").gameObject.GetComponent<RestartPositions> ();
			rp.restartPositions ();
			scored = false;
		}

	    private void OnCollisionEnter(Collision collision)
	    {
	        if (collision.gameObject.CompareTag("Car"))
	        {
	            //audio_hit_car.Play();
	        }
	        else{
	            audio_hit_field.Play();
	        }
	    }

		private void finishGame(){
			gameTransition.finishGame (count_t1, count_t2);
		}
	}
}
