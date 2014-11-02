using UnityEngine;
using System.Collections;

public class Firejet : MonoBehaviour {
	float startPoint = 50f;
	float endPoint = -50f;
	float extendDist = 100;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator TriggerJet () {
		float originalYPos = rigidbody2D.position.y;
		float destinationYPos = originalYPos - extendDist;
		
//		while (level.rigidbody2D.position.y > bounceDist) {
//			level.rigidbody2D.MovePosition (new Vector2 (0, level.rigidbody2D.position.y-bounceSpeed));
//			Debug.Log(level.rigidbody2D.position);
//			yield return new WaitForFixedUpdate();
//		}
//		while (level.rigidbody2D.position.y < originalYPos) {
//			level.rigidbody2D.MovePosition (new Vector2 (0, level.rigidbody2D.position.y+bounceSpeed));
//			Debug.Log(level.rigidbody2D.position);
//			yield return new WaitForFixedUpdate();
//		} 
		yield break;
	}
}
