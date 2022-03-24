using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

/*
 * Created: Session 2
 * Last Edited: Session 20
 * Purpose: To control the win screen by defining what information it displays to the player and 
 * what happens when different buttons are clicked by the player.
 */

public class WinScreen : MonoBehaviour {

	private Canvas winMenu;
	private Canvas levelSelectWin;
	//Defines attributes used to navigate the win screen.

	public TextMeshPro timerText;
	private float finishTime;
	//Defines attributes used to store & display the player's time.

	public TextMeshPro scoreText;
	private int score;
	//Defines attributes used to store & display the player's score.

	public AudioClip winGameSound;
	//Attribute to act as the win sound effect.
	private AudioSource source;
	//Attribute used to play sound effects.

	// Use this for initialization
	void Start () {

		finishTime = PlayerPrefs.GetFloat ("Time");
		timerText.text = "Time: " + finishTime.ToString ();
		/* Stores the player's time when the script is run and displays it on the win screen. */

		score = PlayerPrefs.GetInt ("PlayerScore");
		scoreText.text = "Score: " + score.ToString ();
		/* Stores the player's score when the script is run and displays it on the win screen. */

		winMenu = GameObject.FindGameObjectWithTag ("WinScreen").GetComponent<Canvas> ();
		winMenu.enabled = true;
		levelSelectWin = GameObject.FindGameObjectWithTag ("LevelSelectWinScreen").GetComponent<Canvas> ();
		levelSelectWin.enabled = false;
		/* Finds the canvases and makes them visible/invisible to the user so the menus can 
		 * be switched between.*/

		source = gameObject.GetComponent<AudioSource> ();
		/* Finds the 'AudioSource' component attached to the game object this 
		 * script is attached to so sound effects can be played. */

		source.PlayOneShot (winGameSound, 1);
		/* Plays the win sound effect once when the death screen is first loaded. */
	}

	public void ClickedBackButton () {
		winMenu.enabled = true;
		levelSelectWin.enabled = false;
		Debug.Log ("Clicked the back button");
	}
	//Switches from the level select menu to the win screen.

	public void ClickedLevelSelectButton () {
		winMenu.enabled = false;
		levelSelectWin.enabled = true;
		Debug.Log ("Clicked the level select button");
	}
	//Switches from the win screen to the level select menu.

	public void ClickedReturnToMainMenu () {
		SceneManager.LoadScene (0);
		Debug.Log ("Clicked the return to main menu button");
	}
	//Switches from the win screen to the main menu.
	
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
