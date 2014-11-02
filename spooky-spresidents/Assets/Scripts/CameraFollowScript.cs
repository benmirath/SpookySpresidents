using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraFollowScript : MonoBehaviour {
	public GameObject target;
	private GameObject[] enemies;
	// Use this for initialization
	void Start () {
//		enemies = GameObject.FindGameObjectsWithTag ("Enemy");

//		foreach (GameObject enemy in enemies) {
//			enemy.SetActive(false);
//		}
	}
	
	// Update is called once per frame
	void Update () {
//		foreach (MonsterController enemy in enemies) {
//			if (enemy.transform.position.x > transform.position.x && 
//			    enemy.transform.position.x < transform.) {
//
//			}
//			enemy.enabled = false;
//		}

				/*bg_flip = this.transform.FindChild ("Background").transform.position.z;
		if (!target.GetComponent<CharacterControllerScript> ().facingRight) {
			bg_flip *= -1;
		}
		Debug.Log (bg_flip);*/
		Debug.Log (enemies.Length);
	}
}
