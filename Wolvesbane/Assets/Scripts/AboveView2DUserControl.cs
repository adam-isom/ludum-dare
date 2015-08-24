using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

//namespace UnityStandardAssets._2D
//{
[RequireComponent(typeof (UnityStandardAssets._2D.PlatformerCharacter2D))]
public class AboveView2DUserControl : CreatureBase
{
	private Animator anim;

	private UnityStandardAssets._2D.PlatformerCharacter2D m_Character;
    private bool m_Jump;
	private bool attacking;
	private int attackingTimer;
	public bool crossbowEquipped;
	public GameObject boltCase;
	private bool suckingBlood;
	private int suckingBloodTimer;
	public int suckingBloodCooldown;
	public int stunTime;
	public float moveSpeed;
	public int coinsOwned;
	public int numKills;

    private void Awake()
    {
		anim = GetComponent<Animator> ();
		m_Character = GetComponent<UnityStandardAssets._2D.PlatformerCharacter2D>();
		attackingTimer = 0;
		suckingBlood = false;
    }


    private void Update()
    {
		// Read the inputs.
		float move_x = CrossPlatformInputManager.GetAxis("Horizontal");
		float move_y = CrossPlatformInputManager.GetAxis("Vertical");
		
		//Animation logic
		if (Mathf.Abs(move_x) > Mathf.Abs(move_y)) {
			anim.SetBool ("Walking", true);
			if (move_x > 0) {
				anim.SetFloat("MoveX", 1f);
				anim.SetFloat("LastMoveX", 1f);
			} else {
				anim.SetFloat("MoveX", -1f);
				anim.SetFloat("LastMoveX", -1f);
			}
			anim.SetFloat("MoveY", 0f);
			anim.SetFloat("LastMoveY", 0f);
		} else if (move_y != 0) {
			anim.SetBool ("Walking", true);
			if (move_y > 0) {
				anim.SetFloat("MoveY", 1f);
				anim.SetFloat("LastMoveY", 1f);
			} else {
				anim.SetFloat("MoveY", -1f);
				anim.SetFloat("LastMoveY", -1f);
			}
			anim.SetFloat("MoveX", 0f);
			anim.SetFloat("LastMoveX", 0f);
		} else {
			anim.SetFloat("MoveX", anim.GetFloat("LastMoveX"));
			anim.SetFloat("MoveY", anim.GetFloat("LastMoveY"));
			anim.SetBool ("Walking", false);
		}

        if (!m_Jump)
        {
            // Read the jump input in Update so button presses aren't missed.
            m_Jump = CrossPlatformInputManager.GetButtonDown("Jump");
        }
		if (hitTimer > 0) {
			--hitTimer;
		}
		if (suckingBloodTimer > 0) {
			--suckingBloodTimer;
		}
		if (regenTimer > 0) {
			--regenTimer;
		} else {
			regenTimer = regenCooldown;
			if (currentPower == Power.WEREWOLF && health < maxHealth) {
				++health;
			}
		}

		// Pass all parameters to the character control script.
		m_Character.Move(move_x*moveSpeed,move_y*moveSpeed);
		m_Jump = false;
		
		Vector3 cameraPosition = Camera.main.transform.position;
		cameraPosition.x = this.transform.position.x;
		cameraPosition.y = this.transform.position.y;
		Camera.main.transform.position = cameraPosition;
		if (CrossPlatformInputManager.GetButtonDown("Fire1")) {
			if (crossbowEquipped) {
				Debug.Log ("Firing crossbow");
				fireCrossbow();
			} else {
				Debug.Log ("Swinging sword");
				swingSword();
			}
		} else if (attackingTimer > 0) {
			attackingTimer--;
		} else {
			attacking = false;
		}
		
		// Blood sucking key enables trigger collider
		if (CrossPlatformInputManager.GetButton ("Fire2") && currentPower == Power.NONE) {
			this.suckingBlood = true;
		} else {
			this.suckingBlood = false;
		}
		GameObject.FindGameObjectWithTag("LogManager").GetComponent<LogManagerScript>().playerCoins = coinsOwned;
		GameObject.FindGameObjectWithTag("LogManager").GetComponent<LogManagerScript>().playerKills = numKills;
    }

