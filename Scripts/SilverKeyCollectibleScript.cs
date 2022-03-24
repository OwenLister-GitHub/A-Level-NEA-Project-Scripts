using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Created: Session 5 
 * Last Edited: Session 16
 * Purpose: To control the silver key collectibles/items by defining collisions and adding points to the player's score.
 */

public class SilverKeyCollectibleScript : MonoBehaviour {

	private GameObject doors;
	//Defines a game object used to send a message.

	GameObject Event;
	//Defines a a game object which is later used for the event system.

	// Use this for initialization
	void Start () {

		doors = GameObject.FindGameObjectWithTag ("Doors");
		//Finds the game object with the tag, 'Doors'.

		Event = GameObject.FindGameObjectWithTag ("event_system");
		//Finds the event system so that it can be referenced later.
	}

	void OnTriggerEnter2D (Collider2D col){

		if (col.gameObject.tag == "Player"){
			Debug.Log ("Collided with silver key");
			Destroy (gameObject);
			//When the player collides with a silver key, the silver key will be destroyed. 
			col.gameObject.SendMessage("SilverKeyOnPickup", 100); //The referenced 'SilverKeyOnPickup' method is in the 'GameManagerScript' script.
			//Sends a message to the referenced method to add 100 points to the player's score.
			doors.SendMessage("silverKeyLock", 1); //The referenced 'silverKeyLock' method is in the 'DoorsScript' script.
			//Sends a message to the referenced method to change a variable by 1.
			Event.SendMessage("InvisibleHealthOn", true); //'InvisibleHealthOn' method is in the 'PlayerHealthController' script.
		}
	}


	// Update is called once per frame
	void Update () {
		
	}
}
