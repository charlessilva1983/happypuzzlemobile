using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript : MonoBehaviour {

	[Header ("References")]
	public Animator anim;

	[Header ("Stats")]
	public int playerState = 0;
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
		if(Input.GetKey(KeyCode.LeftArrow)){
			playerState = 1;
		} else if(Input.GetKey(KeyCode.RightArrow)){
			playerState = -1;
		}
	}

	private void setAnimationState(){
		if(playerState == 1){
			anim.SetBool("isRightPressed",false);
			anim.SetBool("isLeftPressed",true);
		} else if(playerState == -1){
			anim.SetBool("isLeftPressed",false);
			anim.SetBool("isRightPressed",true);
		}
	}

	public void addPoints(int numPoints){
		this.points += numPoints;
		Debug.Log("Player:: points: "+ points);
	}
}
