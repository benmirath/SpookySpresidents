using UnityEngine;
using System.Collections;

public class CameraFollowScript : MonoBehaviour {
	public GameObject target;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (target.GetComponent<CharacterControllerScript> ().facingRight);
	}
}
