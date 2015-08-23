using UnityEngine;
using System.Collections;

public class LucreScript : MonoBehaviour {
	public int amount;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D collision) {
		AboveView2DUserControl playerScript = collision.gameObject.GetComponent<AboveView2DUserControl>();
		if (playerScript != null) {
			playerScript.coinsOwned += amount;
			Debug.Log("Picked up some coins! We now have " + playerScript.coinsOwned);
			Destroy(this.gameObject);
		}
	}
}
