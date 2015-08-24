using UnityEngine;
using System.Collections;

public class BoltScript : MonoBehaviour {
	public string team;
	public float armorDivisor;
	public int damage;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Rigidbody2D rigidbody = this.GetComponent<Rigidbody2D> ();
		if (rigidbody.velocity.magnitude <= 7) {
			Destroy(this.gameObject);
		}
		//transform.rotation = Quaternion.LookRotation(rigidbody.velocity.normalized);
		//Debug.Log("Rotation: " + transform.rotation);
		float angle = Mathf.Atan2(rigidbody.velocity.y, rigidbody.velocity.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
	}

	void OnCollisionEnter2D(Collision2D collision) {
		CreatureBase otherScript = (CreatureBase)collision.gameObject.GetComponent("CreatureBase");
		if (otherScript != null) {
			if (otherScript.team != team) {
				Debug.Log("Team: " + team);
				if (collision.gameObject.GetComponent<Animator>() != null) {
					collision.gameObject.GetComponent<Animator>().SetTrigger("hurt");
				}
				//this.gameObject.GetComponent<Animator>().SetTrigger("attack");
				//Debug.Log("Damaging other entity: " + damage + " w/ AD: " + armorDivisor);
				if (otherScript.TakeDamage(damage, armorDivisor)) {
					Destroy(collision.gameObject);
					Debug.Log("Slew " + collision.gameObject.name);
					Destroy(this.gameObject);
					GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundScript>().playSound("crit");
					string player_name = GameObject.FindGameObjectWithTag("NameManager").GetComponent<NameManager>().getName("Player");
					GameObject.FindGameObjectWithTag("Player").GetComponent<AboveView2DUserControl>().numKills++;
					GameObject.FindGameObjectWithTag("LogManager").GetComponent<LogManagerScript>().addMessage(player_name + " slew " + collision.gameObject.name);
				} else {
					GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundScript>().playSound("hit");
				}
			}
		}
	}
}
