using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DeathTextScript : MonoBehaviour {
	public GameObject waitingForDeath;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (waitingForDeath == null) {
			waitingForDeath = GameObject.FindGameObjectWithTag("Player");
			if (waitingForDeath != null) {
				return;
			}
			GetComponent<Text>().text = "You succumb to your wounds. \nYou amassed " + 
				LogManagerScript.playerCoins +
					" coins before your grim demise.\nCreatures slain: " + 
					LogManagerScript.playerKills;
		}
	}
}
