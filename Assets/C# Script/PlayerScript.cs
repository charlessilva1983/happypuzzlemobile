using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerScript : MonoBehaviour {

	[Header ("References")]
	public Animator bodyAnim;
	public Animator faceAnim;
	public AudioSource playerAudioColision;
	public AudioSource playerAudioOuch;

	[Header ("Stats")]
	public float playerState = -1;
	public Text textScore;
	private int points = 0;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		getPlayerInput ();
		setAnimationState ();
	}

	private void getPlayerInput(){
		if(Input.GetKey(KeyCode.LeftArrow) || CrossPlatformInputManager.GetAxis ("Horizontal") == -1){
			playerState = 1;
		} else if(Input.GetKey(KeyCode.RightArrow) || CrossPlatformInputManager.GetAxis ("Horizontal") == 1){
			playerState = -1;
		}
		Debug.Log("Player:: playerState: "+ playerState);
	}

	private void setAnimationState(){
		if(playerState == 1){
			bodyAnim.SetBool("isRightPressed",false);
			bodyAnim.SetBool("isLeftPressed",true);
		} else if(playerState == -1){
			bodyAnim.SetBool("isLeftPressed",false);
			bodyAnim.SetBool("isRightPressed",true);
		}
	}

	public void addPoints(int numPoints){
		faceAnim.SetBool ("isSad", false);
		faceAnim.SetBool ("isHappy", true);
		this.points = this.points + numPoints;
		textScore.text = this.points.ToString("0000");
		Debug.Log("Player:: points: "+ points);
	}

	public int getPoints(){
		return this.points;
	}

	public void playAudioColision(){
		playerAudioColision.Play();
	}

	public void playAudioOuch(){
		faceAnim.SetBool ("isHappy", false);
		faceAnim.SetBool ("isSad", true);
		playerAudioOuch.Play();
	}
}
