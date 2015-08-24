using UnityEngine;
using System.Collections;

public class SoundScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void playSound(string name) {
		AudioSource[] sounds = GetComponents<AudioSource>();
		foreach (AudioSource sound in sounds) {
			if (sound.clip.name == name) {
				sound.Play();
				break;
			}
		}
	}
}
