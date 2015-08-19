using UnityEngine;
using System.Collections;

public class AntBuilder : CreatureBase
{
	[SerializeField] private GameObject ant;
	private float timer;
	private static float ANT_SPAWN_TIME = 8; // seconds
	private GameObject antParent;
	
	void Start() 
	{
		timer = ANT_SPAWN_TIME;
		antParent = GameObject.FindGameObjectWithTag("antParent");
		Debug.Log("Created antBuilder with antParent=" + antParent);
	}
	
	void Update() 
	{    
		timer -= Time.deltaTime;
		if (timer <= 0) {
			GameObject newAnt = (GameObject) Instantiate(ant, this.transform.position, Quaternion.identity);
			newAnt.transform.parent = antParent.transform;
			timer = ANT_SPAWN_TIME;
		}
	}
}