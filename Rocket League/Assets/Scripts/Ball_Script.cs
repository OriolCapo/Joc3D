using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball_Script : MonoBehaviour {

	private int count_t1, count_t2;
	private Rigidbody rb;
	private float totalTime = 180f;

	public Text t1;
	public Text t2;
	public Text time;

    public AudioSource audio_hit_car;
    public AudioSource audio_hit_field;

	// Use this for initialization
	void Start () {
		count_t1 = 0;
		count_t2 = 0;
		rb = GetComponent<Rigidbody> ();
		updateText ();
	}

	// Update is called once per frame
	void FixedUpdate () {
		if (transform.position [2] < -170) {
			++count_t1;
			setBallToCenter ();
		} else if (transform.position [2] > 170) {
			++count_t2;
			setBallToCenter ();
		}

		if (Input.GetKeyDown("1")) {
			++count_t1;
		}
		if (Input.GetKeyDown("2")) {
			++count_t2;
		}
		updateText ();
	}

	void updateText() {
		t1.text = count_t1.ToString ();
		t2.text = count_t2.ToString ();
		totalTime -= Time.deltaTime;
		int current = (int)totalTime;
		int min = current / 60;
		int sec = current % 60;
		time.text = min.ToString () + ":";
		if (sec < 10)
			time.text += "0";
		time.text += sec.ToString ();
	}

	void setBallToCenter(){
		transform.position = new Vector3 (0, 5, 0);
		rb.isKinematic = true;
		rb.isKinematic = false;
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Car"))
        {
            audio_hit_car.Play();
        }
        else{
            audio_hit_field.Play();
        }
    }
}
