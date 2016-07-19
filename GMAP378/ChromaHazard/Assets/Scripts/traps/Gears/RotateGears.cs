using UnityEngine;
using System.Collections;

public class RotateGears : MonoBehaviour {

	public bool rotatingClockwise;
	public float rotationSpeed = 1;

	public GameObject countdown;

	void Update () {
		if (!countdown.activeSelf) {
			if (rotatingClockwise) {
				this.gameObject.transform.Rotate (new Vector3 (0f, 0f, -rotationSpeed));
			} else {
				this.gameObject.transform.Rotate (new Vector3 (0f, 0f, rotationSpeed));
			}
		}
		//end thing
	}
}
