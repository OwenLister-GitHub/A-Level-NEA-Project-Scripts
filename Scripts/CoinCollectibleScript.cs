using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
 * Created: Session 3
 * Last Edited: Session 20
 * Purpose: To control the coin collectibles/items by defining collisions and adding points to the player's score.
 */

public class CoinCollectibleScript : MonoBehaviour {

	GameObject Event;
	//Defines a a game object which is later used for the event system.

	// Use this for initialization
	void Start () {
		Event = GameObject.FindGameObjectWithTag ("event_system");
		//Finds the event system so that it can be referenced later.
	}

	void OnTriggerEnter2D (Collider2D col){
	
		if (col.gameObject.tag == "Player") {
			Debug.Log ("Player collided with coin");
			Event.SendMessage ("coinPickup"); //'coinPickup' method is in the 'SoundEffects' script.
			Destroy (gameObject);
			//When the player collides with a coin, it will be destroyed.//
			col.gameObject.SendMessage ("CoinScore", 5); //'The referenced 'CoinScore' method is in the 'GameManagerScript' script.
			//When the player collides with a coin, 5 points will be added to the player's score.
		}
	}

	// Update is called once per frame
	void Update () {
		
	}
}
