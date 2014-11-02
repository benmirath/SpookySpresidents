using UnityEngine;
using System.Collections;

public class CameraFollowScript : MonoBehaviour {
	public GameObject target;
	public float bg_flip;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		bg_flip = this.transform.FindChild ("Background").transform.position.z;
		if (!target.GetComponent<CharacterControllerScript> ().facingRight) {
			bg_flip *= -1;
		}
		Debug.Log (bg_flip);
	}
}
