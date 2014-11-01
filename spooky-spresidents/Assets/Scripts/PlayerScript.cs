using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {
	public float currentHSpeed;
	public float currentVSpeed;
	public float defaultHSpeed;
	public float defaultVSpeed;
	public float slowedHSpeed;
	public float slowedVSpeed;
	public float fastHSpeed;
	public float fastVSpeed;
	public bool slowedDown;
	public bool tractionDown;
	public bool jumpDown;


	// Use this for initialization
	void Start () {
		defaultHSpeed = 15;
		defaultVSpeed = 15;
		slowedHSpeed = 30;
		slowedVSpeed = 30;
		fastHSpeed = 5;
		fastVSpeed = 5;

		currentHSpeed = defaultHSpeed;
		currentVSpeed = defaultVSpeed;

		slowedDown = false;
		tractionDown = false;
		jumpDown = false;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float xInput = Input.GetAxis ("Horizontal");
		float yInput = Input.GetAxis ("Vertical");

		//Directional movement
		if (xInput != 0) {
			if (xInput > 0) {
				rigidbody2D.AddForce(new Vector2(currentHSpeed,0));

			} else {
				rigidbody2D.AddForce(new Vector2(-currentHSpeed,0));

			}
		} else if (yInput != 0) {
			if (yInput > 0) {

			} else {

			}
		
		}

		if (Input.GetButtonDown ("Jump")) {
//			rigidbody2D.AddForce
		}
	}
}
