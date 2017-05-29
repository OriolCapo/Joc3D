using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitSomething : MonoBehaviour {

    private Rigidbody rb;
    private RecieveHit recieveHit;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball")){
            recieveHit = collision.gameObject.GetComponent<RecieveHit>();
            recieveHit.GetsHit((float)1.2*rb.velocity);
        }else if (collision.gameObject.CompareTag("Car")){
            recieveHit = collision.gameObject.GetComponent<RecieveHit>();
            recieveHit.GetsHit((float)100 * rb.velocity);
        }
    }
}
