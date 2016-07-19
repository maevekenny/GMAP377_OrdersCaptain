using UnityEngine;
using System.Collections;

public class readyBGchanger : MonoBehaviour {

	public GameObject background;
	public Color readyColor;

	private SpriteRenderer _BGSprite;

	private InteractiveSelection _button;

	public int player; //should only be between 1 and 4

	void Start () {
		_BGSprite = background.GetComponent<SpriteRenderer> ();
		_button = GetComponent<InteractiveSelection> ();
	}

	void Update () {
		if (player == 1 && _button.p1Ready) {
			_BGSprite.color = readyColor;
		} else if (player == 2 && _button.p2Ready) {
			_BGSprite.color = readyColor;
		} else if (player == 3 && _button.p3Ready) {
			_BGSprite.color = readyColor;
		} else if (player == 4 && _button.p4Ready) {
			_BGSprite.color = readyColor;
		} else {
			//do nothing
		}
	}
}
