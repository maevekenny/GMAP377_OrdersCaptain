using UnityEngine;
using System.Collections;

public class exitGame : MonoBehaviour {

	private chromaHazardGUIElement _chromaHazardGUIthing;

	// Use this for initialization
	void Start () {
		_chromaHazardGUIthing = GetComponent<chromaHazardGUIElement> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (_chromaHazardGUIthing._isButtonPressed) {
			_chromaHazardGUIthing._isButtonPressed = false;

			Application.Quit();
			print ("quit game");

		}
	}
}
