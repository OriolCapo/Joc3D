using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectCars : MonoBehaviour {

	public float rotationSpeed = 10f;
	public GameObject[] cars;//, car2, car3;

	public Text carName;
	public Text info;
	public Image panel;

	private Vector3 circumcentre;
	private float radius;
	private float angle;
	private float subAngle;
	private bool left, right;
	private float idx;

	private string[] carNames = new string[] { "Rex Hasta", "Basilikos", "Rienfleche" };
	private string[] infos = new string[] { "The \"Mario\" of rocket cars.\nThis car has balanced stats all around, making it good for beginners and veterans alike.\nYou can't go wrong with this car."
        , "This car is STRONG.\nWhile not on the faster side, this car has incredible strenght, enabling it to take hits better, and hit back harder.\nTruly a powerhouse to fear on the field."
        , "In one word, this car is FAST.\nThis car is able to fleet around the field at unmatched speeds. However, it comes at a cost for it's steering and strenght.\nNot recommended for beginners." };

	void Start () {
		circumcentre = new Vector3 (0.0f,2.0f,-23.09f);
		radius = 23.09f;
		angle = 0.0f;
		left = false;
		right = false;
		idx = 0.0f;
		setInformation ((int)idx);
	}
	

	void Update()
	{
		if (Input.GetKeyDown ("right") && !right && !left) {
			right = true;
			subAngle = 0.0f;
			angle = idx * 2 * Mathf.PI / 3;
			idx += 1;
			if (idx == 3)
				idx = 0;
			hideInformation (false);
			setInformation ((int)idx);
		} else if (Input.GetKeyDown ("left") && !right && !left){
			left = true;
			subAngle = 0.0f;
			angle = idx * 2 * Mathf.PI / 3;
			idx -= 1;
			if (idx == -1)
				idx = 2;
			hideInformation (false);
			setInformation ((int)idx);
		}
		if (right) {
			if (subAngle <= 2 * Mathf.PI / 3) {
				subAngle += 2*Time.deltaTime;
				angle += 2*Time.deltaTime;
			} else {
				right = false;
				subAngle = 0.0f;
				hideInformation (true);
			}
		}
		else if (left){
			if (subAngle <= 2 * Mathf.PI / 3) {
				subAngle += 2*Time.deltaTime;
				angle -= 2*Time.deltaTime;

			} else {
				left = false;
				subAngle = 0.0f;
				hideInformation (true);
			}
		}
			
		for (int i = 0; i <= 4; i += 2) {
			rotateCar (cars [i / 2], angle + i * 2 * Mathf.PI / 3);
		}

		/*
		timer += Time.deltaTime;
		angle = timer;
		rotateCar (car1, angle);
		rotateCar (car2, angle + 2*Mathf.PI/3);
		rotateCar (car3, angle + 2*2*Mathf.PI/3);
		*/
	}

	void hideInformation(bool set){
		panel.enabled = set;
		carName.enabled = set;
		info.enabled = set;
	}

	void setInformation(int idx){
		carName.text = carNames [idx];
		info.text = infos [idx];
	}

	void rotateCar(GameObject car, float angle) {
		car.transform.position = new Vector3 ((circumcentre.x + Mathf.Sin (angle) * radius),
												circumcentre.y,
												(circumcentre.z + Mathf.Cos (angle) * radius));
	}
}
