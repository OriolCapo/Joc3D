using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace UnityStandardAssets.Vehicles.Car
{
	[RequireComponent(typeof (CarController))]
	public class gameTransitions : MonoBehaviour {

		// Use this for initialization
		void Start () {
			
		}
		
		// Update is called once per frame
		void Update () {
			
		}

		// variables
		private int coutDownInt;
		public Text countdown;
		public Text getready;
		public Image greyTransparency;

		// call this function to display countdown
		public void getReady ()
		{
			PlayerPrefs.SetInt ("onPlay", 0);
			coutDownInt = 3;
			Invoke ("showNumber", 0.0f);
			Invoke ("showNumber", 1.2f);
			Invoke ("showNumber", 2.4f);
			Invoke ("showNumber", 3.6f);
		}


		private void showNumber(){
			greyTransparency.enabled = true;
			getready.text = "Get Ready!";

			countdown.text = coutDownInt.ToString();
			--coutDownInt;

			if (coutDownInt < 0) {
				countdown.text = "";
				getready.text = "";
				PlayerPrefs.SetInt ("onPlay", 1);
				greyTransparency.enabled = false;
				RestartPositions rp = GameObject.Find ("Stadium3").gameObject.GetComponent<RestartPositions> ();
				rp.setStiffness (3.0f);
			}
		}

		public void finishGame(int count_t1, int count_t2){
			PlayerPrefs.SetInt ("countTeam1", count_t1);
			PlayerPrefs.SetInt ("countTeam2", count_t2);

			getready.text = "Time out!";
			Invoke ("loadShowResultScene", 3);
		}

		void loadShowResultScene(){
			SceneManager.LoadScene ("ShowResults");
		}
	}
}
