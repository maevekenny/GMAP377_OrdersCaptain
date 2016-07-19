using UnityEngine;
using System.Collections;

public class counterTimer : MonoBehaviour {

	private SpriteRenderer _warningSign;
	private landspeederWarning _warningScript;
	private SpriteRenderer _counterSprite;

	// Use this for initialization
	void Start () {
		_warningSign = GameObject.Find("Warning").GetComponent<SpriteRenderer> ();
		_warningScript = GameObject.Find ("Warning").GetComponent <landspeederWarning> ();
		_counterSprite = GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (_warningSign.enabled) {
			_counterSprite.enabled = true;
		} else {
			_counterSprite.enabled = false;
		}

		if (_warningScript.canSendSpeeders) {
			Destroy (this.gameObject);
		}
	}
}
