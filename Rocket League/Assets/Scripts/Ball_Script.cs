using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Ball_Script : MonoBehaviour {

	private int count_t1, count_t2;
	private Rigidbody rb;
	private float totalTime = 20f;
	private bool scored = false;
	private bool onPlay = true;

	public Text t1;
	public Text t2;
	public Text time;

    //public AudioSource audio_hit_car;
    public AudioSource audio_hit_field;

	// Use this for initialization
	void Start () {
		count_t1 = 0;
		count_t2 = 0;
		rb = GetComponent<Rigidbody> ();
		greyTransparency.enabled = false;
		PlayerPrefs.SetInt ("onPlay", 0);
		updateText ();
		getReady ();
	}

	// Update is called once per frame
	void FixedUpdate () {
		if (onPlay) {
			if (transform.position [2] < -170 && !scored) {
				scored = true;
				++count_t1;
				onPlay = false;
				Invoke ("setBallToCenter", 3);

			} else if (transform.position [2] > 170 && !scored) {
				scored = true;
				++count_t2;
				onPlay = false;
				Invoke ("setBallToCenter", 3);

			}

			if (Input.GetKeyDown ("r"))
				setBallToCenter ();

			if (Input.GetKeyDown ("o")) {
				++count_t1;
			}
			if (Input.GetKeyDown ("p")) {
				++count_t2;
			}
			updateText ();
		}
	}

	void updateText() {
		t1.text = count_t1.ToString ();
		t2.text = count_t2.ToString ();
		if (onPlay) {
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

	void setBallToCenter(){
		getReady ();
		PlayerPrefs.SetInt ("onPlay", 0);
		transform.position = new Vector3 (0, 2, 0);
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
		PlayerPrefs.SetInt ("countTeam1", count_t1);
		PlayerPrefs.SetInt ("countTeam2", count_t2);
		SceneManager.LoadScene ("ShowResults");
	}


	// variables
	private int coutDownInt;
	public Text countdown;
	public Text getready;
	public Image greyTransparency;

	// call this function to display countdown
	private void getReady ()
	{
		onPlay = false;
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
		//countdownText = num.ToString ();

		if (coutDownInt < 0) {
			countdown.text = "";
			getready.text = "";
			PlayerPrefs.SetInt ("onPlay", 1);
			onPlay = true;
			greyTransparency.enabled = false;
		}
	}

}
