using UnityEngine;
using System.Collections;

public class RoomScript : MonoBehaviour {

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

			TileScript[] tileScripts = (TileScript[])this.gameObject.GetComponentsInChildren<TileScript> ();
			foreach (TileScript tileScript in tileScripts) {
				tileScript.setVisibility (visible);
			}
		}
	}
}
