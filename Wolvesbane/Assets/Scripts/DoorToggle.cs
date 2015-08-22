using UnityEngine;
using System.Collections;

public class DoorToggle : CreatureBase {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}
	
	public override bool TakeDamage(int amount, float armorDivisor) {
		this.gameObject.GetComponent<BoxCollider2D>().enabled = !this.gameObject.GetComponent<BoxCollider2D>().enabled;
		this.gameObject.GetComponent<SpriteRenderer>().enabled = !this.gameObject.GetComponent<SpriteRenderer>().enabled;
		Debug.Log("HELLO");
		return false;
	}
}
