using UnityEngine;
using System.Collections;

public class SpikeTrap : MonoBehaviour {

	private Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D collision) {
		anim.SetBool("TrapTrigger", true);
		return;
	}

	void OnTriggerExit2D(Collider2D collision) {
		anim.SetBool("TrapTrigger", false);
		return;
	}
}
