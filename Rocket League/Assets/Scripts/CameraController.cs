using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject mustang;
	public GameObject softCar;
	public GameObject monsterTruck;

	private GameObject selectedCar;
	private Vector3 offset1;//, offset2;

    void Start()
    {
        offset1 = new Vector3(0, 5, -10);
		//offset2 = new Vector3(0, 0, -40);
		selectedCar = mustang;
    }

    void Update()
    {
		transform.position = selectedCar.transform.position + offset1;
		//transform.LookAt(transform.position + transform.forward*15);
		//transform.forward = player.transform.forward + (player.transform.position - transform.position);// + offset2;
		//transform.rotation = player.transform.rotation;

		if (Input.GetKeyDown ("1")) {
			selectedCar = mustang;
		} else if (Input.GetKeyDown ("2")) {
			selectedCar = softCar;
		} else if (Input.GetKeyDown ("3")) {
			selectedCar = monsterTruck;
		}
    }
}
