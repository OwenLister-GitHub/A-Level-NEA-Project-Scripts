using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
 * Created: Session 10
 * Last Edited: Session 20
 * Purpose: To control the snake enemy's movement, health and attacks.
 */

public class SnakeEnemyController : MonoBehaviour {

	private int hitPoints = 3;
	private bool dead = false;
	//Defines attributes needed for the snake enemy's health system.

	Animator snakeEnemyAnimations;
	//Used to control this worm enemy's animations. 

	private Transform target;
	public float speed;
	private bool coll = false;
	//Attributes used to control the snake enemy's movement towards the player.

	private bool leftAttackController = false;
	private bool rightAttackController = false;
	//Boolean variables which are later used to control the snake enemy's attacks.

	GameObject Event;
	//Defines a a game object which is later used for the event system.


	// Use this for initialization
	void Start () {

		snakeEnemyAnimations = GetComponent<Animator> ();
		//Finds the animator component attached to the snake enemy so it's animations can be controlled.

		target = GameObject.FindGameObjectWithTag ("Player").GetComponent<Transform> ();
		//Finds the player's transform so that the snake enemy can move towards it.

		Event = GameObject.FindGameObjectWithTag ("event_system");
		//Finds the event system so that it can be referenced later.

		InvokeRepeating ("rightSideCollision", 0.1f, 1.0f);
		InvokeRepeating ("leftSideCollision", 0.1f, 1.0f);
	}




	void leftAttackOn()
	{
		snakeEnemyAnimations.SetBool ("AttackLeft", true);
	}

	void leftAttackOff()
	{
		snakeEnemyAnimations.SetBool ("AttackLeft", false);
	}

	void rightAttackOn()
	{
		snakeEnemyAnimations.SetBool ("AttackRight", true);
	}

	void rightAttackOff()
	{
		snakeEnemyAnimations.SetBool ("AttackRight", false);
	}
	//Methods which enable/disable the snake enemy's left and right attack animations.




	void rightSideCollision()
	{
		Debug.DrawRay(transform.position, Vector2.right*1.0f, Color.yellow, 0.5f);
		//Draws a ray cast line from the snake enemy, to the right.
		RaycastHit2D hitRight = Physics2D.Raycast(transform.position, Vector2.right, 2f);
		//Defines the value that 'RaycastHit2D' stores.


		if (hitRight.collider != null && hitRight.collider.tag == "Player") {
			Invoke ("rightAttackOn", 0.1f);
			if (PlayerPrefs.GetString("Difficulty") == "Hard"){
				Event.SendMessage ("PlayerTakesTwoDamage", 2); //The 'PlayerTakesTwoDamage' method is in the 'PlayerHealthController' script.
			} else {
				Event.SendMessage ("PlayerTakesOneDamage", 1); //The 'PlayerTakesOneDamage' method is in the 'PlayerHealthController' script.
			}
			Invoke ("rightAttackOff", 0.6f);
		} 
	}
	/* Draws a ray cast line to the right of the snake enemy and if the player collides with
	 * that line, the snake enemy's right attack animation is played once by invoking two 
	 * different methods (the first starts the animation playing on a loop and the other
	 * stops the animation playing). Also damages the player if they collide with the ray 
	 * cast line. */


	void leftSideCollision()
	{
		Debug.DrawRay(transform.position, Vector2.left*1.0f, Color.yellow, 0.5f);
		//Draws a ray cast line from the snake enemy, to the left.
		RaycastHit2D hitLeft = Physics2D.Raycast(transform.position, Vector2.left, 2f);
		//Defines the value that 'RaycastHit2D' stores.


		if (hitLeft.collider != null && hitLeft.collider.tag == "Player") {
			Invoke ("leftAttackOn", 0.1f);
			if (PlayerPrefs.GetString("Difficulty") == "Hard"){
				Event.SendMessage ("PlayerTakesTwoDamage", 2); //The 'PlayerTakesTwoDamage' method is in the 'PlayerHealthController' script.
			} else {
				Event.SendMessage ("PlayerTakesOneDamage", 1); //The 'PlayerTakesOneDamage' method is in the 'PlayerHealthController' script.
			}
			Invoke ("leftAttackOff", 0.6f);
		}
	}
	/* Draws a ray cast line to the left of the snake enemy and if the player collides with 
	 * that line, the snake enemy's left attack animation is played once by invoking two 
	 * different methods (the first starts the animation playing on a loop and the other
	 * stops the animation playing). Also damages the player if they collide with the ray 
	 * cast line. */



	public void SnakeEnemyTakesDamage (int DamageDealt){
		hitPoints = hitPoints - DamageDealt; 
		Debug.Log ("Player damaged a snake enemy");
	}
	//Takes away hit points from this snake enemy when the player attacks the snake enemy.



	void OnTriggerEnter2D(Collider2D col){

		if (col.gameObject.tag == "Player") {
			coll = true;
		} else {
			coll = false;
		}
	}
	/* Defines a trigger between the snake enemy and the player which enables the snake enemy to move.
	 * Sets the 'coll' variable to true if the player triggers the (circle) collider on the snake enemy.*/


	// Update is called once per frame
	void Update () {

		if (coll == true) {
			transform.position = Vector2.MoveTowards (transform.position, target.position, speed * Time.deltaTime);
			/*Moves the snake enemy towards the player if the 'coll' bool is true. The 'Time.deltaTime' feature 
		 * ensures that faster computers do not move the snake enemy faster than slower computers.*/
		}

		if (hitPoints <= 0) {
			dead = true;
			Event.SendMessage ("enemyDeath", 1); //'enemyDeath' method is in the 'SoundEffects' script.
			target.SendMessage ("SnakeEnemyScore", 100); //'SnakeEnemyScore' method is in the 'GameManagerScript' script.
			Debug.Log ("Snake enemy defeated!");
			Destroy (gameObject); //Destroys the snake enemy.
		}
		// If the snake enemy has no hit points, it is destroyed and adds 100 points to the player's score.
	}
}