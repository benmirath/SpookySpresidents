using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter2D (Collider2D collision) {
		Debug.Log (collision);
		if (collision.tag == "Player") {
			GameObject.Destroy (collision.gameObject);
			Application.LoadLevel("TitleScreen");
		}
	}
}
