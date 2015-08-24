using UnityEngine;
using System.Collections;

public class PlaySongs : MonoBehaviour {

	public AudioClip[] songs;
	int currentSong = 0;
	bool playedSong0 = false;
	bool playedSong1 = false;
	
	void Update (){
		if (GetComponent<AudioSource>().isPlaying == false) {
			if (currentSong >= songs.Length)
				currentSong = 0;

			GetComponent<AudioSource>().clip = songs[currentSong];
			GetComponent<AudioSource>().Play();
			currentSong++;
		}

	}
}
