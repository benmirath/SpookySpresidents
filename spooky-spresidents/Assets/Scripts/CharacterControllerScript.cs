﻿using UnityEngine;
using System.Collections;

public class CharacterControllerScript : MonoBehaviour {
	private float currentHSpeed;
	private float currentVSpeed;
	public float defaultHSpeed;
	public float defaultVSpeed;
	public float slowedHSpeed;
	public float slowedVSpeed;
	public float fastHSpeed;
	public float fastVSpeed;
	public bool slowedDown;
	public bool tractionDown;
	public bool jumpDown;

	public float maxSpeed = 10f;
	bool facingRight = true;
	//Animator anim;
	BoxCollider2D hitBox;
	
	bool crouching = false;
	bool grounded = false;
	public Transform groundCheck;
	float groundRadius = 0.2f;
	public LayerMask whatIsGround;

	public float jumpCount = 2f;
	float jumpCountStore;
	public float jumpForce = 500f;

	// Use this for initialization
	void Start (){
		//Get the animator connected to this object
		//anim = GetComponent<Animator> ();
		currentHSpeed = defaultHSpeed;
		currentVSpeed = defaultVSpeed;
		
		slowedDown = false;
		tractionDown = false;
		jumpDown = false;

		hitBox = GetComponent<BoxCollider2D> ();
		jumpCountStore = jumpCount;
	}

	void FixedUpdate () {
		//Set the boolean "Ground" based on the small Vector3 called groundCheck, that will toggle based on whatever is or isn't ground
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);
		//anim.SetBool ("Ground", grounded);

		//If I'm on the ground, reset my available jumps back to the default
		if (grounded) {
			jumpCount = jumpCountStore;
		}

		//Set the vSpeed value in our animator based on our upward velocity
		//anim.SetFloat ("vSpeed", rigidbody2D.velocity.y);

		/*
			//Use this if you want to have no air control during jumps
			if (!grounded) return;
		*/

		//Get a new float based on our Horizontal movement input
		currentHSpeed = Input.GetAxis ("Horizontal");
		currentVSpeed = Input.GetAxis ("Vertical");
		//Set the Speed value in our animator based on the move float
		//anim.SetFloat ("Speed", Mathf.Abs (move));
		//anim.SetFloat ("cSpeed", move_v);

		//Move our character ten times our move input
		if (!crouching) {
			rigidbody2D.velocity = new Vector2 (currentHSpeed * maxSpeed, rigidbody2D.velocity.y);
			hitBox.enabled = true;
		} else {
			hitBox.enabled = false;
		}

		if (currentVSpeed < 0) {
			crouching = true;
		} else {
			crouching = false;
		}

		//If we are moving and facing left, flip; Or if we are not moving and facing right, flip
		if (currentHSpeed > 0 && !facingRight) {
			Flip();
		} else if (currentHSpeed < 0 && facingRight) {
			Flip();
		}
	}

	void Update(){
		if ((grounded || jumpCount > 1) && Input.GetButtonDown("Jump")) {
			//anim.SetBool ("Ground", grounded);
			rigidbody2D.AddForce (new Vector2 (0, jumpForce));
			jumpCount -= 1;
		}
	}

	//Manages Left/Right facing
	void Flip() {
		//I am now not facing the opposite way
		facingRight = !facingRight;
		//Make a temp. Vector3 based on this object's scale
		Vector3 theScale = transform.localScale;
		//Flip the X axis by -1
		theScale.x *= -1;
		//Reapply the new theScale to this object's scale
		transform.localScale = theScale;
	}
}
