using UnityEngine;
using System.Collections;

public class newSceneButton : MonoBehaviour {

    public GameObject playerSelect;

	private chromaHazardGUIElement _chromaHazardGUIthing;
	private SpriteRenderer _spriteRenderer;

	// Use this for initialization
	void Start () {
		_chromaHazardGUIthing = GetComponent<chromaHazardGUIElement> ();
		_spriteRenderer = GetComponent<SpriteRenderer> ();
        playerSelect.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		if (_chromaHazardGUIthing._isButtonPressed) {
			_chromaHazardGUIthing._isButtonPressed = false;
            playerSelect.SetActive(true);
		}
	}
}
