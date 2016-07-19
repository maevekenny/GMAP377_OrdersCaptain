using UnityEngine;
using System.Collections;

public class TrapSpeedChanger : MonoBehaviour {

	private TrapSpeedListener listener;
	private float personalSpeedMultiplier = 1;
	private float oldSpeedMultiplier;
	public string trapName;


	private float initialSinkVelocity;
	private float initialArrowVelocity;
	private float initialArrowDelayWaitTime;
	private float initialArrowRespawnWaitTime;
	private float initialGearsRotationSpeed;
	private float initialWarningWaitTime;
	private float initialWarningStartingWaitTime;
	private float initialWarningWarningTime;
	private float initialPushPlateWaitTime;


	// Use this for initialization
	void Start () {
		listener = GameObject.Find ("TrapSpeedListener").GetComponent<TrapSpeedListener> ();
		personalSpeedMultiplier = listener.speedMultiplier;
		oldSpeedMultiplier = personalSpeedMultiplier;

		//get initial values for trap variables
		if (trapName == "log") {
			initialSinkVelocity = GetComponent<LogsMovement> ().sinkVelocity;
		} else if (trapName == "arrow") {
			initialArrowVelocity = GetComponent<ArrowsMovement> ().velocity;
			initialArrowDelayWaitTime = GetComponent<ArrowsMovement> ().DelayWaitTime;
			initialArrowRespawnWaitTime = GetComponent<ArrowsMovement> ().RespawnWaitTime;
		} else if (trapName == "gears") {
			initialGearsRotationSpeed = GetComponent<RotateGears> ().rotationSpeed;
		} else if (trapName == "warning") {
			initialWarningWaitTime = GetComponent<landspeederWarning> ().waitTime;
			initialWarningStartingWaitTime = GetComponent<landspeederWarning> ().initialWaitTime;
			initialWarningWarningTime = GetComponent<landspeederWarning> ().warningTime;
		} else if (trapName == "push") {
			initialPushPlateWaitTime = GetComponent<playerDetection>().waitTime;
		}

	}
	
	// Update is called once per frame
	void Update () {
		personalSpeedMultiplier = listener.speedMultiplier;

		// If the speed multiplier is turned up
		if (oldSpeedMultiplier < personalSpeedMultiplier) {
			if (trapName == "log") {
				GetComponent<LogsMovement> ().sinkVelocity = initialSinkVelocity * personalSpeedMultiplier;
			} else if (trapName == "arrow") {
				GetComponent<ArrowsMovement> ().velocity = initialArrowVelocity * personalSpeedMultiplier;
				GetComponent<ArrowsMovement> ().DelayWaitTime = initialArrowDelayWaitTime / personalSpeedMultiplier;
				GetComponent<ArrowsMovement> ().RespawnWaitTime = initialArrowRespawnWaitTime / personalSpeedMultiplier;
			} else if (trapName == "gears") {
				GetComponent<RotateGears> ().rotationSpeed = initialGearsRotationSpeed * personalSpeedMultiplier;
			} else if (trapName == "sawblade" || trapName == "fire" || trapName == "pressure" || trapName == "rock" || trapName == "bridge") {
				GetComponent<Animator> ().speed = personalSpeedMultiplier;
			} else if (trapName == "warning") {
				GetComponent<landspeederWarning> ().waitTime = initialWarningWaitTime / personalSpeedMultiplier;
				GetComponent<landspeederWarning> ().initialWaitTime = initialWarningStartingWaitTime /  personalSpeedMultiplier;
				GetComponent<landspeederWarning> ().warningTime = initialWarningWarningTime / personalSpeedMultiplier;
			} else if (trapName == "car") {
				GetComponent<Animation>()["landspeeder"].speed = personalSpeedMultiplier;
			} else if (trapName == "push") {
				GetComponent<playerDetection>().waitTime = initialPushPlateWaitTime / personalSpeedMultiplier;
			}
			oldSpeedMultiplier = listener.speedMultiplier;
		}else if (oldSpeedMultiplier > personalSpeedMultiplier) { // If the speed multiplier is turned down
			if (trapName == "log") {
				GetComponent<LogsMovement> ().sinkVelocity = initialSinkVelocity / personalSpeedMultiplier;
			} else if (trapName == "arrow") {
				GetComponent<ArrowsMovement> ().velocity = initialArrowVelocity / personalSpeedMultiplier;
				GetComponent<ArrowsMovement> ().DelayWaitTime = initialArrowDelayWaitTime * personalSpeedMultiplier;
				GetComponent<ArrowsMovement> ().RespawnWaitTime = initialArrowRespawnWaitTime * personalSpeedMultiplier;
			} else if (trapName == "gears") {
				GetComponent<RotateGears> ().rotationSpeed = initialGearsRotationSpeed / personalSpeedMultiplier;
			} else if (trapName == "sawblade" || trapName == "fire" || trapName == "pressure" || trapName == "rock" || trapName == "bridge") {
				GetComponent<Animator> ().speed = personalSpeedMultiplier;
			} else if (trapName == "warning") {
				GetComponent<landspeederWarning> ().waitTime = initialWarningWaitTime * personalSpeedMultiplier;
				GetComponent<landspeederWarning> ().initialWaitTime = initialWarningStartingWaitTime *  personalSpeedMultiplier;
				GetComponent<landspeederWarning> ().warningTime = initialWarningWarningTime * personalSpeedMultiplier;
			} else if (trapName == "car") {
				GetComponent<Animation>()["landspeeder"].speed = personalSpeedMultiplier;
			} else if (trapName == "push") {
				GetComponent<playerDetection>().waitTime = initialPushPlateWaitTime * personalSpeedMultiplier;
			}
			oldSpeedMultiplier = listener.speedMultiplier;
		}
		//end update
	}

}
