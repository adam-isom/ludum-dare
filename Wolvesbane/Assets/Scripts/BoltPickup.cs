using UnityEngine;
using System.Collections;

public class BoltPickup : MonoBehaviour {
	public int numBolts;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter2D(Collider2D collision) {
		AboveView2DUserControl playerScript = collision.gameObject.GetComponent<AboveView2DUserControl>();
		if (playerScript != null) {
			if (playerScript.boltCase != null) {
				playerScript.boltCase.GetComponent<BoltCaseScript>().ammo += numBolts;
				Debug.Log("Picked up ammo! Now have " + playerScript.boltCase.GetComponent<BoltCaseScript>().ammo);
				GameObject.FindGameObjectWithTag("LogManager").GetComponent<LogManagerScript>().addMessage(
					"We now have " + playerScript.boltCase.GetComponent<BoltCaseScript>().ammo + " bolts");
				Destroy(gameObject);
			}
		}
	}
}
