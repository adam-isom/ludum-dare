using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public static GameManager instance = null;				//Static instance of GameManager which allows it to be accessed by any other script.

	private int level;
	private bool doingSetup = true;
	private Text levelText;									//Text to display current level number.
	private Image levelImage;							//Image to block out level as levels are being set up, background for levelText.

	//Awake is always called before any Start functions
	void Awake() {
		print ("LEVEL " + Application.loadedLevel);
		DontDestroyOnLoad(GameObject.Find("UI Canvas"));
		InitGame();
	}
	
	//Initializes the game for each level.
	void InitGame() {
		//While doingSetup is true the player can't move, prevent player from moving while title card is up.
		doingSetup = true;
		print ("DOING SETUP");
		
		levelImage = GameObject.Find ("LevelImage").GetComponent<Image>();
		levelText = GameObject.Find ("LevelText").GetComponent<Text> ();

		//Set the text of levelText to the current level number.
		level = Application.loadedLevel;
		levelText.text = "Level " + level + "\n Press space to continue";
		
		levelText.enabled = true;
		levelImage.enabled = true;
	}


	// Use this for initialization
	void Start () {
		print("Start() function called.");
	}
	
	// Update is called once per frame
	void Update () {

		//Hides black image used between levels
		if (Input.GetKeyDown ("space") && doingSetup == true) {
			print ("space key was pressed");

			levelImage.enabled = false;
			levelText.enabled = false;			
			doingSetup = false;
		}
	}

	//This is called each time a scene is loaded.
	void OnLevelWasLoaded(int level) {
		print ("New level loaded.");
	}
}
