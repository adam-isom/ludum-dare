﻿using UnityEngine;
using System.Collections;

public class AdvanceLevel : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void OnTriggerEnter2D (Collider2D other) {
		if (other.tag == "Player") {
			print("Exit point");
			Application.LoadLevel(Application.loadedLevel+1); // advance one level
		}
	}
}
