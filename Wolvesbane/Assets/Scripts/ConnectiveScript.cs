using UnityEngine;
using System.Collections;

public class ConnectiveScript : MonoBehaviour {

	public GameObject connectedRoomA;
	public GameObject connectedRoomB;
	public bool open;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void toggle(GameObject currentRoom) {
		if (this.connectedRoomA != null && this.connectedRoomB != null) {
			if (this.open) {
				this.open = false;
				this.GetComponent<BoxCollider2D>().isTrigger = false;
				this.GetComponent<SpriteRenderer>().color = Color.magenta;
			} else {
				this.open = true;
				this.GetComponent<BoxCollider2D>().isTrigger = true;
				this.GetComponent<SpriteRenderer>().color = Color.black;
			}

			if (connectedRoomA != currentRoom) {
				connectedRoomA.GetComponent<RoomScript> ().setVisibility (this.open);
			} else {
				connectedRoomB.GetComponent<RoomScript> ().setVisibility (this.open);
			}
		}
	}

	void OnCollisionStay2D(Collision2D collision) {
		Debug.Log ("Collision");
		PlayerScript player = (PlayerScript)collision.gameObject.GetComponent("PlayerScript");
		if (player != null) {
			if (player.actionKey && player.hitTimer == 0) {
				//collision.gameObject.GetComponent<Animator>().SetTrigger("hurt");
				//this.GetComponent<Animator>().SetTrigger("attack");

				player.hitTimer = player.hitCooldown;
				toggle(player.currentRoom);
			}
		}
	}

	void OnTriggerEnter(Collider other) {
		Debug.Log ("Entered collider");
		PlayerScript player = (PlayerScript)other.gameObject.GetComponent("PlayerScript");
		if (player != null) {
			if (player.actionKey && player.hitTimer == 0) {
				//collision.gameObject.GetComponent<Animator>().SetTrigger("hurt");
				//this.GetComponent<Animator>().SetTrigger("attack");
				
				player.hitTimer = player.hitCooldown;
				toggle(player.currentRoom);
			}
		}
	}
}
