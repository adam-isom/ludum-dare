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
		print ("LEVEL " + Application.loadedLevel);

		DontDestroyOnLoad(GameObject.Find("UI Canvas"));
		DontDestroyOnLoad(GameObject.Find("SoundManager"));

		InitGame();
	}
	
	//Initializes the game for each level.
	void InitGame() {
		//While doingSetup is true the player can't move, prevent player from moving while title card is up.
		doingSetup = true;
		print ("DOING SETUP");
		
		levelImage = GameObject.Find ("LevelImage").GetComponent<Image>();
		levelText = GameObject.Find ("LevelText").GetComponent<Text> ();

		if (level == 1) {

			levelText.text = "Level " + level + "\n\n"
				+ "Monsters have overrun the world, and the last remaining human government employs you to collect their bounties. You are sure of only one thing: that you could never become one of them…"
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
