using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Created: Session 5 
 * Last Edited: Session 16
 * Purpose: To control the large blue potion collectibles/items by defining collisions and adding points to the player's score.
 */

public class BlueLargePotionScript : MonoBehaviour {


	GameObject Event;
	//Defines a a game object which is later used for the event system.

	// Use this for initialization
	void Start () {
		Event = GameObject.FindGameObjectWithTag ("event_system");
		//Finds the event system so that it can be referenced later.
	}

	void OnTriggerEnter2D (Collider2D col){

		if (col.gameObject.tag == "Player"){
			Debug.Log ("Collided with a large blue potion");
			Destroy (gameObject);
			//When the player collides with a large blue potion, it will be destroyed. 
			col.gameObject.SendMessage("LargeBluePotionScore", 15); //The referenced 'LargeBluePotionScore' method is in the 'GameManagerScript' script.
			//When the player collides with a large blue potion, after it is destroyed, 15 points are added to the player's score.
			Event.SendMessage("ToxicOn", true); 
			//The 'ToxicOn' method is in the 'PlayerHealthController' script and starts the toxic effect de-buff.
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
