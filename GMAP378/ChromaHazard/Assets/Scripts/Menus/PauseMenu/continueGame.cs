using UnityEngine;
using System.Collections;

public class continueGame : MonoBehaviour {

	public GameObject pauseControllerObject;

	private chromaHazardGUIElement _continue;
	private PauseController _pauseController;

	// Use this for initialization
	void Start () {
		_pauseController = pauseControllerObject.GetComponent<PauseController> ();
		_continue = GetComponent<chromaHazardGUIElement> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (_continue._isButtonPressed) {
			_pauseController.unpause ();
		}
	}
}
