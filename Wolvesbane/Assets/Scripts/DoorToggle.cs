using UnityEngine;
using System.Collections;

public class DoorToggle : CreatureBase {

	public GameObject[] adjacentObjects;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}
	
	public override bool TakeDamage(int amount, float armorDivisor) {
		this.gameObject.GetComponent<BoxCollider2D>().enabled = !this.gameObject.GetComponent<BoxCollider2D>().enabled;
		this.gameObject.GetComponent<SpriteRenderer>().enabled = !this.gameObject.GetComponent<SpriteRenderer>().enabled;
		if (adjacentObjects.Length > 0) {
			foreach (GameObject to_activate in adjacentObjects) {
				if (to_activate != null) {
					to_activate.SetActive(true);
				}
			}
		}
		GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundScript>().playSound("knock");
		return false;
	}

	public override void OnCollisionStay2D(Collision2D collision) {
		return;
	}
}
