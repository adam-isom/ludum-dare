﻿using UnityEngine;
using System.Collections;

public class CreatureBase : MonoBehaviour {

	public enum Power {
		NONE, WEREWOLF, VAMPIRE
	};

	public float health;
	public float maxHealth;
	public int armor;
	public float armorDivisor;
	public int damage;
	public bool isDead;
	public string team;
	public int hitTimer;
	public int hitCooldown;
	public int stunTimer;
	[SerializeField] public GameObject target;
	public GameObject[] toDrop;
	public Power currentPower;
	public int regenTimer;
	public int regenCooldown;

	// Update is called once per frame
	void Update () {

	}

	//returns whether it died
	public virtual bool TakeDamage(int amount, float armorDivisor) {
		health -= amount / Mathf.Max((armor/armorDivisor), 1);
		if (health <= 0) {
			health = 0;
			isDead = true;
			if (toDrop.Length > 0) {
				System.Random random = new System.Random();
				int rand_num = random.Next(0, toDrop.Length+1);
				GameObject.Instantiate(toDrop[rand_num], gameObject.transform.position, Quaternion.identity);
			}
			return true;
		}
		return false;
	}

	public void stun(int stunTime) {
		hitTimer = stunTime;
		stunTimer = stunTime;
	}

	public virtual void OnCollisionStay2D(Collision2D collision) {
		CreatureBase otherScript = (CreatureBase)collision.gameObject.GetComponent("CreatureBase");
		if (otherScript != null) {
			if (otherScript.team != team && hitTimer == 0) {
				if (collision.gameObject.GetComponent<Animator>() != null) {
					collision.gameObject.GetComponent<Animator>().SetTrigger("hurt");
				}
				if (this.GetComponent<Animator>() != null) {
					this.GetComponent<Animator>().SetTrigger("attack");
				}
				//this.gameObject.GetComponent<Animator>().SetTrigger("attack");
				hitTimer = hitCooldown;
				//Debug.Log("Damaging other entity: " + damage + " w/ AD: " + armorDivisor);
				if (otherScript.TakeDamage(damage, armorDivisor)) {
					Destroy(collision.gameObject);
					Debug.Log("Slew " + collision.gameObject.name);
					target = null;
				}
			}
		}
	}
}

