using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets._2D
{
    [RequireComponent(typeof (PlatformerCharacter2D))]
    public class AboveView2DUserControl : CreatureBase
    {
		private Animator anim;

        private PlatformerCharacter2D m_Character;
        private bool m_Jump;
		private bool attacking;
		private int attackingTimer;

        private void Awake()
        {
			anim = GetComponent<Animator> ();
			m_Character = GetComponent<PlatformerCharacter2D>();
			attackingTimer = 0;
        }


        private void Update()
        {
			// Read the inputs.
			float move_x = CrossPlatformInputManager.GetAxis("Horizontal");
			float move_y = CrossPlatformInputManager.GetAxis("Vertical");

			// Interpreting movement for animation controller
			if (move_x > 0) {
				anim.SetFloat("MoveX", 1f);
			} else if (move_x < 0) {
				anim.SetFloat("MoveX", -1f);
			} else {
				anim.SetFloat("MoveX", 0);
			}

			if (move_y > 0) {
				anim.SetFloat("MoveY", 1f);
			} else if (move_y < 0) {
				anim.SetFloat("MoveY", -1f);
			} else {
				anim.SetFloat("MoveY", 0);
			}

            if (!m_Jump)
            {
                // Read the jump input in Update so button presses aren't missed.
                m_Jump = CrossPlatformInputManager.GetButtonDown("Jump");
            }
			if (hitTimer > 0) {
				hitTimer--;
			}
        }


        private void FixedUpdate()
        {
            // Read the inputs.
            float move_x = CrossPlatformInputManager.GetAxis("Horizontal");
			float move_y = CrossPlatformInputManager.GetAxis("Vertical");

			// Interpreting movement for animation controller
			if (move_x != 0 || move_y != 0) {
				anim.SetBool ("Walking", true);
			} else {
				anim.SetBool ("Walking", false);
			}

			// Interpreting movement for animation controller
			if (move_x > 0) {
				anim.SetFloat("LastMoveX", 1f);
			} else if (move_x < 0) {
				anim.SetFloat("LastMoveX", -1f);
			} else {
				anim.SetFloat("LastMoveX", 0);
			}
			
			if (move_y > 0) {
				anim.SetFloat("LastMoveY", 1f);
			} else if (move_y < 0) {
				anim.SetFloat("LastMoveY", -1f);
			} else {
				anim.SetFloat("LastMoveY", 0);
			}

            // Pass all parameters to the character control script.
            m_Character.Move(move_x,move_y);
            m_Jump = false;

			Vector3 cameraPosition = Camera.main.transform.position;
			cameraPosition.x = this.transform.position.x;
			cameraPosition.y = this.transform.position.y;
			Camera.main.transform.position = cameraPosition;
			if (CrossPlatformInputManager.GetButtonDown("Fire1")) {
				if (this.GetComponent<Animator>() != null) {
					this.GetComponent<Animator>().SetTrigger("attack");
				}
				attacking = true;
				attackingTimer = 10;
				Debug.Log("attacking");
			} else if (attackingTimer > 0) {
				attackingTimer--;
			} else {
				attacking = false;
			}
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
						}
					}
				}
			}
		}
    }
}
