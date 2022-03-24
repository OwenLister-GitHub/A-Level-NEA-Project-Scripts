using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
 * Created: Session 3
 * Last Edited: Session 20
 * Purpose: To control character/player movement and attacks. Also controls character 
 * animations and defines the rigidbody so the player can collide with other objects e.g items.
 */

public class CharacterControllerScript : MonoBehaviour {

	Animator myCharacter; 
	//Used for character animations.

	Rigidbody2D rb;
	//Used for character collisions and movement.

	bool right = false;
	bool left = false;
	bool up = false;
	bool down = false;
	//Boolean variables used to enable the player to deal damage. 

	bool increasedDamage = false;
	//Used to make the player deal increased damage to enemies.

	bool increasedSpeed = false;
	//Used to make the player move faster.

	bool decreasedSpeed = false;
	//Used to make the player move slower.


	// Use this for initialization
	void Start () {
		myCharacter = GetComponent<Animator> ();
		//Finds the animator component attatched to the character sprite.
		rb = GetComponent<Rigidbody2D> ();
		//Finds the rigidbody of the character.

		InvokeRepeating ("rightArrowAttack", 0.000001f, 0.5f);
		InvokeRepeating ("leftArrowAttack", 0.000001f, 0.5f);
		InvokeRepeating ("upArrowAttack", 0.000001f, 0.5f);
		InvokeRepeating ("downArrowAttack", 0.000001f, 0.5f);
		//Repeatedly invokes the player's attack methods.

		if (PlayerPrefs.GetString("Difficulty") == "Hard"){
			rb.drag = 70;
		} else if (PlayerPrefs.GetString("Difficulty") == "Normal"){
			rb.drag = 50;
		} else if (PlayerPrefs.GetString("Difficulty") == "Easy"){
			rb.drag = 30;
		}
		/* Changes the player's movement speed based on the selected difficulty. */
	} 


	public void DecreasedSpeedStart(bool slow){
		decreasedSpeed = true;
		rb.drag = 100;
		Debug.Log ("Player has decreased movement speed for 5 seconds!");
		Invoke ("DecreasedSpeedStop", 5f);
	}//Controls the period of 5 seconds where the player has decreased movement speed.

	public void DecreasedSpeedStop(){
		decreasedSpeed = false;
		if (PlayerPrefs.GetString("Difficulty") == "Hard"){
			rb.drag = 70;
		} else if (PlayerPrefs.GetString("Difficulty") == "Normal"){
			rb.drag = 50;
		} else if (PlayerPrefs.GetString("Difficulty") == "Easy"){
			rb.drag = 30;
		}
		Debug.Log ("Player no longer has decreased movement speed!");
	}//Ends the period of 5 seconds where the player has decreased movement speed.

	public void IncreasedSpeedStart(bool speed){
		increasedSpeed = speed;
		Debug.Log ("Player has increased movement speed for 5 seconds!");
		Invoke ("IncreasedSpeedStop", 5f);
	}//Controls the period of 5 seconds where the player has increased movement speed.

	public void IncreasedSpeedStop(){
		increasedSpeed = false;
		Debug.Log ("Player no longer has increased movement speed!");
	}//Ends the period of 5 seconds where the player has increased movement speed.

	public void IncreaseOn (bool start){
		increasedDamage = start;
		Debug.Log ("Player deals increased damage for 5 seconds!");
		Invoke ("IncreaseOff", 5f);
	}
	//Controls the period of 5 seconds where the player deals increased damage.

	public void IncreaseOff (){
		increasedDamage = false;
		Debug.Log ("Player no longer deals increased damage!");
	}
	//Ends the period where the player deals increased damage.


	void rightArrowAttack()
	{
		Debug.DrawRay(transform.position, Vector2.right*0.75f, Color.yellow, 0.2f);
		//Draws a ray cast line from the player, to the right.
		RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, 1f);
		//Defines the value that 'RaycastHit2D' stores.


