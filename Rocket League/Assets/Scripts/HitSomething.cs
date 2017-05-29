using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitSomething : MonoBehaviour {

    private Rigidbody rb;
    private RecieveHit recieveHit;
    private float strength;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        strength = GetComponent<CarCharacteristics>().strenghtFactor;
        strength = (float)(strength / 8.0);
    }

    // Update is called once per frame
    void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball")){
            recieveHit = collision.gameObject.GetComponent<RecieveHit>();
            recieveHit.GetsHit((float)1.2*strength*rb.velocity);
        }else if (collision.gameObject.CompareTag("Car")){
            recieveHit = collision.gameObject.GetComponent<RecieveHit>();
            recieveHit.GetsHit((float)300.0 *strength * rb.velocity);
        }
    }
}
