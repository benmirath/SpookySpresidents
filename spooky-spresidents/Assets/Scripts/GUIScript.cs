using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GUIScript : MonoBehaviour {
	private float cool_a = 1f;
	private bool HasUsedPower = false;
	public string InputKey;
	public float CooldownLength;
	public Image cooldown;

	public float curHP = 100f;
	public float maxHP = 150f;
	private bool Alive = true;

	private float testTime, startTime;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (this.name == "Life Seal") {
			cooldown.fillAmount = curHP / maxHP;
			if (Input.GetKeyUp (InputKey)){
				curHP -= 10f;
			}
			if (curHP < 0){
				Alive = false;
			}
		} else {
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
		}
		Debug.Log (Alive);
	}
}
