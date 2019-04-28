using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceFactoryScript : MonoBehaviour {

	[Header ("Stats")]
	public float startTimeBtwShots;
	private float timeBtwShots;

	[Header ("References")]
	public GameObject[] shot;
	private GameObject newShot;
	//private Transform player = null;
	private int spawnedPieces = 0;

	void Start () {
		//player = GameObject.FindGameObjectWithTag ("Player").transform;
		timeBtwShots = startTimeBtwShots;
		//Debug.Log("PieceFactory:: " + Vector2.Distance (transform.position, player.position));
	}

	void Update () {
		// Makes the enemy shoot !
		if (timeBtwShots <= 0) {
			// Get the first on the list
			newShot = Instantiate(shot[0], transform.position, Quaternion.identity);
			newShot.GetComponent<ShooterObjectScript>().move = true;
			timeBtwShots = startTimeBtwShots;
			// Add to the end of the list
			shot[shot.Length-1] = (newShot);
			spawnedPieces += 1;
			Debug.Log("PieceFactory:: spawnedPieces: "+ spawnedPieces);
		} else {
			timeBtwShots -= Time.deltaTime;
		}
	}

}
