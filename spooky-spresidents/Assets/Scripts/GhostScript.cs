using UnityEngine;
using System.Collections;

public class GhostScript : MonoBehaviour {
	public PlayerScript target;
	public GameObject level;

	public float powerStartup;
	public float power1Cooldown;
	public float power2Cooldown;
	public float power3Cooldown;
	public float power4Cooldown;

	public delegate void FirstPower();
	public static event FirstPower OnFirstPower;
	public delegate void SecondPower();
	public static event SecondPower OnSecondPower;
	public delegate void ThirdPower();
	public static event ThirdPower OnThirdPower;
	public delegate void FourthPower();
	public static event FourthPower OnFourthPower;

	// Use this for initialization
	void Start () {
		OnFirstPower += StartBounce;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Power 1")) {
			OnFirstPower();
		}
		if (Input.GetButtonDown ("Power 2")) {
			OnSecondPower();
		}
	}

	public float bounceTimer = 1.0f;
	public float bounceDist = -5.0f;
	public float bounceSpeed = .25f;

	public void StartBounce () {
		Debug.Log ("working");
		StartCoroutine (levelBounce());
	}
	public IEnumerator levelBounce () {
		float originalYPos = level.rigidbody2D.position.y;
		float destinationYPos = level.rigidbody2D.position.y - bounceDist;

		while (level.rigidbody2D.position.y > bounceDist) {
			level.rigidbody2D.MovePosition (new Vector2 (0, level.rigidbody2D.position.y-bounceSpeed));
			Debug.Log(level.rigidbody2D.position);
			yield return new WaitForFixedUpdate();
		}
		while (level.rigidbody2D.position.y < originalYPos) {
			level.rigidbody2D.MovePosition (new Vector2 (0, level.rigidbody2D.position.y+bounceSpeed));
			Debug.Log(level.rigidbody2D.position);
			yield return new WaitForFixedUpdate();
		} 
		yield break;
		Debug.Log ("Done");
		yield break;
	}
//	public IEnumerator enemyBounce () {
//
//	}

}
