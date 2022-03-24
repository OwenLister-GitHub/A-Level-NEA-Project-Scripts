using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Created: Session 13
 * Last Edited: Session 13
 * Purpose: To control the small chests in the game by defining what happens to them when the player attacks them.
 */

public class SmallChestScript : MonoBehaviour {

	public GameObject smallRedPotion;
	public GameObject smallBluePotion;
	private bool itemsSpawned = false;
	//Attributes used to instantiate items.

	// Use this for initialization
	void Start () {
		
	}


	public void SmallChestDestruction (int Value) {
		Destroy (gameObject);
		if (itemsSpawned == false) {
			Instantiate (smallRedPotion, transform.position, Quaternion.identity);
			Debug.Log ("Spawned a small red potion");
			Instantiate (smallBluePotion, transform.position, Quaternion.identity);
			Debug.Log ("Spawned a small blue potion");
			itemsSpawned = true;
		}
	}
	/* Destroys the small chest. Then a small red potion and small blue potion is spawned in 
	 * the same position as the small chest was. This method is called upon by the player when 
	 * they attack the small chest.*/

	
	// Update is called once per frame
	void Update () {
		
	}
}
