using UnityEngine;
using System.Collections;

public class Firewheel : MonoBehaviour {

	// Use this for initialization
	public Renderer rend;
	public float rotationSpeed = 1f;
	void Start () {
		StartCoroutine (RidinSpinnahs ());
		GhostScript.OnSecondPower += FlipDir;
	}
	void OnDestroy () {
		GhostScript.OnSecondPower -= FlipDir;
	}
	
	// Update is called once per frame
	IEnumerator RidinSpinnahs () {
		while (true) {
//			rigidbody2D.MoveRotation (rigidbody2D.rotation + rotationSpeed);
			transform.Rotate (0,0,rotationSpeed);
			yield return null;
		}
	}

	void FlipDir () {
		if (rend.isVisible)
			rotationSpeed *= -1;
	}
}
