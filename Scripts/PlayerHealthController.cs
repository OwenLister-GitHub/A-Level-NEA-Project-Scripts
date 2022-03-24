using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealthController : MonoBehaviour {

 /*
 * Created: Session 9
 * Last Edited: Session 19
 * Purpose: To display the player's health to the player and control what happens to 
 * the player's health in certain events, such as losing health when they are attacked 
 * by an enemy.
 */

	private GameObject heartFull1;
	private GameObject heartFull2;
	private GameObject heartFull3;
	private GameObject heartHalf1;
	private GameObject heartHalf2;
	private GameObject heartHalf3;
	//Defines the game objects used for displaying the player's health to the user.

	private int PlayerHealth = 6;

	private bool invincible = false;

	private bool invisibleHealth = false;


	// Use this for initialization
	void Start () {

		heartFull1 = GameObject.FindGameObjectWithTag("FullHeart1");
		heartFull1.SetActive (false);

		heartFull2 = GameObject.FindGameObjectWithTag("FullHeart2");
		heartFull2.SetActive (false);

		heartFull3 = GameObject.FindGameObjectWithTag("FullHeart3");
		heartFull3.SetActive (false);

		heartHalf1 = GameObject.FindGameObjectWithTag ("HalfHeart1");
		heartHalf1.SetActive (false);

		heartHalf2 = GameObject.FindGameObjectWithTag ("HalfHeart2");
		heartHalf2.SetActive (false);

		heartHalf3 = GameObject.FindGameObjectWithTag ("HalfHeart3");
		heartHalf3.SetActive (false);
		//Identifies the game objects used for displaying the player's health to the user and makes them visible/invisible to the user when the game is run.

		if (PlayerPrefs.GetString ("Difficulty") == "Hard") {
			PlayerHealth = 4;
		}
		/* If the difficulty selected is 'Hard', the player starts each level with four hearts of 
		 * health instead of six. */
	}
		

	public void ToxicOn(bool dmg){
		InvokeRepeating ("ToxicDamage", 0.1f, 2f);
		Invoke ("ToxicOff", 6f);
	}
	/* Starts the toxic effect period and after 6 seconds (so there is enough time for the player to be 
	 * damaged 3 times by the effect), the toxic effect is stopped. */

	public void ToxicDamage(){
		PlayerHealth -= 1;
		Debug.Log("Toxic damage!");
	} //Deals damage to the player as part of the toxic effect de-buff.

	public void ToxicOff(){
		CancelInvoke ("ToxicDamage");
		Debug.Log ("Toxic stopped!");
	}//Stops the toxic effect by stopping the 'ToxicDamage' method being invoked.

	/* The above 3 methods control the toxic effect de-buff by starting and stopping damage being dealt
	 * to the player every few seconds. */


	public void InvisibleHealthOn(bool health){
		invisibleHealth = true;
		Debug.Log ("Player's health is invisible for 5 seconds!");
		Invoke ("InvisibleHealthOff", 5f);
	}//Controls when the player's health is visible/invisible.

	public void InvisibleHealthOff(){
		invisibleHealth = false;
		Debug.Log ("Player's health is no longer invisible!");
	}//Stops the player's health being visible/invisible.


	public void PlayerTakesOneDamage (int Damage){
		PlayerHealth = PlayerHealth - Damage;
		Debug.Log ("Enemy/trap dealt 1 damage to player!");
	}
	//This method is used to take one point of health away from the player when an enemy/trap attacks them.


	public void PlayerTakesTwoDamage (int Damage){
		PlayerHealth = PlayerHealth - Damage;
		Debug.Log ("Enemy dealt 2 damage to player!");
	}
	//This method is used to take two points of health away from the player when an enemy attacks them.


	public void PlayerTakesThreeDamage (int Damage){
		PlayerHealth = PlayerHealth - Damage;
		Debug.Log ("Enemy dealt 3 damage to player!");
	}
	//This method is used to take three points of health away from the player when an enemy attacks them.


	public void PlayerGainsHealth (int Health){
		PlayerHealth = PlayerHealth + Health;
		Debug.Log ("Player has gained health!");
	}
	//This method adds points to the players health. Called upon by the large red potion item/collectible.

	public void InvincibilityOn (bool start){
		invincible = true;
		Debug.Log ("Player is invincible for 5 seconds!");
		Invoke ("InvincibilityOff", 5f);
	}
	//Starts the period of invincibility for the player which lasts 5 seconds.

	public void InvincibilityOff (){
		invincible = false;
		Debug.Log ("Player is no longer invincible!");
	}
	//Stops the period of invincibility for the player.


	// Update is called once per frame
	void Update () {

		if (PlayerPrefs.GetString ("Difficulty") == "Hard") {
			if (PlayerHealth > 4) {
				PlayerHealth = 4;
			}
		}
		//Makes the player's maximum health 4 if the difficulty is 'Hard'.

		if (PlayerHealth > 6) {
			PlayerHealth = 6;
		} else if (invincible == true) {
			PlayerHealth = 6;
		}
		/* Ensures that the player's health never exceeds 6 and enables
		 * the player to be invincible. */

		if (invisibleHealth == false) {
			if (PlayerHealth == 6) {
			
				heartFull1.SetActive (true);
				heartFull2.SetActive (true);
				heartFull3.SetActive (true);
				heartHalf1.SetActive (false);
				heartHalf2.SetActive (false);
				heartHalf3.SetActive (false);

			} else if (PlayerHealth == 5) {
				
				heartFull1.SetActive (true);
				heartFull2.SetActive (true);
				heartFull3.SetActive (false);
				heartHalf1.SetActive (false);
				heartHalf2.SetActive (false);
				heartHalf3.SetActive (true);

			} else if (PlayerHealth == 4) {
			
				heartFull1.SetActive (true);
				heartFull2.SetActive (true);
				heartFull3.SetActive (false);
				heartHalf1.SetActive (false);
				heartHalf2.SetActive (false);
				heartHalf3.SetActive (false);

			} else if (PlayerHealth == 3) {
			
				heartFull1.SetActive (true);
				heartFull2.SetActive (false);
				heartFull3.SetActive (false);
				heartHalf1.SetActive (false);
				heartHalf2.SetActive (true);
				heartHalf3.SetActive (false);

			} else if (PlayerHealth == 2) {

				heartFull1.SetActive (true);
				heartFull2.SetActive (false);
				heartFull3.SetActive (false);
				heartHalf1.SetActive (false);
				heartHalf2.SetActive (false);
				heartHalf3.SetActive (false);

			} else if (PlayerHealth == 1) {

				heartFull1.SetActive (false);
				heartFull2.SetActive (false);
				heartFull3.SetActive (false);
				heartHalf1.SetActive (true);
				heartHalf2.SetActive (false);
				heartHalf3.SetActive (false);

			} else if (PlayerHealth <= 0) {

				heartFull1.SetActive (false);
				heartFull2.SetActive (false);
				heartFull3.SetActive (false);
				heartHalf1.SetActive (false);
				heartHalf2.SetActive (false);
				heartHalf3.SetActive (false);
				SceneManager.LoadScene (1);
				//Loads the death screen when the player has no health left.
			}
			//Displays different combinations hearts to the user when the player has different amounts of health.
		} else if (invisibleHealth == true) {
			heartFull1.SetActive (false);
			heartFull2.SetActive (false);
			heartFull3.SetActive (false);
			heartHalf1.SetActive (false);
			heartHalf2.SetActive (false);
			heartHalf3.SetActive (false);

			if(PlayerHealth <= 0){
				SceneManager.LoadScene (1);
				//Loads the death screen when the player has no health left.
			}
		}/* Makes the player's health invisible if the 'invisibleHealth' bool is true and loads 
		the death screen when the player has no health left. */
	}
}

