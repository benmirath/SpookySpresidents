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
	}

	float bounceTimer = 1.0f;
	float bounceDist = -10.0f;
	float bounceSpeed = .5f;

	public void StartBounce () {
		Debug.Log ("working");
		StartCoroutine (levelBounce());
	}
	public IEnumerator levelBounce () {
		float originalYPos = level.rigidbody2D.position.y;
		float destinationYPos = level.rigidbody2D.position.y - bounceDist;

		Debug.Log (originalYPos);
		Debug.Log (destinationYPos);
		Debug.Log (level.rigidbody2D);

//		level.rigidbody2D.AddForce (new Vector2 (0, -200f), ForceMode2D.Impulse);

		while (level.rigidbody2D.position.y > bounceDist) {
			level.rigidbody2D.MovePosition (new Vector2 (0, level.rigidbody2D.position.y-bounceSpeed));
//			level.rigidbody2D.AddForce (new Vector2 (0, bounceSpeed), ForceMode2D.Impulse);
			Debug.Log(level.rigidbody2D.position);
			yield return new WaitForFixedUpdate();
		}
		while (level.rigidbody2D.position.y < originalYPos) {
			level.rigidbody2D.MovePosition (new Vector2 (0, level.rigidbody2D.position.y+bounceSpeed));
//			level.rigidbody2D.AddForce (new Vector2 (0, bounceSpeed), ForceMode2D.Impulse);
			Debug.Log(level.rigidbody2D.position);
			yield return new WaitForFixedUpdate();
		} 
		yield break;


//		while (level.transform.position.y > bounceDist) {
//			level.transform.position = Vector2.Lerp (new Vector2 (level.transform.position.x, level.transform.position.y), new Vector2 (level.transform.position.x, destinationYPos), bounceSpeed);		
//			yield return null;
//		}
//		while (level.transform.position.y < originalYPos) {
//			level.transform.position = Vector2.Lerp(new Vector2(level.transform.position.x, level.transform.position.y), new Vector2(level.transform.position.x, originalYPos), bounceSpeed);		
//			yield return null;
//		}
		Debug.Log ("Done");
		yield break;
	}

}
