using UnityEngine;
using System.Collections;

public class landspeederWarning : MonoBehaviour {

	public float waitTime;
	[HideInInspector]public float initialWaitTime;

	public float warningTime; //How long the WARNING should flash for
	public float warningFlashTime;
	private float initialWarningFlashTime;

	public GameObject carCounter;
	public int carCount;
	private int countersSpawned = 0;

	private SpriteRenderer _sprite;
	private Animator _warningFlash;

	public bool canSendSpeeders = false;

	// Use this for initialization
	void Start () {
		initialWaitTime = waitTime;
		initialWarningFlashTime = warningFlashTime;

		_sprite = GetComponent<SpriteRenderer> ();
		if (_sprite.enabled) {
			_sprite.enabled = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		waitTime -= Time.deltaTime;

		if (waitTime <= warningTime && waitTime >= 0) {

			spawnCounters ();

			warningFlashTime -= Time.deltaTime;

			if (warningFlashTime <= 0) {
				if (_sprite.enabled) {
					_sprite.enabled = false;
				} else {
					_sprite.enabled = true;
				}

				warningFlashTime = initialWarningFlashTime;
			}
		} else if (waitTime <= 0) {
			canSendSpeeders = true;
			_sprite.enabled = false;
			countersSpawned = 0;
			waitTime = initialWaitTime;
		}
			
	}

	void spawnCounters(){
		if (carCount <= 0) {
			carCount = 1;
		}
			
		if (countersSpawned != carCount) {
			GameObject newCounter = Instantiate(carCounter) as GameObject;
			newCounter.transform.parent = this.gameObject.transform;
			newCounter.transform.localPosition = new Vector2 (9f - countersSpawned, -2.75f);
			newCounter.transform.localScale = new Vector2 (.23f, .23f);
			countersSpawned++;
		}
	}
}
