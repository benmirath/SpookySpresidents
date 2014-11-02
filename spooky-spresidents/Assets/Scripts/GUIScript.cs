using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GUIScript : MonoBehaviour {
	private float cool_a = 1f;
	public bool HasUsedPower = false;
	public string Power;
	public string InputKey;
	public float CooldownLength;
	public Image cooldown;

	public bool test = false;
	private float testTime, startTime;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		cooldown.color = new Color (1f, 1f, 1f, cool_a);
		if (Input.GetKeyUp (InputKey) && !HasUsedPower) {
				cool_a = 0.75f;
				testTime = Time.time + CooldownLength;
				startTime = Time.time;
				HasUsedPower = true;
				Debug.Log (Time.time + " / " + testTime);
		}

		cooldown.fillAmount = 1 - (Time.time - startTime) / (testTime - startTime);

		if (Time.time > testTime) {
				cool_a = 0f;
				HasUsedPower = false;
		}

		if (test){
			Debug.Log (cooldown.fillAmount);
		}
	}
}
