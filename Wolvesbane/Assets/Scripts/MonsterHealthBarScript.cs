using UnityEngine;
using System.Collections;

public class MonsterHealthBarScript : MonoBehaviour {

	public GameObject creatureObject;
	private float maxWidth;

	// Use this for initialization
	void Start () {
		this.creatureObject = this.GetComponentInParent<MonsterAI>().gameObject;
		this.maxWidth = this.transform.localScale.x;
	}
	
	// Update is called once per frame
	void Update () {
		// Compute fractional health
		if (creatureObject != null) {
			double fractionalHealth = creatureObject.GetComponent<CreatureBase> ().health / creatureObject.GetComponent<CreatureBase> ().maxHealth;
			Vector3 scale = this.transform.localScale;
			scale.x = (float) (this.maxWidth * fractionalHealth);
			this.transform.localScale = scale;
		} else {
			GameObject.Destroy(this.gameObject);
		}
	}
}