		if (hit.collider != null && hit.collider.tag == "LargeChest" && right == true) {
			Debug.Log ("Destroyed a large chest!");
			hit.collider.SendMessage("ChestDestruction", 1); //Sends a message to the 'ChestDestruction' method in the 'LargeChestScript' script. 
		} 
		else if (hit.collider != null && hit.collider.tag == "WormEnemy" && right == true){
			Debug.Log ("Hit a worm enemy!");
			if (increasedDamage == true){
				hit.collider.SendMessage ("WormEnemyTakesDamage", 3); //Sends a message to the 'WormEnemyTakesDamage' method in the 'WormEnemyController' script.
			}
			else if (increasedDamage == false){
				hit.collider.SendMessage ("WormEnemyTakesDamage", 1); //Sends a message to the 'WormEnemyTakesDamage' method in the 'WormEnemyController' script.
			}
			//Deals increased damage to the worm enemy if the 'increasedDamage' bool is true.
		} 
		else if (hit.collider != null && hit.collider.tag == "SnakeEnemy" && right == true){
			Debug.Log ("Hit a snake enemy");
			if (increasedDamage == true){
				hit.collider.SendMessage ("SnakeEnemyTakesDamage", 3); //Sends a message to the 'SnakeEnemyTakesDamage' method in the 'SnakeEnemyController' script.
			}
			else if (increasedDamage == false){
				hit.collider.SendMessage ("SnakeEnemyTakesDamage", 1); //Sends a message to the 'SnakeEnemyTakesDamage' method in the 'SnakeEnemyController' script.
			}
			//Deals increased damage to the snake enemy if the 'increasedDamage' bool is true.
		}
		else if (hit.collider != null && hit.collider.tag == "SmallChest" && right == true){
			Debug.Log ("Destroyed a small chest!");
			hit.collider.SendMessage("SmallChestDestruction", 1); //Sends a message to the 'SmallChestDestruction' method in the 'SmallChestScript' script. 
		}
		else if (hit.collider != null && hit.collider.tag == "Boss" && right == true){
			Debug.Log ("Hit boss enemy!");
			hit.collider.SendMessage("bossTakesOneDamage", 1); //Sends a message to the 'bossTakesOneDamage' method in the 'BossEnemyController' script. 
		}
		else { 
			Debug.Log ("Nothing");
		}
	}
	/* This defines the conditions for what happens if the player's ray cast line for this 
	 * attack collides with a worm enemy, snake enemy, boss enemy, small chest or large chest. */


	void leftArrowAttack()
	{
		Debug.DrawRay(transform.position, Vector2.left*0.75f, Color.yellow, 0.2f);
		//Draws a ray cast line from the player, to the left.
		RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.left, 1f);
		//Defines the value that 'RaycastHit2D' stores.


		if (hit.collider != null && hit.collider.tag == "LargeChest" && left == true) {
			Debug.Log ("Destroyed a large chest!");
			hit.collider.SendMessage("ChestDestruction", 1); //Sends a message to the 'ChestDestruction' method in the 'LargeChestScript' script. 
		} 
		else if (hit.collider != null && hit.collider.tag == "WormEnemy" && left == true){
			Debug.Log ("Hit a worm enemy!");
			if (increasedDamage == true){
				hit.collider.SendMessage ("WormEnemyTakesDamage", 3); //Sends a message to the 'WormEnemyTakesDamage' method in the 'WormEnemyController' script.
			}
			else if (increasedDamage == false){
				hit.collider.SendMessage ("WormEnemyTakesDamage", 1); //Sends a message to the 'WormEnemyTakesDamage' method in the 'WormEnemyController' script.
			}
			//Deals increased damage to the worm enemy if the 'increasedDamage' bool is true.
		} 
		else if (hit.collider != null && hit.collider.tag == "SnakeEnemy" && left == true){
			Debug.Log ("Hit a snake enemy");
			if (increasedDamage == true){
				hit.collider.SendMessage ("SnakeEnemyTakesDamage", 3); //Sends a message to the 'SnakeEnemyTakesDamage' method in the 'SnakeEnemyController' script.
			}
			else if (increasedDamage == false){
				hit.collider.SendMessage ("SnakeEnemyTakesDamage", 1); //Sends a message to the 'SnakeEnemyTakesDamage' method in the 'SnakeEnemyController' script.
			}
			//Deals increased damage to the snake enemy if the 'increasedDamage' bool is true.
		}
		else if (hit.collider != null && hit.collider.tag == "SmallChest" && left == true){
			Debug.Log ("Destroyed a small chest!");
			hit.collider.SendMessage("SmallChestDestruction", 1); //Sends a message to the 'SmallChestDestruction' method in the 'SmallChestScript' script. 
		}
		else if (hit.collider != null && hit.collider.tag == "Boss" && left == true){
			Debug.Log ("Hit boss enemy!");
			hit.collider.SendMessage("bossTakesOneDamage", 1); //Sends a message to the 'bossTakesOneDamage' method in the 'BossEnemyController' script. 
		}
		else { 
			Debug.Log ("Nothing");
		}
	}
	/* This defines the conditions for what happens if the player's ray cast line for this 
	 * attack collides with a worm enemy, snake enemy, boss enemy, small chest or large chest. */


	void upArrowAttack()
	{
		Debug.DrawRay(transform.position, Vector2.up*0.75f, Color.yellow, 0.2f);
		//Draws a ray cast line from the player, upwards.
		RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up, 1f);
		//Defines the value that 'RaycastHit2D' stores.


		if (hit.collider != null && hit.collider.tag == "LargeChest" && up == true) {
			Debug.Log ("Destroyed a large chest!");
			hit.collider.SendMessage("ChestDestruction", 1); //Sends a message to the 'ChestDestruction' method in the 'LargeChestScript' script. 
		} 
		else if (hit.collider != null && hit.collider.tag == "WormEnemy" && up == true){
			Debug.Log ("Hit a worm enemy!");
			if (increasedDamage == true){
				hit.collider.SendMessage ("WormEnemyTakesDamage", 3); //Sends a message to the 'WormEnemyTakesDamage' method in the 'WormEnemyController' script.
			}
			else if (increasedDamage == false){
				hit.collider.SendMessage ("WormEnemyTakesDamage", 1); //Sends a message to the 'WormEnemyTakesDamage' method in the 'WormEnemyController' script.
			}
			//Deals increased damage to the worm enemy if the 'increasedDamage' bool is true.
		} 
		else if (hit.collider != null && hit.collider.tag == "SnakeEnemy" && up == true){
			Debug.Log ("Hit a snake enemy");
			if (increasedDamage == true){
				hit.collider.SendMessage ("SnakeEnemyTakesDamage", 3); //Sends a message to the 'SnakeEnemyTakesDamage' method in the 'SnakeEnemyController' script.
			}
			else if (increasedDamage == false){
				hit.collider.SendMessage ("SnakeEnemyTakesDamage", 1); //Sends a message to the 'SnakeEnemyTakesDamage' method in the 'SnakeEnemyController' script.
			}
			//Deals increased damage to the snake enemy if the 'increasedDamage' bool is true.
		}
		else if (hit.collider != null && hit.collider.tag == "SmallChest" && up == true){
			Debug.Log ("Destroyed a small chest!");
			hit.collider.SendMessage("SmallChestDestruction", 1); //Sends a message to the 'SmallChestDestruction' method in the 'SmallChestScript' script. 
		}
		else if (hit.collider != null && hit.collider.tag == "Boss" && up == true){
			Debug.Log ("Hit boss enemy!");
			hit.collider.SendMessage("bossTakesOneDamage", 1); //Sends a message to the 'bossTakesOneDamage' method in the 'BossEnemyController' script. 
		}
		else { 
			Debug.Log ("Nothing");
		}
	}
	/* This defines the conditions for what happens if the player's ray cast line for this 
	 * attack collides with a worm enemy, snake enemy, boss enemy, small chest or large chest. */


	void downArrowAttack()
	{
		Debug.DrawRay(transform.position, Vector2.down*0.75f, Color.yellow, 0.2f);
		//Draws a ray cast line from the player, downwards.
		RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1f);
		//Defines the value that 'RaycastHit2D' stores.


		if (hit.collider != null && hit.collider.tag == "LargeChest" && down == true) {
			Debug.Log ("Destroyed a large chest!");
			hit.collider.SendMessage("ChestDestruction", 1); //Sends a message to the 'ChestDestruction' method in the 'LargeChestScript' script. 
		} 
		else if (hit.collider != null && hit.collider.tag == "WormEnemy" && down == true){
			Debug.Log ("Hit a worm enemy!");
			if (increasedDamage == true){
				hit.collider.SendMessage ("WormEnemyTakesDamage", 3); //Sends a message to the 'WormEnemyTakesDamage' method in the 'WormEnemyController' script.
			}
			else if (increasedDamage == false){
				hit.collider.SendMessage ("WormEnemyTakesDamage", 1); //Sends a message to the 'WormEnemyTakesDamage' method in the 'WormEnemyController' script.
			}
			//Deals increased damage to the worm enemy if the 'increasedDamage' bool is true.
		} 
		else if (hit.collider != null && hit.collider.tag == "SnakeEnemy" && down == true){
			Debug.Log ("Hit a snake enemy");
			if (increasedDamage == true){
				hit.collider.SendMessage ("SnakeEnemyTakesDamage", 3); //Sends a message to the 'SnakeEnemyTakesDamage' method in the 'SnakeEnemyController' script.
			}
			else if (increasedDamage == false){
				hit.collider.SendMessage ("SnakeEnemyTakesDamage", 1); //Sends a message to the 'SnakeEnemyTakesDamage' method in the 'SnakeEnemyController' script.
			}
			//Deals increased damage to the snake enemy if the 'increasedDamage' bool is true.
		}
		else if (hit.collider != null && hit.collider.tag == "SmallChest" && down == true){
			Debug.Log ("Destroyed a small chest!");
			hit.collider.SendMessage("SmallChestDestruction", 1); //Sends a message to the 'SmallChestDestruction' method in the 'SmallChestScript' script. 
		}
		else if (hit.collider != null && hit.collider.tag == "Boss" && down == true){
			Debug.Log ("Hit boss enemy!");
			hit.collider.SendMessage("bossTakesOneDamage", 1); //Sends a message to the 'bossTakesOneDamage' method in the 'BossEnemyController' script. 
		}
		else { 
			Debug.Log ("Nothing");
		}
	}
	/* This defines the conditions for what happens if the player's ray cast line for this 
	 * attack collides with a worm enemy, snake enemy, boss enemy, small chest or large chest. */



	// Update is called once per frame
	void Update () {
		

		if (Input.GetKey (KeyCode.W)) {
			if (increasedSpeed == false) {
				myCharacter.SetBool ("WalkUp", true);
				rb.AddForce (new Vector2 (0, 2), ForceMode2D.Impulse);
			} else if (increasedSpeed == true) {
				myCharacter.SetBool ("WalkUp", true);
				rb.AddForce (new Vector2 (0, 4), ForceMode2D.Impulse);
			}
		}
		else{
			myCharacter.SetBool ("WalkUp", false);
		}//Controls how much the player moves.

		if (Input.GetKey (KeyCode.A)) {
			if (increasedSpeed == false) {
				myCharacter.SetBool ("WalkLeft", true);
				rb.AddForce (new Vector2 (-2, 0), ForceMode2D.Impulse);
			} else if (increasedSpeed == true) {
				myCharacter.SetBool ("WalkLeft", true);
				rb.AddForce (new Vector2 (-4, 0), ForceMode2D.Impulse);
			}
		}
		else{
			myCharacter.SetBool ("WalkLeft", false);
		}//Controls how much the player moves.

		if (Input.GetKey (KeyCode.S)) {
			if (increasedSpeed == false) {
				myCharacter.SetBool ("WalkDown", true);
				rb.AddForce (new Vector2 (0, -2), ForceMode2D.Impulse);
			} else if (increasedSpeed == true) {
				myCharacter.SetBool ("WalkDown", true);
				rb.AddForce (new Vector2 (0, -4), ForceMode2D.Impulse);
			}
		}
		else{
			myCharacter.SetBool ("WalkDown", false);
		}//Controls how much the player moves.

		if (Input.GetKey (KeyCode.D)) {
			if (increasedSpeed == false) {
				myCharacter.SetBool ("WalkRight", true);
				rb.AddForce (new Vector2 (2, 0), ForceMode2D.Impulse);
			} else if (increasedSpeed == true) {
				myCharacter.SetBool ("WalkRight", true);
				rb.AddForce (new Vector2 (4, 0), ForceMode2D.Impulse);
			}
		}
		else{
			myCharacter.SetBool ("WalkRight", false);
		}//Controls how much the player moves.




		if (Input.GetKey (KeyCode.RightArrow)) {
			myCharacter.SetBool ("AttackRight", true);
			right = true;
		} else {
			myCharacter.SetBool ("AttackRight", false);
			right = false;
		}
		/* Plays the character's right attack animation when the right arrow key is pressed by
		 * the player and the 'right' boolean variable is set to true which enables the player 
		 * to deal damage to enemies and/or objects such as chests.*/




		if (Input.GetKey (KeyCode.LeftArrow)) {
			myCharacter.SetBool ("AttackLeft", true);
			left = true;
		} else {
			myCharacter.SetBool ("AttackLeft", false);
			left = false;
		}
		/* Plays the character's left attack animation when the left arrow key is pressed by
		 * the player and the 'left' boolean variable is set to true which enables the player 
		 * to deal damage to enemies and/or objects such as chests.*/




		if (Input.GetKey (KeyCode.UpArrow)) {
			myCharacter.SetBool ("AttackUp", true);
			up = true;
		} else {
			myCharacter.SetBool ("AttackUp", false);
			up = false;
		}
		/* Plays the character's up attack animation when the up arrow key is pressed by
		 * the player and the 'up' boolean variable is set to true which enables the player 
		 * to deal damage to enemies and/or objects such as chests.*/




		if (Input.GetKey (KeyCode.DownArrow)) {
			myCharacter.SetBool ("AttackDown", true);
			down = true;
		} else {
			myCharacter.SetBool ("AttackDown", false);
			down = false;
		}
		/* Plays the character's down attack animation when the down arrow key is pressed by
		 * the player and the 'down' boolean variable is set to true which enables the player 
		 * to deal damage to enemies and/or objects such as chests.*/
	}	
	//Declares the character controls for attacks and movement. 
}
