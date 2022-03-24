using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Created: Session 5
 * Last Edited: Session 20
 * Purpose: To control the coin bag collectibles/items by defining collisions and adding points to the player's score.
 */

public class CoinBagCollectibleScript : MonoBehaviour {

	GameObject Event;
	//Defines a a game object which is later used for the event system.

	// Use this for initialization
	void Start () {
		Event = GameObject.FindGameObjectWithTag ("event_system");
		//Finds the event system so that it can be referenced later.
	}
		
	void OnTriggerEnter2D (Collider2D col){

		if (col.gameObject.tag == "Player") {
			Debug.Log ("Player collided with coin bag");
			Event.SendMessage ("coinPickup"); //'coinPickup' method is in the 'SoundEffects' script.
			Destroy (gameObject);
			//When the player collides with a coin bag, it will be destroyed.
			col.gameObject.SendMessage("CoinBagScore", 25); //'The referenced 'CoinBagScore' method is in the 'GameManagerScript' script.
			//When the player collides with a coin bag, 25 points will be added to their score. 
		}
	}

	
	// Update is called once per frame
	void Update () {
		
	}
}
