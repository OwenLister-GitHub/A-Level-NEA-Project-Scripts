using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * Created: Session 13
 * Last Edited: Session 15
 * Purpose: To control navigation on the tutorial screen (there is only one button
 * though), and to control what happens when the 'Play' button is clicked.
 */

public class TutorialScreenNavigation : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}


	public void ClickPlayButton () {
		SceneManager.LoadScene (3);
		Debug.Log ("Clicked the 'Play' button");
		PlayerPrefs.SetInt ("PlayerScore", 0);
		PlayerPrefs.SetFloat ("Time", 0);
		PlayerPrefs.SetInt ("SilverKeys", 4);
		PlayerPrefs.SetInt ("GoldKeys", 4);
		PlayerPrefs.SetInt ("TutorialLevel", 1);
		PlayerPrefs.SetInt ("Level1", 0);
		PlayerPrefs.SetInt ("Level2", 0);
		PlayerPrefs.SetInt ("Level3", 0);
	}
	/* When the player clicks on the 'Play' button, this method will be run
	 * which switches from the tutorial screen to the tutorial level, and 
	 * creates & sets multiple player pref values so that they can be used 
	 * throughout the game for essential features such as the player's score
	 * and the timer. */

	
	// Update is called once per frame
	void Update () {
		
	}
}
