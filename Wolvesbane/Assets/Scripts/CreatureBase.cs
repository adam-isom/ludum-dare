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
}

