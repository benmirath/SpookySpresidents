﻿using UnityEngine;
using System.Collections;

public class Treadmill : MonoBehaviour {
	bool right = true;
	public float speed;

	// Use this for initialization
	void Start () {
		GhostScript.OnThirdPower += FlipDirection;
	}
	void OnDestroy () {
		GhostScript.OnThirdPower -= FlipDirection;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FlipDirection () {
		right = !right;
	}
	void OnTriggerStay2D (Collider2D collider) {
		float dir = 0;
		if (right) dir = 1;
		else dir = -1;

		if (collider.tag == "Player" || collider.tag == "Enemy") {
			collider.rigidbody2D.AddForce (new Vector2(dir * speed, 0));
		}
	}
}