	private void fireCrossbow() {
		if (hitTimer == 0) {
			if (this.GetComponent<Animator> () != null) {
				this.GetComponent<Animator> ().SetTrigger ("fireCrossbow");
			}
			attacking = false;
			// Create projectile
			if (boltCase != null) {
				BoltCaseScript boltCaseScript = boltCase.GetComponent<BoltCaseScript> ();
				GameObject bolt = boltCaseScript.getBolt ();

				if (bolt != null) {
					// Make projectile fire at mouse position
					Vector3 mousepos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
					Vector2 mousedir = (new Vector2 (mousepos.x, mousepos.y) - new Vector2 (transform.position.x, transform.position.y)).normalized;

					GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundScript>().playSound("crossbowfire");

					// Make sure projectile starts outside of player's collider
					Vector2 offset = new Vector2 ();
					offset.x = (float)0.2 * mousedir.x;
					offset.y = (float)0.2 * mousedir.y;
					bolt.transform.Translate (offset);
					Rigidbody2D boltRigidBody = bolt.GetComponent<Rigidbody2D> ();
					boltRigidBody.AddForce (600 * mousedir);
					//Debug.Log ("firing crossbow");

					hitTimer = hitCooldown;
				}
			}
		}
	}

	private void swingSword() {
		if (this.GetComponent<Animator>() != null) {
			this.GetComponent<Animator>().SetTrigger("attack");
		}
		attacking = true;
		attackingTimer = 10;
		Debug.Log("attacking");
	}
		
	public override void OnCollisionStay2D(Collision2D collision) {
		if (attacking) {
			CreatureBase otherScript = (CreatureBase)collision.gameObject.GetComponent("CreatureBase");
			if (otherScript != null) {
				if (otherScript.team != team && hitTimer == 0) {
					if (collision.gameObject.GetComponent<Animator>() != null) {
						collision.gameObject.GetComponent<Animator>().SetTrigger("hurt");
					}
					//this.gameObject.GetComponent<Animator>().SetTrigger("attack");
					hitTimer = hitCooldown;
					Debug.Log("Damaging other entity: " + damage + " w/ AD: " + armorDivisor);
					if (otherScript.TakeDamage(damage, armorDivisor)) {
						Destroy(collision.gameObject);
						target = null;
						GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundScript>().playSound("crit");
						string player_name = GameObject.FindGameObjectWithTag("NameManager").GetComponent<NameManager>().getName("Player");
						numKills++;
						GameObject.FindGameObjectWithTag("LogManager").GetComponent<LogManagerScript>().addMessage(player_name + " slew " + collision.gameObject.name);
					} else {
						GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundScript>().playSound("hit");
					}
				}
			}
		}
	}

	public void OnTriggerStay2D(Collider2D collider) {
		if (suckingBlood && suckingBloodTimer == 0) {
			MonsterAI monster = collider.gameObject.GetComponent<MonsterAI>();
			if (monster != null && monster.team != team && collider.isTrigger == false) {
				if (collider.gameObject.GetComponent<Animator>() != null) {
					collider.gameObject.GetComponent<Animator>().SetTrigger("hurt");
				}
				monster.stun(stunTime);
				currentPower = monster.currentPower;
				suckingBloodTimer = suckingBloodCooldown;
				Debug.Log("Damaging other entity: " + damage + " w/ AD: " + armorDivisor);
				GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundScript>().playSound("bloodsuck");
				if (monster.TakeDamage(damage, armorDivisor)) {
					string player_name = GameObject.FindGameObjectWithTag("NameManager").GetComponent<NameManager>().getName("Player");
					numKills++;
					GameObject.FindGameObjectWithTag("LogManager").GetComponent<LogManagerScript>().addMessage(player_name + " slew " + collider.gameObject.name);
					Destroy(collider.gameObject);
					target = null;
				}
			}
		}
	}
}
//}
