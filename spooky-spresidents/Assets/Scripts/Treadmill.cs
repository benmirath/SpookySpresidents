using UnityEngine;
using System.Collections;

public class Treadmill : MonoBehaviour {
	bool right = true;
	public float speed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerStay2D (Collider2D collider) {
		float dir = 0;

		Debug.Log ("BOOST");

		if (right) dir = 1;
		else dir = -1;

		if (collider.tag == "Player" || collider.tag == "Enemy") {
			Debug.Log ("WOOT");
			collider.rigidbody2D.AddForce (new Vector2(dir * speed, 0));
		}
	}
}
