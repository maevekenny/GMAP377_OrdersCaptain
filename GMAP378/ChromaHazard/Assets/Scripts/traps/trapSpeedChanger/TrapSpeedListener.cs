using UnityEngine;
using System.Collections;

public class TrapSpeedListener : MonoBehaviour {

	//This script is going to exist in every level,
	//and whatever is going to change the speed of the traps in the game
	//will do so by changing this variable. The TrapSpeedChanger script
	//will be attached to traps, and they'll all look for this variable and act accordingly.
	public float speedMultiplier;

	public float speedIncrease;

	public float timeInterval;
	private float initialTimeInterval;

	void Start () {
		initialTimeInterval = timeInterval;
	}

	void Update () {
		timeInterval -= Time.deltaTime;

		if (timeInterval <= 0) {
			speedMultiplier += speedIncrease;
			timeInterval = initialTimeInterval;
		}
	}
}
