using UnityEngine;
using System.Collections;

public class levelSelectDisplay : MonoBehaviour {

	public GameObject[] buttons;

	public GameObject controllerNav;
	private controllerNavigation _controllerNav;

	private SpriteRenderer _display;

	public Sprite[] displays;

	private Sprite initialDisplay;

	void Awake () {
		_controllerNav = controllerNav.GetComponent<controllerNavigation> ();

		_display = GetComponent<SpriteRenderer> ();
		initialDisplay = _display.sprite;
	}

	void Update () {
		if (buttons [_controllerNav.location].GetComponent<chromaHazardGUIElement> ().mouseOver) {
			_display.sprite = displays [_controllerNav.location];
		}else {
			_display.sprite = initialDisplay;
		}

	}
}
