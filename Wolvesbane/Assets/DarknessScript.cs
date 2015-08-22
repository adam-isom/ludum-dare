using UnityEngine;
using System.Collections;

public class DarknessScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionStay2D(Collision2D collision) {
		Debug.Log("DARKNESS");
		Destroy(this.transform.parent.gameObject);
	}
}
