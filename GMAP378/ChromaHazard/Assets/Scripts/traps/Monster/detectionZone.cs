using UnityEngine;
using System.Collections;

public class detectionZone : MonoBehaviour {

	public bool inTheZone = false;
	public GameObject player;

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Player") {
			inTheZone = true;
			player = col.gameObject;
		} else {
			inTheZone = false;
		}
	}
}
