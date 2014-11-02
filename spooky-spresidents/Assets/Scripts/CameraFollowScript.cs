using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraFollowScript : MonoBehaviour {
	public GameObject target;
	private GameObject[] enemy;
	// Use this for initialization
	void Start () {
//		enemy = GameObject.FindGameObjectsWithTag ("Enemy");
//		foreach ()
	}
	
	// Update is called once per frame
	void Update () {
				/*bg_flip = this.transform.FindChild ("Background").transform.position.z;
		if (!target.GetComponent<CharacterControllerScript> ().facingRight) {
			bg_flip *= -1;
		}
		Debug.Log (bg_flip);*/
		Debug.Log (enemy.Length);
	}
}
