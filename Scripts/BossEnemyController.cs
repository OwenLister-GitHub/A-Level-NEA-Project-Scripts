using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
 * Created: Session 14
 * Last Edited: Session 20
 * Purpose: To control the boss enemy's movement, health and attacks.
 */

public class BossEnemyController : MonoBehaviour {

	private Transform movementPoint1;
	private Transform movementPoint2;
	private bool move1 = false;
	private bool move2 = true;
	//Used to make the boss enemy move between 2 points.

	private Transform rayCastLocation; 
	//Used as location for a ray cast line.

	public float speed;
	//Used for the movement speed of the boss enemy.

	Animator bossAnimations;
	//Used to play boss enemy's animations.

	GameObject Event;
	//Used to deal damage to the player.

	private int bossHealth = 10;
	//Defines the boss enemy's health.

	private Transform target;
	//Used to identify the player.

	public GameObject goldKey;


	// Use this for initialization
	void Start () {

		bossAnimations = GetComponent<Animator> ();
		movementPoint1 = GameObject.FindGameObjectWithTag ("BossMovementPoint1").GetComponent<Transform> ();
		movementPoint2 = GameObject.FindGameObjectWithTag ("BossMovementPoint2").GetComponent<Transform> ();
		//Find animator component attached to boss enemy and two game objects.

		target = GameObject.FindGameObjectWithTag ("Player").GetComponent<Transform> (); 
		//Finds the player so that points can be added to the player's score.

		rayCastLocation = GameObject.FindGameObjectWithTag ("BossRayCastLocation").GetComponent<Transform> ();
		//Finds game object us	ed as location for a ray cast line.

		Event = GameObject.FindGameObjectWithTag ("event_system");
		//Finds event system so boss enemy can deal damage to the player.

		InvokeRepeating ("movement1", 0.1f, 10f);
		InvokeRepeating ("movement2", 5.1f, 10f);
		//Make the boss enemy move between two points.

		InvokeRepeating ("rightAttackAnimation", 0.1f, 1.5f);
		InvokeRepeating ("rightAttackAnimationOff", 0.9f, 1.5f);
		//Make the boss enemy attack once, repeatedly, every few seconds.
	}
		

	void movement1(){
		move1 = true;
		move2 = false;
	}

	void movement2(){
		move1 = false;
		move2 = true;
	}
	/* Both methods used to control which points the boss enemy moves to. */


	void rightAttackAnimation(){
		bossAnimations.SetBool ("attackRight", true);
		Debug.DrawRay(rayCastLocation.position, Vector2.right*2f, Color.yellow, 0.5f);
		//Draws a ray cast line from the boss enemy, to the right.
		RaycastHit2D hit = Physics2D.Raycast(rayCastLocation.position, Vector2.right, 2f);
		//Defines the value that 'RaycastHit2D' stores.

		if (hit.collider != null && hit.collider.tag == "Player") {
			if (PlayerPrefs.GetString ("Difficulty") == "Hard") {
				Event.SendMessage ("PlayerTakesThreeDamage", 3);
			} else if (PlayerPrefs.GetString ("Difficulty") == "Normal") {
				Event.SendMessage ("PlayerTakesTwoDamage", 2);
			} else if (PlayerPrefs.GetString ("Difficulty") == "Easy") {
				Event.SendMessage ("PlayerTakesOneDamage", 1);
			}
		}
	}
	/* If the player collides with the ray cast line created from the boss enemy, damage
	 * is dealt to the player (the amount of damage depends on the difficulty). */

	void rightAttackAnimationOff(){
		bossAnimations.SetBool ("attackRight", false);
	}
	/* Stops the boss enemy's attack animation. */

	void bossTakesOneDamage(int Dmg){
		bossHealth = bossHealth - Dmg;
		Debug.Log("Player dealt 1 damage to boss!");
	}
	//Used to deal damage to the boss enemy from the player.
	
	// Update is called once per frame
	void Update () {

		if (move1 == true && move2 == false) {
			transform.position = Vector2.MoveTowards (transform.position, movementPoint1.position, speed * Time.deltaTime);
		} else if (move2 == true && move1 == false) {
			transform.position = Vector2.MoveTowards (transform.position, movementPoint2.position, speed * Time.deltaTime);
		}
		/* Makes the boss enemy move towards the points defined and found at the start of the script. Which point depends 
		 * on which boolean variable is true and which is false (which is controlled in the 'movement1' and 'movement2' 
		 * methods above). */

		if (bossHealth == 0) {
			Event.SendMessage ("enemyDeath", 1); //'enemyDeath' method is in the 'SoundEffects' script.
			Destroy (gameObject);
			Instantiate (goldKey, transform.position, Quaternion.identity);
			Debug.Log ("Player defeated the boss!");
			target.SendMessage ("BossEnemyScore", 500); //'BossEnemyScore' script is in the 'GameManagerScript' script.
		}
		/* If the boss enemy's health is 0, it is destroyed, adds 500 points to the player's score and instantiates 
		 * a gold key item/collectible. */
	}
}
