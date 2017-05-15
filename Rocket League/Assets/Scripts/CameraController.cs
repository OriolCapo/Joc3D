using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject player;

	private Vector3 offset1;//, offset2;

    void Start()
    {
        offset1 = new Vector3(0, 5, -10);
		//offset2 = new Vector3(0, 0, -40);
    }

    void Update()
    {
        transform.position = player.transform.position + offset1;
		//transform.LookAt(transform.position + transform.forward*15);
		//transform.forward = player.transform.forward + (player.transform.position - transform.position);// + offset2;
		//transform.rotation = player.transform.rotation;
    }
}
