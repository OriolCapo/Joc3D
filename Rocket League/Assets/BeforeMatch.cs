using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeforeMatch : MonoBehaviour {

	private Vector3 iniPos, finPos, iniRot, finRot;//, pos, rot;
	private bool once=true;

	void Start () {
		iniPos = new Vector3 (-100.0f, 100.0f, 150.0f);
		finPos = new Vector3 (-100.0f, 100.0f, -150.0f);

		iniRot = new Vector3 (35, 120, 0);
		finRot = new Vector3 (35, 50, 0);
		PlayerPrefs.SetInt ("onPlay", 0);
		PlayerPrefs.SetInt ("startGame", 0);
		moveCamera ();
	}

	void moveCamera(){
		for (float i = 0.0f; i <= 3.0f; i += 0.001f) {
			StartCoroutine (setParams(i));
		}
	}

	IEnumerator setParams(float i){
		yield return new WaitForSeconds(i*5);
		Vector3 pos = Vector3.Lerp (iniPos, finPos, i);
		Vector3 rot = Vector3.Lerp (iniRot, finRot, i);
		if (once) {
			transform.position = pos;
			transform.rotation = Quaternion.Euler (rot);
		}

		if (pos.Equals(finPos) && once) {
			once = false;
			CameraController cc = GetComponent<CameraController> ();
			cc.setWorking (true);
			PlayerPrefs.SetInt ("startGame", 1);
		}
	}
}
