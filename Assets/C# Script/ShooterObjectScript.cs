using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterObjectScript : MonoBehaviour {

	[Header ("Stats")]
	public float speed;
	public bool move = false;
	public Animator anim;
	public GameObject particle;

	[Header ("References")]
	private Transform player;
	private Vector2 target;
	private int pieceState = 0;

	void Start () {
		pieceState = Random.Range(0, 2);
		Debug.Log("ShooterObject:: pieceState ="+pieceState);
		if (anim == null) {
			anim = GameObject.Find ("OtherBody").GetComponent<Animator>();
			Debug.Log("ShooterObject:: Obeve o animator do OtherBody");
		}
		if (pieceState == 0) {
			pieceState = -1;
			anim.SetBool ("isRight", false);
			anim.SetBool ("isLeft", true);
		} else {
			anim.SetBool("isLeft", false);
			anim.SetBool ("isRight", true);
		}
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		target = new Vector2 (player.position.x, player.position.y);

	}

	void FixedUpdate () {
		if (move) {
			transform.position = Vector2.MoveTowards (transform.position, target, speed * Time.deltaTime);
			if (transform.position.x == target.x && transform.position.y == target.y) {
				//DestroyProjectile ();
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.CompareTag ("Player")) {
			PlayerScript ps = player.GetComponent<PlayerScript> ();
			Debug.Log("ShooterObject:: playerState: "+ ps.playerState + " / pieceState: " + pieceState);
			if ((ps.playerState + this.pieceState) == 0) {
				ps.addPoints (1);
				Debug.Log ("ShooterObject:: Score: " + ps.getPoints ());
			} else {
				ps.playAudioOuch();
			}
			ps.playAudioColision();
			GameObject particle_ = Instantiate(particle, transform.position, transform.rotation);
			Destroy(particle_.gameObject, 1.2f);
			DestroyProjectile();
		}
	}

	void DestroyProjectile(){
		Destroy (gameObject);
	}
}
