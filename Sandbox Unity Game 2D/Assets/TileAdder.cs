using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class TileAdder : MonoBehaviour {

	[SerializeField] private GameObject tile_to_place;

	// Use this for initialization
	void Start () {
		//tile_to_place = GetComponent<GameObject>();
	}
	
	// Update is called once per frame
	void Update () {
		if (CrossPlatformInputManager.GetButtonUp("Submit")) {
			//GameObject new_tile = new GameObject("dynamic tile");
			Vector3 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			mousepos.z = 1;
			Instantiate(tile_to_place, mousepos, Quaternion.identity);
			Debug.Log("Position: " + Input.mousePosition);
			//new_tile = tile_to_place;
			//Vector3 mouse_pos = Input.mousePosition;
			//new_tile.transform.position = new Vector3(6,6,6);
			//new_tile.transform.position.x = mouse_pos.x;
			//Debug.Log("Mouse X: " + new_tile.transform.position.x);
		}
	}
}
