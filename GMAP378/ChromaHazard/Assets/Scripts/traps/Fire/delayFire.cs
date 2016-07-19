using UnityEngine;
using System.Collections;

public class delayFire : MonoBehaviour {

	public float delayTime;
	private Animator _fireAnimator;

	// Use this for initialization
	void Start () {
		_fireAnimator = GetComponent<Animator> ();
		_fireAnimator.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
			delayTime -= Time.deltaTime;

			if (delayTime <= 0) {
				_fireAnimator.enabled = true;
				enabled = false;
			}
	}
}
