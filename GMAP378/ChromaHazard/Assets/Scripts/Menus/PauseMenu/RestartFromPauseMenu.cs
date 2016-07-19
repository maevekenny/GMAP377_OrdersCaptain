using UnityEngine;
using System.Collections;

public class RestartFromPauseMenu : MonoBehaviour {

	private chromaHazardGUIElement _chromaHazardGUIthing;
	private int levelToLoad;

	// Use this for initialization
	void Start () {
		_chromaHazardGUIthing = GetComponent<chromaHazardGUIElement> ();
		levelToLoad = Application.loadedLevel;
	}
	
	// Update is called once per frame
	void Update () {
		if (_chromaHazardGUIthing._isButtonPressed) {
			_chromaHazardGUIthing._isButtonPressed = false;
			Application.LoadLevel(levelToLoad);
		}
	}
}
