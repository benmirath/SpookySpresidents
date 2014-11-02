using UnityEngine;
using System.Collections;

public class MonsterController : MonoBehaviour {
	public enum EnemyType {
		Gommba,
		BulletBob
	}
	public EnemyType enemyType;
//	public float defaultHSpeed;
//	public float defaultVSpeed;
	public float idleTimer = 3f;
	private float currentHSpeed;
	private float currentVSpeed;

	public Transform waypointLeft;
	public Transform waypointRight;

	public bool slowedDown;
	public bool tractionDown;
	public bool jumpDown;
	bool alive = true;
	
	public SkeletonAnimation animation;
	
	public float maxSpeed = 10f;
	public bool facingRight = true;
	//Animator anim;
	BoxCollider2D hitBox;
	
	bool crouching = false;
	bool grounded = false;
	public Transform groundCheck;
	float groundRadius = 0.2f;
	public LayerMask whatIsGround;
	
	public int jumpCount = 2;
	int jumpCountStore;
	//	public float jumpForce = 500f;
	public float jumpForce = 6f;
	
	// Use this for initialization
	void Start (){
		//Get the animator connected to this object
		//anim = GetComponent<Animator> ();
//		currentHSpeed = defaultHSpeed;
//		currentVSpeed = defaultVSpeed;
		
		slowedDown = false;
		tractionDown = false;
		jumpDown = false;
		
		hitBox = GetComponent<BoxCollider2D> ();
		jumpCountStore = jumpCount;
		if (enemyType == EnemyType.Gommba) {
			StartCoroutine (PatrolRoute ());
		} else {
			Animation anim = GetComponent<Animation>();
//			anim.playAutomatically = true;
			anim.Play();

			Debug.Log (anim);
		}
//		GhostScript ghost = GameObject.FindGameObjectWithTag ("Ghost").GetComponent<GhostScript>();
		GhostScript.OnSecondPower += Possession;
	}

	bool walkRight = true;
	IEnumerator PatrolRoute () {
		while (alive && renderer.isVisible) {
			if (walkRight) {
				if (transform.position.x < waypointRight.position.x) {
					//walk right
					currentHSpeed = 1;
				} else {
					currentHSpeed = 0;
					walkRight = false;
					yield return new WaitForSeconds (idleTimer);
				}
			} else {
				if (transform.position.x > waypointLeft.position.x) {
					//walk right
					currentHSpeed = -1;
				} else {
					currentHSpeed = 0;
					walkRight = true;
					yield return new WaitForSeconds (idleTimer);
				}
			}
			yield return null;		
		}
	}

	
	void FixedUpdate () {
		//Set the boolean "Ground" based on the small Vector3 called groundCheck, that will toggle based on whatever is or isn't ground
		if (alive && renderer.isVisible) {
			grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);
			//anim.SetBool ("Ground", grounded);
			
			//If I'm on the ground, reset my available jumps back to the default
			if (grounded) {
				jumpCount = jumpCountStore;
			}

			//Move our character ten times our move input
			if (enemyType == EnemyType.BulletBob) {
				currentHSpeed = -1;
			}

			if (!crouching && renderer.isVisible) {
				Debug.Log ("flying: "+enemyType);
				Debug.Log (rigidbody2D.velocity);
				rigidbody2D.velocity = new Vector2 (currentHSpeed * maxSpeed, rigidbody2D.velocity.y);
				if (rigidbody2D.velocity != Vector2.zero && enemyType == EnemyType.Gommba) {
					animation.AnimationName = "Walking";					
				} else if (enemyType == EnemyType.Gommba) {
					animation.AnimationName = "Idle";
				}
				hitBox.enabled = true;
			} else {
				hitBox.enabled = false;
			}
			
			if (currentVSpeed < 0) {
				crouching = true;
			} else {
				crouching = false;
			}
			
			//If we are moving and facing left, flip; Or if we are not moving and facing right, flip
			if (currentHSpeed > 0 && facingRight) {
				Flip ();
			} else if (currentHSpeed < 0 && !facingRight) {
				Flip ();
			}
		}
	}

	public CircleCollider2D rocketExplosion;
	public ParticleSystem rocketExplosionParticle;
	IEnumerator Explosion () {
		float timer = rocketExplosionParticle.duration;
		rocketExplosion.enabled = true;
		rocketExplosionParticle.Play ();
		yield return new WaitForSeconds (timer);
		rocketExplosion.enabled = false;
		Die ();
		yield break;

	}
	void Possession () {
		if (renderer.isVisible) {
			if (enemyType == EnemyType.Gommba) {
				rigidbody2D.AddForce (transform.up * jumpForce);
			} else {
				StartCoroutine (Explosion ());
			}
		}
	}
	
	void Die () {
		GameObject.Destroy (gameObject);
	}

	//Manages Left/Right facing
	void Flip() {
		//I am now not facing the opposite way
		facingRight = !facingRight;
		//Make a temp. Vector3 based on this object's scale
		Vector3 theScale = transform.localScale;
		//Flip the X axis by -1
		theScale.x *= -1;
		//Reapply the new theScale to this object's scale
		transform.localScale = theScale;
	}
}
