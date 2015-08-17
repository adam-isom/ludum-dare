using UnityEngine;
using System.Collections;

public class EntrancePlacer : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Vector3 temp_point = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width,Screen.height/2,0));
		this.transform.position = new Vector3(temp_point.x,temp_point.y,0);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
