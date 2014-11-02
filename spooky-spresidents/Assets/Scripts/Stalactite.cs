﻿using UnityEngine;
using System.Collections;

public class Stalactite : MonoBehaviour {
	public float speed = .5f;
	bool falling = false;

	// Use this for initialization
	void Start () {
		GhostScript.OnThirdPower += TriggerFall;
	}
	
	// Update is called once per frame
	void Update () {
		if (falling) {
			transform.Translate(new Vector3 (0, -speed, 0));
		}
	}
	void TriggerFall () {
		if (renderer.isVisible)
			falling = true;
	}
}