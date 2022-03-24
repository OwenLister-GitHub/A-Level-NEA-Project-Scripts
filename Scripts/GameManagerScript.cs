using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/*
 * Created: Session 4
 * Last Edited: Session 15
 * Purpose: To define and control essential features of the game such as the player's score.
 * Also has methods called upon in other scripts for features such as items/pickups and score.
 */

public class GameManagerScript : MonoBehaviour {

	public int score;
	public TextMeshPro scoreText; 
	//Defines the attributes used for the score system.

	public TextMeshPro timerText;
	private float timerTime;
	//Defines the attributes used for the timer.

	// Use this for initialization
	void Start () {

		score = PlayerPrefs.GetInt ("PlayerScore");
		scoreText.text = "Score: " + PlayerPrefs.GetInt ("PlayerScore");
		/* Sets the 'score' variable equal to the 'PlayerScore' player pref value (currently
		 * zero) and then displays the score, using the 'PlayerScore' player pref value. */

		timerTime = PlayerPrefs.GetFloat ("Time");
		/*Sets the 'timerTime' variable equal to the 'Time' player pref value so that the 
		 * player's time can be stored. */
	}

	public void CoinScore (int AddCoinScore){

		score = score + AddCoinScore;
		PlayerPrefs.SetInt ("PlayerScore", score);
		scoreText.text = "Score: " + PlayerPrefs.GetInt ("PlayerScore");
		Debug.Log ("5 Points added to score!");
	}
	//Adds 5 points to the player's score when the player collides with and 'picks up' a coin.


	public void CoinBagScore (int AddCoinBagScore){

		score = score + AddCoinBagScore;
		PlayerPrefs.SetInt ("PlayerScore", score);
		scoreText.text = "Score: " + PlayerPrefs.GetInt ("PlayerScore");
		Debug.Log ("Added 25 points to score!");
	}
	//Adds 25 points to the player's score when the player collides with and 'picks up' a coin bag.

	public void GoldKeyOnPickup (int AddKeyGoldScore){
		
		score = score + AddKeyGoldScore;
		PlayerPrefs.SetInt ("PlayerScore", score);
		scoreText.text = "Score: " + PlayerPrefs.GetInt ("PlayerScore");
		Debug.Log ("Added 100 points to score!");
	}
	//Adds 100 points to the player's score when the player collides with and 'picks up' a gold key.

	public void SilverKeyOnPickup (int AddKeySilverScore){

		score = score + AddKeySilverScore;
		PlayerPrefs.SetInt ("PlayerScore", score);
		scoreText.text = "Score: " + PlayerPrefs.GetInt ("PlayerScore");
		Debug.Log ("Added 100 points to score!");
	}
	//Adds 100 points to the player's score when the player collides with and 'picks up' a silver key.

	public void SmallRedPotionScore (int AddSmallRedPotionScore){

		score = score + AddSmallRedPotionScore;
		PlayerPrefs.SetInt ("PlayerScore", score);
		scoreText.text = "Score: " + PlayerPrefs.GetInt ("PlayerScore");
		Debug.Log ("Added 15 points to score!");
	}
	//Adds 5 points to the player's score when the player collides with and 'picks up' a small red potion.

	public void LargeRedPotionScore (int AddLargeRedPotionScore){

		score = score + AddLargeRedPotionScore;
		PlayerPrefs.SetInt ("PlayerScore", score);
		scoreText.text = "Score: " + PlayerPrefs.GetInt ("PlayerScore"); 
		Debug.Log ("Added 15 points to score!");
	}
	//Adds 15 points to the player's score when the player collides with and 'picks up' a large red potion.

	public void SmallBluePotionScore (int AddSmallBluePotionScore){

		score = score + AddSmallBluePotionScore;
		PlayerPrefs.SetInt ("PlayerScore", score);
		scoreText.text = "Score: " + PlayerPrefs.GetInt ("PlayerScore");
		Debug.Log ("Added 15 points to score!");
	}
	//Adds 5 points to the player's score when the player collides with and 'picks up' a small blue potion.

	public void LargeBluePotionScore (int AddLargeBluePotionScore){

		score = score + AddLargeBluePotionScore;
		PlayerPrefs.SetInt ("PlayerScore", score);
		scoreText.text = "Score: " + PlayerPrefs.GetInt ("PlayerScore"); 
		Debug.Log ("Added 15 points to score!");
	}
	//Adds 15 points to the player's score when the player collides with and 'picks up' a large blue potion.

	public void WormEnemyScore (int WormScore){

		score = score + WormScore;
		PlayerPrefs.SetInt ("PlayerScore", score);
		scoreText.text = "Score: " + PlayerPrefs.GetInt ("PlayerScore");
		Debug.Log ("Added 50 points to score!");
	}
	//Adds 50 points to the player's score when the player defeats a worm enemy.

	public void SnakeEnemyScore (int SnakeScore){

		score = score + SnakeScore;
		PlayerPrefs.SetInt ("PlayerScore", score);
		scoreText.text = "Score: " + PlayerPrefs.GetInt ("PlayerScore");
		Debug.Log ("Added 100 points to score!");
	}
	//Adds 100 points to the player's score when the player defeats a snake enemy.

	public void BossEnemyScore (int BossScore){

		score = score + BossScore;
		PlayerPrefs.SetInt ("PlayerScore", score);
		scoreText.text = "Score: " + PlayerPrefs.GetInt ("PlayerScore");
		Debug.Log ("Added 500 points to score!");
	}
	//Adds 500 points to the player's score when the player defeats the boss enemy.


	// Update is called once per frame
	void Update () {

		timerText.text = "Time: " + Time.fixedTime.ToString(); 
		timerTime = Time.fixedTime;
		PlayerPrefs.SetFloat ("Time",timerTime);

		PlayerPrefs.SetInt ("PlayerScore", score);
	}
	/* Updates the timer, the 'Time' player pref value and the 'PlayerScore' player pref value 
	 * so that the text changes (time and score), the time increases for the user and so the
	 * player's time can be displayed & stored for use elsewhere. The timer is constantly set to 
	 * the 'Time' player pref value so that it can be carried between levels (as the scene changes).*/
}
