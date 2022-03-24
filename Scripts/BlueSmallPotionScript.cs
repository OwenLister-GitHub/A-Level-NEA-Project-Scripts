using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Created: Session 5 
 * Last Edited: Session 16
 * Purpose: To control the small blue potion collectibles/items by defining collisions and adding points to the player's score.
 */

public class BlueSmallPotionScript : MonoBehaviour { 


	// Use this for initialization
	void Start () {
		
	}

	void OnTriggerEnter2D (Collider2D col){

		if (col.gameObject.tag == "Player"){
			Debug.Log ("Collided with a small blue potion");
			Destroy (gameObject);
			//When the player collides with a small blue potion, it will be destroyed. 
			col.gameObject.SendMessage("SmallBluePotionScore", 5); //The referenced 'SmallBluePotionScore' method is in the 'GameManagerScript' script.
			//When the player collides with a small blue potion, after it is destroyed, 5 points are added to the player's score.
			col.gameObject.SendMessage("DecreasedSpeedStart", true);
		} /* The 'DecreasedSpeedStart' method is in the 'CharacterControllerScript' script. */
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
