using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * Created: Session 1
 * Last Edited: Session 18
 * Purpose: To control the pause menu by defining when it is visible and what happens when 
 * buttons are clicked on by the player.
 */

public class PauseMenuNavigation : MonoBehaviour {

	private Canvas pauseMenu;
	private Canvas levelSelectPauseMenu;
	//Defines the canvases so that they can be referenced.

	// Use this for initialization
	void Start () {
		pauseMenu = GameObject.FindGameObjectWithTag ("PauseMenu").GetComponent<Canvas> ();
		pauseMenu.enabled = false;
		levelSelectPauseMenu = GameObject.FindGameObjectWithTag ("LevelSelectPauseMenu").GetComponent<Canvas> ();
		levelSelectPauseMenu.enabled = false;
	}
	/*This finds the canvases when the game is run and makes them visible/invisible to the user*/


	public void ClickedLevelSelectPauseButton (){
		pauseMenu.enabled = false;
		levelSelectPauseMenu.enabled = true;
		Debug.Log ("Clicked the level select button");
	}
	/*This switches the pause menu to the level select button for the user*/

	public void ClickedReturnToMainMenuButton (){
		SceneManager.LoadScene (0);
		Debug.Log ("Clicked return to main menu button");
	}
	//This loads the start/main menu when the return to main menu button is clicked.

	public void ClickedBackLevelButton (){
		pauseMenu.enabled = true;
		levelSelectPauseMenu.enabled = false;
		Debug.Log ("Clicked the back button");
	}
	//This switches the level select menu to the pause menu for the user when they click the back button.

	public void ClickedResumeButton (){
		pauseMenu.enabled = false;
		levelSelectPauseMenu.enabled = false;
		Debug.Log ("Clicked the resume button");
	}
	/* This makes the pause menu invisible when the player clicks the resume button so that they
	 * can continue playing the game.*/

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
		if (Input.GetKey (KeyCode.Escape)) {
			pauseMenu.enabled = true;
			levelSelectPauseMenu.enabled = false;
		}
		//Opens the pause menu if the player presses the escape button.
	}
}
