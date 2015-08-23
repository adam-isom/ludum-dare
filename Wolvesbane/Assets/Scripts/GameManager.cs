using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		print("Start() function called.");
		//Application.LoadLevel("main");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("space") && Application.loadedLevel != 1) { // Application.loadedLevel is the current scene number
			print ("space key was pressed");
			Application.LoadLevel("main");
		}
	}

	//This is called each time a scene is loaded.
	void OnLevelWasLoaded(int level) {
		print ("New level loaded.");
	}
}
