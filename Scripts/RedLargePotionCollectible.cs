using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Created: Session 5 
 * Last Edited: Session 16
 * Purpose: To control the large red potion collectibles/items by defining collisions and adding points to the player's score.
 */

public class RedLargePotionCollectible : MonoBehaviour {

	GameObject Event;
	//Defines a a game object which is later used for the event system.

	// Use this for initialization
	void Start () {

		Event = GameObject.FindGameObjectWithTag ("event_system");
		//Finds the event system so that it can be referenced later for adding to the player's health.
	}

	void OnTriggerEnter2D (Collider2D col){

		if (col.gameObject.tag == "Player"){
			Debug.Log ("Collided with a large red potion");
			Destroy (gameObject);
			//When the player collides with a large red potion, it will be destroyed. 
			col.gameObject.SendMessage("LargeRedPotionScore", 15); //The referenced 'LargeRedPotionScore' method is in the 'GameManagerScript' script.
			//When the player collides with a large red potion, after it is destroyed, 15 points are added to the player's score.
			Event.SendMessage("PlayerGainsHealth", 1); //The 'PlayerGainsHealth' method is in the 'PlayerHealthController' script.
			col.gameObject.SendMessage("IncreaseOn", true); //The 'IncreaseOn' method is in the 'CharacterControllerScript' script.
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
