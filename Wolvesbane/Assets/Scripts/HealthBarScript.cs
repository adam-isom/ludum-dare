using UnityEngine;
using System.Collections;

public class HealthBarScript : MonoBehaviour {

	public GameObject creatureObject;
	private int maxWidth;

	// Use this for initialization
	void Start () {
		this.creatureObject = GameObject.FindGameObjectWithTag ("Player");
		this.maxWidth = (int)Camera.main.ViewportToScreenPoint(new Vector3(0.95f,1,0)).x;
			//(int) this.GetComponent<RectTransform>().sizeDelta.x;
		//Vector3 pos = Camera.main.WorldToViewportPoint(this.transform.position);
		//pos.x = Mathf.Clamp(pos.x,0f,1f);
		//pos.y = Mathf.Clamp(pos.y,0f,1f);
		//transform.position = Camera.main.ViewportToWorldPoint(pos);
	}
	
	// Update is called once per frame
	void Update () {
		// Compute fractional health
		if (creatureObject != null) {
			//double fractionalHealth = creatureObject.GetComponent<CreatureBase> ().health / creatureObject.GetComponent<CreatureBase> ().maxHealth;
			Vector2 size = this.GetComponent<RectTransform> ().sizeDelta;
			int heart_width = 34;
			size.x = (int)Mathf.Min(this.maxWidth, heart_width*(int)creatureObject.GetComponent<CreatureBase> ().health);
			size.y = 14;
			this.GetComponent<RectTransform> ().sizeDelta = size;
		} else {
			GameObject.Destroy(this.gameObject);
		}
	}
}