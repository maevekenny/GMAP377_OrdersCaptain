using UnityEngine;
using System.Collections;

public class characterSelectButton : MonoBehaviour {
	
	public Sprite pressed;
	private bool buttonPressed = false;
	private Sprite original;

	public GameObject readyButton;
	public float readyButtonWaitTime;

	// Use this for initialization
	void Start () {
		original = GetComponent<SpriteRenderer>().sprite;
	}

	void Update () {
		if (buttonPressed) {
			readyButtonWaitTime -= Time.deltaTime;
			if (readyButtonWaitTime <= 0) { 
				readyButton.SetActive (true);
			}
		}
	}
	
	void OnTriggerEnter2D(Collider2D coll)
	{
		if (!buttonPressed && coll.gameObject.CompareTag("Player"))
		{
			readyButton.SetActive (false);
			buttonPressed = true;
			GetComponent<SpriteRenderer>().sprite = pressed;
		}
	}
	 
}
