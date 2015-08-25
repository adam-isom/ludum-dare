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
		level = Application.loadedLevel + 1;
		print ("LEVEL " + level);

		DontDestroyOnLoad(GameObject.Find("UICanvas"));
		DontDestroyOnLoad(GameObject.Find("MusicManager"));

		InitGame();
	}
	
	//Initializes the game for each level.
	void InitGame() {
		//While doingSetup is true the player can't move, prevent player from moving while title card is up.
		doingSetup = true;
		print ("DOING SETUP");

		levelImage = GameObject.Find ("LevelImage").GetComponent<Image>();
		levelText = GameObject.Find ("LevelText").GetComponent<Text> ();

		if (level%2 == 0) {

			levelText.text = "Level " + level + "\n\n"
				+ "Home again. Better pick up some supplies before tonight."
				+ "\n\n Press space to continue";
		}

		else if (level == 1) {
			
			levelText.text = "Level " + level + "\n\n"
				+ "After last night's adventures, you feel some sort of transformation happening to you…"
					+ "\n\n…You feel your humanity slipping away, but in its place new abilities have emerged. You thirst for blood!"
				+ "\n\n Press space to continue";
		} else if (level == 3) {
			
			levelText.text = "Level " + level + "\n\n"
				+ "Your contact implied tonight would be a tougher job."
					+ "\n\n Press space to continue";
		} else if (level == 5) {
			
			levelText.text = "Level " + level + "\n\n"
				+ "Fear seeps into your bones..."
					+ "\n\n Press space to continue";
		}
		else levelText.text = "Level " + level + "\n Press space to continue";
		
		levelText.enabled = true;
		levelImage.enabled = true;
		Time.timeScale = 0.0F;
	}


	// Use this for initialization
	void Start () {
		print("Start() function called.");
	}
	
	// Update is called once per frame
	void Update () {

	}
		/*//Hides black image used between levels
		if (Input.GetKeyDown ("space") && doingSetup == true) {
			print ("space key was pressed");

			levelImage.enabled = false;
			levelText.enabled = false;			
			doingSetup = false;
		}
	}*/

	void OnGUI() {
		
		//Hides black image used between levels
		if (Input.GetKeyDown ("space") && doingSetup == true) {
			print ("space key was pressed");
			
			levelImage.enabled = false;
			levelText.enabled = false;			
			doingSetup = false;
			Time.timeScale = 1.0F;
		}
	}

	//This is called each time a scene is loaded.
	void OnLevelWasLoaded(int level) {
		print ("New level loaded.");
	}
}
