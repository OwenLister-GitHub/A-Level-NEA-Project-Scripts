using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Created: Session 5 
 * Last Edited: Session 16
 * Purpose: To control the gold key collectibles/items by defining collisions and adding points to the player's score.
 */

public class GoldKeyCollectibleScript : MonoBehaviour {

	private GameObject doors;
	//Defines a game object used to send a message.

	// Use this for initialization
	void Start () {
	
		doors = GameObject.FindGameObjectWithTag ("Doors");
		//Finds the game object with the tag, 'Doors'.
	}

	void OnTriggerEnter2D (Collider2D col){

		if (col.gameObject.tag == "Player"){
			Debug.Log ("Collided with gold key");
			Destroy (gameObject);
			//When the player collides with a gold key, the gold key will be destroyed. 
			col.gameObject.SendMessage("GoldKeyOnPickup", 100); //The referenced 'GoldKeyOnPickup' method is in the 'GameManagerScript' script.
			//Sends a message to the referenced method to add 100 points to the player's score.
			doors.SendMessage("goldKeyLock", 1); //The referenced 'silverKeyLock' method is in the 'DoorsScript' script.
			//Sends a message to the referenced method to change a variable by 1.
			col.gameObject.SendMessage("IncreasedSpeedStart", true); 
			//The 'IncreasedSpeedStart' method is in the 'CharacterControllerScript' script.
		}
	}


	// Update is called once per frame
	void Update () {
		
	}
}
