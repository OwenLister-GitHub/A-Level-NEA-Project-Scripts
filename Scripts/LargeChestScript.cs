using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Created: Session 8
 * Last Edited: Session 8
 * Purpose: To control the large chests in the game by defining what happens to them when the player attacks them.
 */

public class LargeChestScript : MonoBehaviour {

	public GameObject largeRedPotion;
	public GameObject coin;
	private bool itemsSpawned = false;

	// Use this for initialization
	void Start () {
		
	}


	public void ChestDestruction (int Value) {
		Destroy (gameObject);
		if (itemsSpawned == false) {
			Instantiate (largeRedPotion, transform.position, Quaternion.identity);
			Debug.Log ("Spawned a large red potion");
			Instantiate (coin, transform.position, Quaternion.identity);
			Debug.Log ("Spawned a coin");
			itemsSpawned = true;
		}
	}
	/*Destroys the chest. Then a large red potion and coin are spawned in the same position as the large chest was.
	 *This method is called upon by the player when they attack the large chest.*/

	// Update is called once per frame
	void Update () {
		
	}
}
