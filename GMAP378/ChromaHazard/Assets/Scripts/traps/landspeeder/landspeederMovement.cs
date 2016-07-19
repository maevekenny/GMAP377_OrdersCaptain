using UnityEngine;
using System.Collections;

public class landspeederMovement : MonoBehaviour {

	private landspeederWarning _warningScript;
	private Animation _speederMovement;

	public GameObject followingCar;
	public bool allCarsSpawned;

	private int carsSpawned = 0;

	// Use this for initialization
	void Start () {
		_warningScript = GameObject.Find ("Warning").GetComponent<landspeederWarning> ();
		_speederMovement = GetComponent<Animation> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (_warningScript.canSendSpeeders) {
			for (int i = 1; i <= _warningScript.carCount; i++)
			{
				if (carsSpawned <= _warningScript.carCount - 1) {
					carsSpawned++;
					GameObject newFollowingCar = Instantiate (followingCar) as GameObject;
					newFollowingCar.transform.parent = this.gameObject.transform;
					newFollowingCar.transform.localPosition = new Vector2 (i * 0.2f, 0f);
					newFollowingCar.transform.localScale = new Vector2 (1f, 1f);
				}
			}
			_speederMovement.Play ();
		}
	}

	public void cannotSendSpeeders(){
		_warningScript.canSendSpeeders = false;
		carsSpawned = 0;
	}

}
