using UnityEngine;
using System.Collections;

public class playerDetection : MonoBehaviour {

	public bool playerDetected;
	public bool canActivateTrap;

	public float waitTime;
	private float initialWaitTime;

	void Start(){
		initialWaitTime = waitTime;
	}

	void Update(){
		if (playerDetected) {
			waitTime -= Time.deltaTime;

			if (waitTime <= 0) {
				canActivateTrap = true;
				waitTime = initialWaitTime;
			}
		}
	}

	void OnTriggerStay2D (Collider2D col){
		if (col.tag == "Player") {
			playerDetected = true;
		}
	}

	void OnTriggerExit2D (Collider2D col){
		if (col.tag == "Player") {
			print ("player left");
			playerDetected = false;
			waitTime = initialWaitTime;
		}
	}
}
