using UnityEngine;
using System.Collections;

public class moveTongueV2 : MonoBehaviour {

	public GameObject detectionBox;
	private detectionZone _detectionObject;

	public GameObject tongue;
	private Rigidbody2D _tongueRigidbody;
	private newTongueMoving _tongueObject; //The class that will let us know if the tongue has grabbed a player or not
	private Vector3 _tongueStartingPos;

	public float tongueMovementSpeedX;
	public float tongueMovementSpeedY;
	public float grabWaitTime; // in seconds
	private float initialGrabWaitTime; // so we can keep it on hand when we need it

	// Use this for initialization
	void Start () {
		_detectionObject = detectionBox.GetComponent<detectionZone> ();
		_tongueRigidbody = tongue.GetComponent<Rigidbody2D> ();
		_tongueObject = tongue.GetComponent<newTongueMoving> ();
		_tongueStartingPos = tongue.transform.position;

		initialGrabWaitTime = grabWaitTime;
	}
	
	// Update is called once per frame
	void Update () {
		if (_detectionObject.inTheZone) {
			//If the monster notices the player, it sends its tongue out after that player
			_tongueRigidbody.velocity = new Vector2 (tongueMovementSpeedX, tongueMovementSpeedY);
		}

		if (_tongueObject.isPlayerGrabbed) {
			//If the tongue grabs the player, stop the tongue, wait an amount of time, then bring the player to the monster
			_tongueObject.player.transform.position = _tongueObject.transform.position;
			_tongueRigidbody.velocity = Vector2.zero;

			grabWaitTime -= Time.deltaTime;
			if (grabWaitTime <= 0) {
				_tongueRigidbody.velocity = new Vector2 (-tongueMovementSpeedX / 2, -tongueMovementSpeedY / 2);

				if (tongue.transform.position.x <= _tongueStartingPos.x) {
					_tongueObject.isPlayerGrabbed = false;
					_tongueRigidbody.velocity = Vector2.zero;
					_tongueObject.transform.position = _tongueStartingPos;
				}

				//grabWaitTime = initialGrabWaitTime;
			}
		}

		//print (tongue.transform.position);
	}
}
