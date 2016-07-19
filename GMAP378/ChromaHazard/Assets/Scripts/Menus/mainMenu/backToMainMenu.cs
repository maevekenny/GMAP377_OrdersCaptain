using UnityEngine;
using System.Collections;



public class backToMainMenu: MonoBehaviour {

    public bool loadLastScene = false;

	//This script also works for the "Return to Main Menu"
	//button in the KinectCheck scene.

	public int sceneToLoad;

	private chromaHazardGUIElement _chromaHazardGUIthing;
	private SpriteRenderer _spriteRenderer;

	// Use this for initialization
	void Start () {
		_chromaHazardGUIthing = GetComponent<chromaHazardGUIElement> ();
		_spriteRenderer = GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (_chromaHazardGUIthing._isButtonPressed) {
			_chromaHazardGUIthing._isButtonPressed = false;
            if (!loadLastScene)
            {
                Application.LoadLevel(sceneToLoad);
            }
            else
            {
                Application.LoadLevel(GameObject.Find("DataStorage").GetComponent<DataStorage>().lastLevel);
            }
		}
	}

    public void LoadScene()
    {
        Application.LoadLevel(sceneToLoad);
    }
}
