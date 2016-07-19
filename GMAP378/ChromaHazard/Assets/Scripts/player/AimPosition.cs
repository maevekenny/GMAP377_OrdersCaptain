using UnityEngine;
using System.Collections;

public class AimPosition : MonoBehaviour {

    public Vector2 position;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        position = this.transform.position;

	}
}
