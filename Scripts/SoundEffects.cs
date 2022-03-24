using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
 * Created: Session 20
 * Last Edited: Session 20
 * Purpose: To control the sound effects in the game, such as when sounds are played.
 */

public class SoundEffects : MonoBehaviour {

	public AudioClip death, coin;
	//Attributes to act as the actual sound effects.
	private AudioSource source;
	//Attribute used to play sound effects.

	// Use this for initialization
	void Start () {
		source = gameObject.GetComponent<AudioSource> ();
		/* Finds the 'AudioSource' component attached to the game object this 
		 * script is attached to so sound effects can be played. */
	}

	public void coinPickup(){
		source.PlayOneShot (coin, 1);
	}
	/* Plays (once) the coin pickup sound effect for coins. */

	public void enemyDeath(int num){
		source.PlayOneShot (death, 1);
	}
	/* Plays (once) the death sound effect for enemies. */

	// Update is called once per frame
	void Update () {
		
	}
}
