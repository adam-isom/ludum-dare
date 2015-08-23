using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	private int level;
	private bool doingSetup = true;
	private Text levelText;									//Text to display current level number.
	private GameObject levelImage;							//Image to block out level as levels are being set up, background for levelText.

	//Awake is always called before any Start functions
	void Awake() {
		DontDestroyOnLoad(gameObject);

		//Call the InitGame function to initialize the level 
		InitGame();
	}


	//Initializes the game for each level.
	void InitGame() {
		//While doingSetup is true the player can't move, prevent player from moving while title card is up.
		doingSetup = true;

		//Get a reference to our image LevelImage by finding it by name.
		levelImage = GameObject.Find("LevelImage");
		//Get a reference to our text LevelText's text component by finding it by name and calling GetComponent.
		levelText = GameObject.Find("LevelText").GetComponent<Text>();

		//Set the text of levelText to the current level number.
		level = Application.loadedLevel;
		levelText.text = "Level " + level + "\n Press space to continue";
		
		//Set levelImage to active blocking player's view of the game board during setup.
		levelImage.SetActive(true);
	}


	// Use this for initialization
	void Start () {
		print("Start() function called.");
		//Application.LoadLevel("main");
	}
	
	// Update is called once per frame
	void Update () {

		//Hides black image used between levels
		if (Input.GetKeyDown ("space") && doingSetup == true) {
			print ("space key was pressed");

			levelImage.SetActive(false);
			levelText.enabled = false;			
			doingSetup = false;
		}
	}

	//This is called each time a scene is loaded.
	void OnLevelWasLoaded(int level) {
		print ("New level loaded.");
	}
}
