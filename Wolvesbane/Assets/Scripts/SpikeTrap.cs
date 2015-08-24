using UnityEngine;
using System.Collections;

public class SpikeTrap : MonoBehaviour {

	private Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D collision) {
		if (collision.isTrigger) {
			return;
		}
		anim.SetBool("TrapTrigger", true);
		CreatureBase otherscript = collision.gameObject.GetComponent<CreatureBase>();
		if (otherscript != null) {
			if (otherscript.TakeDamage(2,5)) {
				string target_name = GameObject.FindGameObjectWithTag("NameManager").GetComponent<NameManager>().getName(collision.gameObject.name);
				GameObject.FindGameObjectWithTag("LogManager").GetComponent<LogManagerScript>().addMessage(target_name + " was impaled");
				Destroy(collision.gameObject);
			}
			GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundScript>().playSound("crit2");
		}
		return;
	}

	void OnTriggerExit2D(Collider2D collision) {
		if (collision.isTrigger) {
			return;
		}
		anim.SetBool("TrapTrigger", false);
		return;
	}
}
