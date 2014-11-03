using UnityEngine;
using System.Collections;

public class MovingPlatform : MonoBehaviour {
	bool right = true;
	public Transform limiterRight;
	public Transform limiterLeft;
	public float idleTimer;
	public float speed;


	// Use this for initialization
	void Start () {
		StartCoroutine (Movement ());

		GhostScript.OnThirdPower += FlipDir;
	}
	void OnDestroy () {
		GhostScript.OnThirdPower -= FlipDir;
	}
	IEnumerator Movement () {
		while (true) {
			int dir;
			if (right) {
				if (transform.position.x < limiterRight.position.x) {
					//walk right
					dir = 1;
				} else {
					dir = 0;
					right = false;
					rigidbody2D.velocity = Vector2.zero;
					yield return new WaitForSeconds (idleTimer);
				}
			} else {
				if (transform.position.x > limiterLeft.position.x) {
					//walk right
				    dir = -1;
				} else {
					dir = 0;
					right = true;
					rigidbody2D.velocity = Vector2.zero;
					yield return new WaitForSeconds (idleTimer);
				}
			}
			rigidbody2D.velocity = new Vector2 (dir * speed, rigidbody2D.velocity.y);
			yield return null;		
		}
	}

	void FlipDir () {
		if (renderer.isVisible)
			right = !right;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
