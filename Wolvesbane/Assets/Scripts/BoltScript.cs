using UnityEngine;
using System.Collections;

public class BoltScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Rigidbody2D rigidbody = this.GetComponent<Rigidbody2D> ();
		if (rigidbody.velocity.magnitude <= 2) {
			Destroy(this.gameObject);
		}
	}

	// collide
}
