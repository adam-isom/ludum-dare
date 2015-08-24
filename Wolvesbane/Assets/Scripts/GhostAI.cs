using UnityEngine;
using System.Collections;

public class GhostAI : MonsterAI {
	void OnTriggerStay2D(Collider2D collision) {
		if (!collision.isTrigger) {
			CollideWithGameObject(collision.gameObject);
		}
	}
}
