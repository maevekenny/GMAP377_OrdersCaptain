using UnityEngine;
using System.Collections;

public class carTimer : MonoBehaviour {

	private landspeederWarning _warningScript;

	void Start () {
		_warningScript = GameObject.Find ("Warning").GetComponent <landspeederWarning> ();
	}

	void Update () {
		if (!_warningScript.canSendSpeeders) {
			Destroy (this.gameObject);
		}
	}
}
