using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiationPointController : MonoBehaviour {

 /*
 * Created: Session 13
 * Last Edited: Session 13
 * Purpose: To control the instantiation points in the game by defining which enemies to instantiate
 * and where to instantiate them.
 */

	public GameObject snakeEnemy;
	private bool instantiated = false;
	//Defines attributes used for the instantiation of enemies.

	// Use this for initialization
	void Start () {
		
	}

	void OnTriggerEnter2D (Collider2D col){

		if (instantiated == false && col.gameObject.tag == "Player"){
			Instantiate (snakeEnemy, transform.position, Quaternion.identity);
			Debug.Log ("Spawned a snake enemy");
			instantiated = true;
		}
	}
	/* Instantiates a snake enemy when the player triggers the collider and sets 'instantiated'
	 * to true so that it can only happen once. */
	
	// Update is called once per frame
	void Update () {
		
	}
}
