using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

/*
 * Created: Session 2
 * Last Edited: Session 20
 * Purpose: To control the death screen by defining what happens when buttons are clicked by the player
 * and what information is displayed to the player.
 */

public class DeathScreen : MonoBehaviour {

	private Canvas deathScreen;
	private Canvas levelSelectMenu;
	//Defines attributes used to navigate the death screen.

	public TextMeshPro timerText;
	private float finishTime;
	//Defines attributes used to store & display the player's time.

	public TextMeshPro scoreText;
	private int score;
	//Defines attributes used to store & display the player's score.

	public AudioClip gameOverSound;
	//Attribute to act as the game over sound effect.
	private AudioSource source;
	//Attribute used to play sound effects.

	// Use this for initialization
	void Start () {

		finishTime = PlayerPrefs.GetFloat ("Time");
		timerText.text = "Time: " + finishTime.ToString ();
		/* Stores the player's time when the script is run and displays it on the death screen. */

		score = PlayerPrefs.GetInt ("PlayerScore");
		scoreText.text = "Score: " + score.ToString ();
		/* Stores the player's score when the script is run and displays it on the death screen. */

		deathScreen = GameObject.FindGameObjectWithTag ("DeathScreen").GetComponent<Canvas> (); 
		deathScreen.enabled = true; 
		levelSelectMenu = GameObject.FindGameObjectWithTag ("LevelSelectDeathScreen").GetComponent<Canvas> (); 
		levelSelectMenu.enabled = false; 
		/* Finds the canvases and makes them visible/invisible to the user so the menus can 
		 * be switched between.*/

		source = gameObject.GetComponent<AudioSource> ();
		/* Finds the 'AudioSource' component attached to the game object this 
		 * script is attached to so sound effects can be played. */

		source.PlayOneShot (gameOverSound, 1);
		/* Plays the game over sound effect once when the death screen is first loaded. */
	}

	public void ClickedReturnToMainMenuButton (){
		SceneManager.LoadScene (0);
		Debug.Log ("Clicked return to main menu button");
	}
	//This loads the start/main menu when the return to main menu button is clicked.

	public void ClickedLevelSelectButton (){
		deathScreen.enabled = false;
		levelSelectMenu.enabled = true;
		Debug.Log ("Clicked level select menu");
	}
	//Switches from the death screen to the level select menu.

	public void ClickedBackLevelButton (){
		deathScreen.enabled = true;
		levelSelectMenu.enabled = false;
		Debug.Log ("Clicked back button");
	}
	//Switches from the level select menu to death screen menu when the back button is clicked.

	public void TutorialLevelButton(){
		SceneManager.LoadScene (3);
		PlayerPrefs.SetInt ("TutorialLevel", 1);
		PlayerPrefs.SetInt ("Level1", 0);
		PlayerPrefs.SetInt ("Level2", 0);
		PlayerPrefs.SetInt ("Level3", 0);
		PlayerPrefs.SetInt ("SilverKeys", 4);
		PlayerPrefs.SetInt ("GoldKeys", 4);
	} 
	/* When the tutorial level button is clicked, the tutorial level is loaded and the
	 * appropriate player pref values are set. */

	public void Level1Button(){
		SceneManager.LoadScene (4);
		PlayerPrefs.SetInt ("TutorialLevel", 0);
		PlayerPrefs.SetInt ("Level1", 1);
		PlayerPrefs.SetInt ("Level2", 0);
		PlayerPrefs.SetInt ("Level3", 0);
		PlayerPrefs.SetInt ("SilverKeys", 3);
		PlayerPrefs.SetInt ("GoldKeys", 3);
	}
	/* When the level 1 button is clicked, level 1 is loaded and the appropriate
	 * player pref values are set. */

	public void Level2Button(){
		SceneManager.LoadScene (5);
		PlayerPrefs.SetInt ("TutorialLevel", 0);
		PlayerPrefs.SetInt ("Level1", 0);
		PlayerPrefs.SetInt ("Level2", 1);
		PlayerPrefs.SetInt ("Level3", 0);
		PlayerPrefs.SetInt ("SilverKeys", 2);
		PlayerPrefs.SetInt ("GoldKeys", 2);
	}
	/* When the level 2 button is clicked, level 2 is loaded and the appropriate
	 * player pref values are set. */

	public void Level3Button(){
		SceneManager.LoadScene (6);
		PlayerPrefs.SetInt ("TutorialLevel", 0);
		PlayerPrefs.SetInt ("Level1", 0);
		PlayerPrefs.SetInt ("Level2", 0);
		PlayerPrefs.SetInt ("Level3", 1);
		PlayerPrefs.SetInt ("SilverKeys", 1);
		PlayerPrefs.SetInt ("GoldKeys", 1);
	}
	/* When the level 3 button is clicked, level 3 is loaded and the appropriate
	 * player pref values are set. */

	// Update is called once per frame
	void Update () {
		
	}
}
