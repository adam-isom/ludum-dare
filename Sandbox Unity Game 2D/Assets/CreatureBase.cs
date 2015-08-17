using UnityEngine;
using System.Collections;

public class CreatureBase : MonoBehaviour {

	public float health;
	public float maxHealth;
	public int armor;
	public float armorDivisor;
	public int damage;
	public bool isDead;
	public string team;
	public int hitTimer;
	public int hitCooldown;
	[SerializeField] public GameObject target;

	// Update is called once per frame
	void Update () {

	}

	//returns whether it died
	bool TakeDamage(int amount, float armorDivisor) {
		health -= amount / Mathf.Max((armor/armorDivisor), 1);
		if (health < 0) {
			health = 0;
			isDead = true;
			return true;
		}
		return false;
	}

	void OnCollisionStay2D(Collision2D collision) {
		CreatureBase otherScript = (CreatureBase)collision.gameObject.GetComponent("CreatureBase");
		if (otherScript != null) {
			if (otherScript.team != team && hitTimer == 0) {
				collision.gameObject.GetComponent<Animator>().SetTrigger("hurt");
				this.GetComponent<Animator>().SetTrigger("attack");
				//this.gameObject.GetComponent<Animator>().SetTrigger("attack");
				hitTimer = hitCooldown;
				//Debug.Log("Damaging other entity: " + damage + " w/ AD: " + armorDivisor);
				if (otherScript.TakeDamage(damage, armorDivisor)) {
					Destroy(collision.gameObject);
					target = null;
				}
			}
		}
	}
}

