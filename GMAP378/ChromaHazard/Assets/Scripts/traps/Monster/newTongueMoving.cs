using UnityEngine;
using System.Collections;

public class newTongueMoving : MonoBehaviour {

	public GameObject player;
	public bool isPlayerGrabbed = false;

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Player") {
			player = col.gameObject;
			isPlayerGrabbed = true;
		} else {
			//isPlayerGrabbed = false;
		}
	}
}
