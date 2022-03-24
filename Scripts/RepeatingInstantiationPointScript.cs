using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingInstantiationPointScript : MonoBehaviour {

 /*
 * Created: Session 15
 * Last Edited: Session 15
 * Purpose: To control the repeating instantiation points in the game by defining when enemies are to
 * be instantiate, and where.
 */

	public GameObject snakeEnemy;
	//Used to instantiate a snake enemy later in the script.

	// Use this for initialization
	void Start () {
		
	}

	void OnTriggerEnter2D (Collider2D col){
		InvokeRepeating ("SnakeInstantiation", 0.1f, 4f);
	}
	/* Repeatedly invokes the 'SnakeInstantiation' method so that snake enemies are repeatedly
	 * instantiated. */

	void SnakeInstantiation(){
		Instantiate (snakeEnemy, transform.position, Quaternion.identity);
		Debug.Log ("Spawned a snake enemy");
	}
	//Instantiates a snake enemy and outputs a message to the debug log.

	// Update is called once per frame
	void Update () {
		
	}
}
