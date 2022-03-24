using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
 * Created: Session 9
 * Last Edited: Session 19
 * Purpose: To control the worm enemy's movement, health and attacks.
 */

public class WormEnemyController : MonoBehaviour {

	private int hitPoints = 2;
	private bool dead = false;
	//Defines attributes needed for the worm enemy's health system.

	Animator wormEnemyAnimations;
	//Used to control this worm enemy's animations. 

	GameObject Event;
	//Defines a a game object which is later used for the event system.

	Vector3 start = new Vector3(0,1, 0);
	//Defines a vector2 used for the ray cast lines of the worm enemy's attacks.

	GameObject target;
	//Used to find the player later in the script.


	// Use this for initialization
	void Start () {

		wormEnemyAnimations = GetComponent<Animator> ();
		//Finds the animator component attached to the worm enemy so it's animations can be controlled.

		target = GameObject.FindGameObjectWithTag ("Player"); 
		//Finds the player.

		Event = GameObject.FindGameObjectWithTag ("event_system");
		//Finds the event system so that it can be referenced later.

		InvokeRepeating ("leftAttack", 0.1f, 2.0f);
		InvokeRepeating ("leftAttackOff", 1.0f, 2.0f);

		InvokeRepeating ("rightAttack", 1.1f, 2.0f);
		InvokeRepeating ("rightAttackOff", 2.0f, 2.0f);
		/*Invoke repating calls upon methods below to play the enemy's left attack animation once, then the
		 * right animation once. This is then repeated.  */
	}



	void leftAttack()
	{
		wormEnemyAnimations.SetBool ("Attack_Left", true);

		Debug.DrawRay(transform.position - start, Vector2.left*2.0f, Color.green, 1.0f);
		//Draws a ray cast line from the worm enemy, to the left.
		RaycastHit2D hit = Physics2D.Raycast(transform.position - start, Vector2.left, 2f);
		//Defines the value that 'RaycastHit2D' stores.


		if (hit.collider != null && hit.collider.tag == "Player") {
			if (PlayerPrefs.GetString("Difficulty") == "Easy"){
				Event.SendMessage ("PlayerTakesOneDamage", 1); //The 'PlayerTakesOneDamage' method is in the 'PlayerHealthController' script.
			} else if (PlayerPrefs.GetString("Difficulty") == "Normal"){
				Event.SendMessage ("PlayerTakesTwoDamage", 2); //The 'PlayerTakesTwoDamage' method is in the 'PlayerHealthController' script.
			} else if (PlayerPrefs.GetString("Difficulty") == "Hard"){
				Event.SendMessage ("PlayerTakesThreeDamage", 3); //The 'PlayerTakesThreeDamage' method is in the 'PlayerHealthController' script.
			}
		} else {
			Debug.Log ("Worm enemy has not hit the player");
		}
		/* Defines the conditions for the worm enemy to deal damage to the player and deals damage to the 
		 * player if there is a collision between the player and the worm enemy. */
	}

	void leftAttackOff()
	{
		wormEnemyAnimations.SetBool ("Attack_Left", false);
	}
	//Stops the worm enemy's left attack animation.

	void rightAttackOff()
	{
		wormEnemyAnimations.SetBool ("Attack_Right", false);
	}
	//Stops the worm enemy's right attack animation.

	void rightAttack()
	{
		wormEnemyAnimations.SetBool ("Attack_Right", true);

		Debug.DrawRay(transform.position - start, Vector2.right*2.0f, Color.green, 1.0f);
		//Draws a ray cast line from the worm enemy, to the right.
		RaycastHit2D hit = Physics2D.Raycast(transform.position - start, Vector2.right, 2f);
		//Defines the value that 'RaycastHit2D' stores.


		if (hit.collider != null && hit.collider.tag == "Player") {
			if (PlayerPrefs.GetString("Difficulty") == "Easy"){
				Event.SendMessage ("PlayerTakesOneDamage", 1); //The 'PlayerTakesOneDamage' method is in the 'PlayerHealthController' script.
			} else if (PlayerPrefs.GetString("Difficulty") == "Normal"){
				Event.SendMessage ("PlayerTakesTwoDamage", 2); //The 'PlayerTakesTwoDamage' method is in the 'PlayerHealthController' script.
			} else if (PlayerPrefs.GetString("Difficulty") == "Hard"){
				Event.SendMessage ("PlayerTakesThreeDamage", 3); //The 'PlayerTakesThreeDamage' method is in the 'PlayerHealthController' script.
			}
		} else {
			Debug.Log ("Worm enemy has not hit the player");
		}
		/*Defines the conditions for the worm enemy to deal damage to the player and deals one point of damage to the 
		 * player if there is a collision between the player and the worm enemy. */
	}



	public void WormEnemyTakesDamage (int DamageDealt){
		hitPoints = hitPoints - DamageDealt; 
		Debug.Log ("Player damaged a worm enemy");
	}
	//Takes away hit points from this worm enemy when the player attacks the worm enemy.


	// Update is called once per frame
	void Update () {
		
		if (hitPoints <= 0) {
			Event.SendMessage ("enemyDeath", 1); //'enemyDeath' method is in the 'SoundEffects' script.
			dead = true;
			Destroy (gameObject);
			target.SendMessage ("WormEnemyScore", 50); //'WormEnemyScore' script is in the 'GameManagerScript' script.
			Debug.Log ("Worm enemy defeated!");
		}
		// If the worm enemy has no hit points, it is destroyed and adds 50 points to the player's score.
	}
}
