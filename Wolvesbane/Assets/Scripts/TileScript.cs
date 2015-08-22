using UnityEngine;
using System.Collections;

public class TileScript : MonoBehaviour {

	public bool visible;

	// Use this for initialization
	void Start () {
		this.visible = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void setVisibility(bool visible) {
		if (visible != this.visible) {
			this.visible = visible;

			this.gameObject.GetComponent<SpriteRenderer> ().enabled = this.visible;
		}
	}
}
