using UnityEngine;
using System.Collections;

public class BoltCaseScript : MonoBehaviour {

	public GameObject boltType;
	public int ammo;
	private GameObject player;

	// Use this for initialization
	void Start () {
		this.player = GameObject.FindGameObjectWithTag ("Player");
		if (this.player != null) {
			Debug.Log ("found player");
		} else {
			Debug.Log ("DID NOT FIND PLAYER!");
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public GameObject getBolt() {

		GameObject bolt = null;
		if (ammo > 0) {
			--ammo;
			bolt = (GameObject) GameObject.Instantiate(boltType, player.transform.position, Quaternion.identity);
			BoltScript bolt_script = bolt.GetComponent<BoltScript>();
			bolt_script.damage = 2;
			bolt_script.armorDivisor = 5;
			bolt_script.team = "Player";
		}

		return bolt;
	}
}
