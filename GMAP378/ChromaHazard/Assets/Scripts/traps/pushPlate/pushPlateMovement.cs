using UnityEngine;
using System.Collections;

public class pushPlateMovement : MonoBehaviour {

	public GameObject playerDetector;
	private playerDetection _playerDetection;
	private Animation _plateMovement;

	// Use this for initialization
	void Start () {
		_playerDetection = playerDetector.GetComponent<playerDetection> ();
		_plateMovement = GetComponent<Animation> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (_playerDetection.canActivateTrap) {
			_plateMovement.Play ();
		}
	}

	public void unactivateTrap(){
		_playerDetection.canActivateTrap = false;
	}
}
