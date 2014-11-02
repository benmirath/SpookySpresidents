using UnityEngine;
using System.Collections;

public class JumpKill : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public CharacterControllerScript player;
	void OnTriggerEnter2D (Collider2D collision) {
		Debug.Log (collision);
		if (collision.tag == "Enemy") {
//			Debug.Log ("working");

			GameObject.Destroy(collision.gameObject);
			player.rigidbody2D.AddForce(transform.up * player.jumpForce * 1.5f);
		}
	}
}
