using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//OnTriggerEnter2D is sent when another object enters a trigger collider attached to this object (2D physics only).
	// Note: currently using the AdvanceLevel script instead of this function to do scene transitions.
	private void OnTriggerEnter2D (Collider2D other) { 
		//Check if the tag of the trigger collided with is Exit.
		if (other.tag == "Exit") {
			print ("Exit point");
		}
	}
}
