using UnityEngine;
using System.Collections;

public class Firejet : MonoBehaviour {
	float startPoint = 50f;
	float endPoint = -50f;
	public float extendDist = 100;
	public float extendSpeed = 2f;

	// Use this for initialization
	void Start () {
		GhostScript.OnThirdPower += StartJet;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void StartJet () {
		if (renderer.isVisible)
			StartCoroutine (TriggerJet());
	}

	IEnumerator TriggerJet () {
		float originalYPos = rigidbody2D.position.y;
		float destinationYPos = originalYPos - extendDist;
		
		while (rigidbody2D.position.y > destinationYPos) {
			transform.Translate (new Vector3 (-extendSpeed, 0, 0));
			yield return new WaitForFixedUpdate();
		}
		while (rigidbody2D.position.y < originalYPos+ 20f) {
			transform.Translate (new Vector3 (extendSpeed, 0, 0));
			yield return new WaitForFixedUpdate();
		} 
		yield break;
	}
}
