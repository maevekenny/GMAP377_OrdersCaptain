using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class selectScreenCountdown : MonoBehaviour {

	public GameObject playersController;
	private PressStart _playersController;

	public float countdown;
	private Text _text;

	// Use this for initialization
	void Start () {
		_playersController = playersController.GetComponent<PressStart> ();
		_text = GetComponent<Text> ();
		countdown = _playersController.loadLevelDelay;
	}
	
	// Update is called once per frame
	void Update () {
		if (_playersController.isLoadingLevel) {
			countdown -= Time.deltaTime;
		}

		if (countdown < 3 && countdown >= 2) {
			_text.text = "Moving to Level Select Screen in 3...";
			_text.color = Color.red;
		}else if (countdown < 2 && countdown >= 1) {
			_text.text = "Moving to Level Select Screen in 2...";
			_text.color = Color.red;
		}else if (countdown < 1 && countdown >= 0) {
			_text.text = "Moving to Level Select Screen in 1...";
			_text.color = Color.red;
		}
	}
}
