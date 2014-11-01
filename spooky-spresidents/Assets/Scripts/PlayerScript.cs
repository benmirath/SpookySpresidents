using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {
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

	public CharacterController2D controller;

	// Use this for initialization
	void Awake () {
//		defaultHSpeed = 15;
//		defaultVSpeed = 15;
//		slowedHSpeed = 30;
//		slowedVSpeed = 30;
//		fastHSpeed = 5;
//		fastVSpeed = 5;
	}

	void Start () {
		currentHSpeed = defaultHSpeed;
		currentVSpeed = defaultVSpeed;

		slowedDown = false;
		tractionDown = false;
		jumpDown = false;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float xInput = Input.GetAxis ("Horizontal");
		//float yInput = Input.GetAxis ("Vertical");

		//Directional movement
		if (xInput != 0) {
			if (xInput > 0) {

				controller.move(new Vector3(currentHSpeed, 0, 0));
//				rigidbody2D.AddForce(new Vector2(currentHSpeed,0), ForceMode2D.Impulse);

			} else {
				controller.move(new Vector3(-currentHSpeed, 0, 0));
//				rigidbody2D.AddForce(new Vector2(-currentHSpeed,0), ForceMode2D.Impulse);

			}
		} 

		if (Input.GetButtonDown ("Jump") && controller.isGrounded) {
			rigidbody2D.AddForce(new Vector2(0,5));
		}
	}
}
