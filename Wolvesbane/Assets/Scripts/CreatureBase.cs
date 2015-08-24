using UnityEngine;
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
				int rand_num = random.Next(toDrop.Length);
				//Debug.Log("rand_num: " + rand_num + " Len:" + toDrop.Length);
				GameObject.Instantiate(toDrop[rand_num], gameObject.transform.position, Quaternion.identity);
			}
			return true;
		} else {
			if (GetComponent<Animator>() != null) {
				GetComponent<Animator>().SetTrigger ("Damaged");
			}
		}
		return false;
	}

	public void stun(int stunTime) {
		hitTimer = stunTime;
		stunTimer = stunTime;
	}

	public virtual void CollideWithGameObject(GameObject collided) {
		CreatureBase otherScript = collided.GetComponent<CreatureBase>();
		if (otherScript != null) {
			if (otherScript.team != team && hitTimer == 0) {
				//if (collided.GetComponent<Animator>() != null) {
					//collided.GetComponent<Animator>().SetTrigger("hurt");
				//}
				if (this.GetComponent<Animator>() != null) {
					this.GetComponent<Animator>().SetTrigger("Attacking");
				}
				GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundScript>().playSound("hit");
				//this.gameObject.GetComponent<Animator>().SetTrigger("attack");
				hitTimer = hitCooldown;
				//Debug.Log("Damaging other entity: " + damage + " w/ AD: " + armorDivisor);
				if (otherScript.TakeDamage(damage, armorDivisor)) {
					Destroy(collided);
					Debug.Log("Slew " + collided.name);
					string creature_name = GameObject.FindGameObjectWithTag("NameManager").GetComponent<NameManager>().getName(name);
					string target_name = GameObject.FindGameObjectWithTag("NameManager").GetComponent<NameManager>().getName(collided.name);
					GameObject.FindGameObjectWithTag("LogManager").GetComponent<LogManagerScript>().addMessage(creature_name + " slew " + target_name);
					target = null;
					GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundScript>().playSound("crit");
				}
			}
		}
	}
	public virtual void OnCollisionStay2D(Collision2D collision) {
		CollideWithGameObject(collision.gameObject);
	}
}

