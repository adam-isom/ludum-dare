using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets._2D
{
    [RequireComponent(typeof (PlatformerCharacter2D))]
    public class AboveView2DUserControl : CreatureBase
    {
        private PlatformerCharacter2D m_Character;
        private bool m_Jump;


        private void Awake()
        {
            m_Character = GetComponent<PlatformerCharacter2D>();
        }


        private void Update()
        {
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
            // Pass all parameters to the character control script.
            m_Character.Move(move_x,move_y);
            m_Jump = false;

			Vector3 cameraPosition = Camera.main.transform.position;
			cameraPosition.x = this.transform.position.x;
			cameraPosition.y = this.transform.position.y;
			Camera.main.transform.position = cameraPosition;
        }
    }
}
