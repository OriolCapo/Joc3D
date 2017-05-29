using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecieveHit : MonoBehaviour {

    private Rigidbody rb;
    public AudioSource audio_hit;
    private float resistance;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        resistance = GetComponent<CarCharacteristics>().resistanceFactor;
        resistance = (float)(resistance / 8.0);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void GetsHit(Vector3 velocitat)
    {
        if (resistance > 0)
        {
            velocitat = velocitat / resistance;
        }        
        rb.AddForce(velocitat.x, velocitat.magnitude/3, velocitat.z, ForceMode.Impulse);
        audio_hit.Play();
    }
}
