using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectCars : MonoBehaviour {

	public float rotationSpeed = 10f;
	public GameObject[] cars;//, car2, car3;

	private Vector3 circumcentre;
	private float radius;
	private float angle;
	private float timer;
	private float subAngle;
	private bool left, right;
	private float idx;


	void Start () {
		circumcentre = new Vector3 (0.0f,2.0f,-23.09f);
		radius = 23.09f;
		angle = 0.0f;
		timer = 0.0f;
		left = false;
		right = false;
		idx = 0.0f;
	}
	

	void Update()
	{
		if (Input.GetKeyDown ("right") && !right && !left) {
			right = true;
			subAngle = 0.0f;
			timer = idx * 2 * Mathf.PI / 3;
			idx += 1;
			if (idx == 3)
				idx = 0;
		} else if (Input.GetKeyDown ("left") && !right && !left){
			left = true;
			subAngle = 0.0f;
			timer = idx * 2 * Mathf.PI / 3;
			idx -= 1;
			if (idx == -1)
				idx = 2;
		}
		if (right) {
			if (subAngle <= 2 * Mathf.PI / 3) {
				subAngle += 2*Time.deltaTime;
				timer += 2*Time.deltaTime;
			} else {
				right = false;
				subAngle = 0.0f;
			}
		}
		else if (left){
			if (subAngle <= 2 * Mathf.PI / 3) {
				subAngle += 2*Time.deltaTime;
				timer -= 2*Time.deltaTime;

			} else {
				left = false;
				subAngle = 0.0f;
			}
		}

		angle = timer;
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

	void rotateCar(GameObject car, float angle) {
		car.transform.position = new Vector3 ((circumcentre.x + Mathf.Sin (angle) * radius),
												circumcentre.y,
												(circumcentre.z + Mathf.Cos (angle) * radius));
	}
}
