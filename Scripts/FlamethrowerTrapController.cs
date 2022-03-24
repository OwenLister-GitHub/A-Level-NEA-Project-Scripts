using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlamethrowerTrapController : MonoBehaviour {

 /*
 * Created: Session 12
 * Last Edited: Session 12
 * Purpose: To control the flamethrower trap by defining when it should deal damage to the player.
 */

	GameObject Event;
	//Defines a a game object which is later used for the event system.

	// Use this for initialization
	void Start () {

		Event = GameObject.FindGameObjectWithTag ("event_system");
		//Finds the event system so that it can be referenced later.
	}
		

	void OnTriggerEnter2D(Collider2D col){

		if (col.gameObject.tag == "Player") {
			Event.SendMessage ("PlayerTakesOneDamage", 1); //The 'PlayerTakesOneDamage' method is in the 'PlayerHealthController' script.
		}
	}
	//If the player collides with the flamethrower trap, one point of damage is dealt to the player.

	// Update is called once per frame
	void Update () {
		
	}
}
