using UnityEngine;
using System.Collections;

public class DeadZone : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D collision) {
		Debug.Log (collision);
		if (collision.tag == "Player" || collision.tag == "Enemy")
		GameObject.Destroy (collision.gameObject);
		if (collision.tag == "Player") {
			Application.LoadLevel("TitleScreen");
		}
	}
}
