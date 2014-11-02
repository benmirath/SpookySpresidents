using UnityEngine;
using System.Collections;

public class GhostScript : MonoBehaviour {
	public CharacterControllerScript target;
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
		OnFourthPower += StartSlowdown;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Power 1") || Input.GetButtonDown ("Power 3") || Input.GetButtonDown ("Power 3") || Input.GetButtonDown ("Power 3")) {
					
		}
		if (Input.GetButtonDown ("Power 1") && OnFirstPower != null) {
			OnFirstPower();
		}
		if (Input.GetButtonDown ("Power 2") && OnSecondPower != null) {
			OnSecondPower();
		}
		if (Input.GetButtonDown ("Power 3") && OnThirdPower != null) {
			OnThirdPower();
		}
		if (Input.GetButtonDown ("Power 4") && OnFourthPower != null) {
			OnFourthPower();
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
	}
	float slowdownDuration = 1f;
	void StartSlowdown () {
		StartCoroutine (TimeSlowdown ());
	}
	public IEnumerator TimeSlowdown () {
		float grav = target.rigidbody2D.gravityScale;

		target.rigidbody2D.gravityScale = grav / 5;
		target.timeScale = 0.20f;
		yield return new WaitForSeconds (slowdownDuration);
		target.rigidbody2D.gravityScale = grav;
		target.timeScale = 1f;
		yield break;
	}

//	public IEnumerator enemyBounce () {
//
//	}

}
