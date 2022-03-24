using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * Created: Session 1
 * Last Edited: Session 19
 * Purpose: To control the start menu by defining which menus are visible/invisible at different times
 * and what happens when different buttons are clicked by the user.
 */

public class StartMenuNavigation : MonoBehaviour {

	private Canvas mainCanvas;
	private Canvas levelCanvas;
	private Canvas difficultyCanvas;
	//Defines the canvas elements to be used.

	// Use this for initialization
	void Start () {
		
		mainCanvas = GameObject.FindGameObjectWithTag("MainMenu").GetComponent<Canvas>();
		mainCanvas.enabled = true;
		
		levelCanvas = GameObject.FindGameObjectWithTag("LevelSelectMenu").GetComponent<Canvas>();
		levelCanvas.enabled = false;

		difficultyCanvas = GameObject.FindGameObjectWithTag("DifficultyMenu").GetComponent<Canvas>();
		difficultyCanvas.enabled = false;

		PlayerPrefs.SetInt ("TutorialLevel", 0);
		PlayerPrefs.SetInt ("Level1", 0);
		PlayerPrefs.SetInt ("Level2", 0);
		PlayerPrefs.SetInt ("Level3", 0);
		PlayerPrefs.SetString ("Difficulty", "Normal");
	}
	/*Finds the canvases used for the menus when the game is started/run and enables/disables them to make
	certain menus visible/invisible to the user. Then sets player pref values used for level selection.*/


	public void ClickedEasyButton(){
		PlayerPrefs.SetString ("Difficulty", "Easy");
		mainCanvas.enabled = true;
		levelCanvas.enabled = false;
		difficultyCanvas.enabled = false;
		Debug.Log ("Clicked easy button");
	}
	/*Changes the difficulty to easy and takes the player back to the main menu.*/

	public void ClickedNormalButton(){
		PlayerPrefs.SetString ("Difficulty", "Normal");
		mainCanvas.enabled = true;
		levelCanvas.enabled = false;
		difficultyCanvas.enabled = false;
		Debug.Log ("Clicked normal button");
	}
	/*Changes the difficulty to normal and takes the player back to the main menu.*/

	public void ClickedHardButton(){
		PlayerPrefs.SetString ("Difficulty", "Hard");
		mainCanvas.enabled = true;
		levelCanvas.enabled = false;
		difficultyCanvas.enabled = false;
		Debug.Log ("Clicked hard button");
	}
	/*Changes the difficulty to hard and takes the player back to the main menu.*/

	public void ClickedDifficultyButton(){
		mainCanvas.enabled = false; 
		levelCanvas.enabled = false;
		difficultyCanvas.enabled = true;
		Debug.Log ("Clicked difficulty button");
	}
	/*Outputs "Clicked difficulty button" when the difficulty button is clicked and
	switches from the Main Menu to the Difficulty Menu.*/

	public void ClickedLevelSelectButton(){
		mainCanvas.enabled = false; 
		levelCanvas.enabled = true; 
		difficultyCanvas.enabled = false;
		Debug.Log ("Clicked level select button");
	}
	/*Outputs "Clicked level select button" when the level select button is clicked and
	switches from the Main Menu to the Level Select Menu.*/

	public void TutorialLevelButton(){
		SceneManager.LoadScene (3);
		PlayerPrefs.SetInt ("TutorialLevel", 1);
		PlayerPrefs.SetInt ("Level1", 0);
		PlayerPrefs.SetInt ("Level2", 0);
		PlayerPrefs.SetInt ("Level3", 0);
		PlayerPrefs.SetInt ("SilverKeys", 4);
		PlayerPrefs.SetInt ("GoldKeys", 4);
		PlayerPrefs.SetInt ("PlayerScore", 0);
	} 
	/* When the tutorial level button is clicked, the tutorial level is loaded and the
	 * appropriate player pref values are set which are significant for the basic features 
	 * of the game, such as the player's score. */

	public void Level1Button(){
		SceneManager.LoadScene (4);
		PlayerPrefs.SetInt ("TutorialLevel", 0);
		PlayerPrefs.SetInt ("Level1", 1);
		PlayerPrefs.SetInt ("Level2", 0);
		PlayerPrefs.SetInt ("Level3", 0);
		PlayerPrefs.SetInt ("SilverKeys", 3);
		PlayerPrefs.SetInt ("GoldKeys", 3);
		PlayerPrefs.SetInt ("PlayerScore", 0);
	}
	/* When the level 1 button is clicked, level 1 is loaded and the appropriate
	 * player pref values are set which are significant for the basic features 
	 * of the game, such as the player's score. */

	public void Level2Button(){
		SceneManager.LoadScene (5);
		PlayerPrefs.SetInt ("TutorialLevel", 0);
		PlayerPrefs.SetInt ("Level1", 0);
		PlayerPrefs.SetInt ("Level2", 1);
		PlayerPrefs.SetInt ("Level3", 0);
		PlayerPrefs.SetInt ("SilverKeys", 2);
		PlayerPrefs.SetInt ("GoldKeys", 2);
		PlayerPrefs.SetInt ("PlayerScore", 0);
	}
	/* When the level 2 button is clicked, level 2 is loaded and the appropriate
	 * player pref values are set which are significant for the basic features 
	 * of the game, such as the player's score. */

	public void Level3Button(){
		SceneManager.LoadScene (6);
		PlayerPrefs.SetInt ("TutorialLevel", 0);
		PlayerPrefs.SetInt ("Level1", 0);
		PlayerPrefs.SetInt ("Level2", 0);
		PlayerPrefs.SetInt ("Level3", 1);
		PlayerPrefs.SetInt ("SilverKeys", 1);
		PlayerPrefs.SetInt ("GoldKeys", 1);
		PlayerPrefs.SetInt ("PlayerScore", 0);
	}
	/* When the level 3 button is clicked, level 3 is loaded and the appropriate
	 * player pref values are set which are significant for the basic features 
	 * of the game, such as the player's score. */
		
	public void ClickedStartButton(){
		SceneManager.LoadScene (2);
		Debug.Log ("Clicked start button");
	}
	/* When the start button is clicked, the tutorial screen is loaded and the message, 
	 * 'Clicked start button' is outputted to the debug log. */

	public void ClickedBackLevelButton(){
		mainCanvas.enabled = true;
		levelCanvas.enabled = false;
		difficultyCanvas.enabled = false;
		Debug.Log ("Clicked back button");
	}
	/*Outputs "Clicked back button" when the back button is clicked and
	switches from the Level Select Menu to the Main Menu.*/

	public void ClickedBackDifficultyButton(){
		mainCanvas.enabled = true;
		levelCanvas.enabled = false;
		difficultyCanvas.enabled = false;
		Debug.Log ("Clicked back button");
	}
	/*Outputs "Clicked back button" when the back button is clicked and
	switches from the Difficulty Menu to the Main Menu.*/


	// Update is called once per frame
	void Update () {
		
	}
}
