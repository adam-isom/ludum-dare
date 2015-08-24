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

	public bool TakeDamage(int amount, float armorDivisor) {
		this.gameObject.GetComponent<BoxCollider2D>().enabled = !this.gameObject.GetComponent<BoxCollider2D>().enabled;
		this.gameObject.GetComponent<SpriteRenderer>().enabled = !this.gameObject.GetComponent<SpriteRenderer>().enabled;
		anim.SetTrigger ("TrapTrigger");
		return false;
	}
	
	public void OnCollisionStay2D(Collision2D collision) {
		anim.SetTrigger ("TrapTrigger");
		return;
	}
}
