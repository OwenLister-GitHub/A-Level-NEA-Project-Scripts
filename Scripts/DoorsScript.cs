using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * Created: Session 13
 * Last Edited: Session 15
 * Purpose: To control the doors in each level. When the player has collected all of the
 * keys in a level and the player collides with the doors, they will move onto the next
 * level.
 */

public class DoorsScript : MonoBehaviour {

	private int silver;
	private int gold;
	//Defines attributes used to allow the player to move onto the next level.

	// Use this for initialization
	void Start () {

		silver = PlayerPrefs.GetInt ("SilverKeys");
		gold = PlayerPrefs.GetInt ("GoldKeys");
	}

	void OnCollisionEnter2D (Collision2D col){

		if (silver == 3 && gold == 3) {
			SceneManager.LoadScene (4);
			Debug.Log ("Player moves onto next level!");
		} else if (silver == 2 && gold == 2) {
			SceneManager.LoadScene (5);
			Debug.Log ("Player moves onto next level!");
		} else if (silver == 1 && gold == 1) {
			SceneManager.LoadScene (6);
			Debug.Log ("Player moves onto next level!");
		} else if (silver == 0 && gold == 0) {
			SceneManager.LoadScene (7);
			Debug.Log ("PLAYER HAS WON THE GAME!");
		}
	}
	/* If the player collides with the doors of the current level and they have collected
	 * both (all) of the keys in the level, then the next level will be loaded or the win 
	 * screen will be loaded if the player has won the game. */

	public void silverKeyLock (int number1){
		silver = silver - number1;
		Debug.Log ("-1 silver key");
	}
	/* Changes the 'silver' variable so the doors of the current level will allow the player
	 * to move onto the next level. */

	public void goldKeyLock (int number2){
		gold = gold - number2;
		Debug.Log ("-1 gold key");
	}
	/* Changes the 'gold' variable so the doors of the current level will allow the player
	 * to move onto the next level. */


	// Update is called once per frame
	void Update () {

		PlayerPrefs.SetInt ("SilverKeys", silver);
		PlayerPrefs.SetInt ("GoldKeys", gold);
	}
}
