using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecieveHit : MonoBehaviour {

    private Rigidbody rb;
    public AudioSource audio_hit;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void GetsHit(Vector3 velocitat)
    {        
        rb.AddForce(velocitat.x, velocitat.magnitude/3, velocitat.z, ForceMode.Impulse);
        audio_hit.Play();
    }
}
