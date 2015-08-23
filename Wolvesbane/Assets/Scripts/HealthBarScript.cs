using UnityEngine;
using System.Collections;

public class HealthBarScript : MonoBehaviour {

	public GameObject creatureObject;
	private int maxWidth;

	// Use this for initialization
	void Start () {
		this.creatureObject = GameObject.FindGameObjectWithTag ("Player");
		this.maxWidth = (int) this.GetComponent<RectTransform>().sizeDelta.x;
	}
	
	// Update is called once per frame
	void Update () {
		// Compute fractional health
		if (creatureObject != null) {
			double fractionalHealth = creatureObject.GetComponent<CreatureBase> ().health / creatureObject.GetComponent<CreatureBase> ().maxHealth;
			Vector2 size = this.GetComponent<RectTransform> ().sizeDelta;
			size.x = (int)(this.maxWidth * fractionalHealth);
			this.GetComponent<RectTransform> ().sizeDelta = size;
		} else {
			GameObject.Destroy(this.gameObject);
		}
	}
}
