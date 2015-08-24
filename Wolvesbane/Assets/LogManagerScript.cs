using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LogManagerScript : MonoBehaviour {
	public GameObject oldText;
	public GameObject medText;
	public GameObject newText;

	//Storing some shit here
	public int playerCoins;
	public int playerKills;

	// Use this for initialization
	void Start () {
//		oldText.GetComponent<RectTransform>().anchoredPosition = new Vector2(100,100);
//		oldText.GetComponent<RectTransform>().SetParent(transform);
//		oldText.GetComponent<RectTransform>().localScale = Vector3.one;
//		oldText.GetComponent<RectTransform>().sizeDelta = new Vector2(100,50);
//		oldText.GetComponent<RectTransform>().anchoredPosition = new Vector2(0,0);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void addMessage(string message) {
		oldText.GetComponent<Text>().text = medText.GetComponent<Text>().text;
		medText.GetComponent<Text>().text = newText.GetComponent<Text>().text;
		newText.GetComponent<Text>().text = message;
	}
}
