using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

[RequireComponent(typeof (UnityStandardAssets._2D.PlatformerCharacter2D))]
public class PlayerScript : CreatureBase {

	public GameObject currentRoom;
	public bool actionKey;
	private UnityStandardAssets._2D.PlatformerCharacter2D m_Character;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (hitTimer > 0) {
			hitTimer--;
		}
		Vector3 pos = Camera.main.WorldToViewportPoint(this.transform.position);
		pos.x = Mathf.Clamp(pos.x,0f,1f);
		pos.y = Mathf.Clamp(pos.y,0f,1f);
		transform.position = Camera.main.ViewportToWorldPoint(pos);
	}

	private void Awake()
	{
		m_Character = GetComponent<UnityStandardAssets._2D.PlatformerCharacter2D>();
	}
	
	private void FixedUpdate()
	{
		// Read the inputs.
		float move_x = CrossPlatformInputManager.GetAxis("Horizontal");
		float move_y = CrossPlatformInputManager.GetAxis("Vertical");

		// Pass all parameters to the character control script.
		m_Character.Move(move_x,move_y);

		// set whether the player is pressing the action key
		this.actionKey = CrossPlatformInputManager.GetButtonDown ("Jump");
	}
}
