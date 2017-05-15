using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour {

	public float speed = 10f;
	public float rotationSpeed = 10f;
	public GameObject TopLeftW, TopRightW, BackLeftW, BackRightW;

	private Rigidbody rb;

	void Start() {
		rb = GetComponent<Rigidbody> ();
	}

    // Update is called once per frame
    void Update()
    {
        float translation = Input.GetAxis("Vertical") * speed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
        //translation *= Time.deltaTime;
        //rotation *= Time.deltaTime;
		rb.AddForce(-transform.forward * translation);
        transform.Rotate(0, rotation, 0);
        
    }
}
