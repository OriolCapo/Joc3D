using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explote : MonoBehaviour {

	private GameObject expl;
	private ParticleSystem ps;

	public float power = 100000.0f;
	private float radius = 3000.0f;
	private float upForce = 1.0f;

	void Start () {
		expl = GameObject.Find ("Explosion");
		ps = expl.GetComponent<ParticleSystem> ();
		ps.Stop ();
	}

	public void playIt(){
		ps.transform.position = transform.position;
		ps.Play ();
		detonate ();
		gameObject.SetActive (false);
		Invoke ("stopIt", 3);
	}

	void detonate(){
		Vector3 explosionPos = expl.transform.position;
		Collider[] colliders = Physics.OverlapSphere (explosionPos, radius);
		foreach (Collider hit in colliders) {
			Rigidbody rigidB = hit.GetComponent<Rigidbody> ();
			if (rigidB != null) {
				rigidB.AddExplosionForce (power, explosionPos, radius, upForce, ForceMode.Impulse);
			}
		}
	}

	public void stopIt(){
		ps.Stop ();
		//go = !go;
	}
}
