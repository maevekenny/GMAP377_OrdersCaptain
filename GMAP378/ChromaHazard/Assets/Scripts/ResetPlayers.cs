using UnityEngine;
using System.Collections;

public class ResetPlayers : MonoBehaviour {

    DataStorage data;

	// Use this for initialization
	void Start () {
        data = GameObject.Find("DataStorage").gameObject.GetComponent<DataStorage>();
        data.playerOn[0] = false;
        data.playerOn[1] = false;
        data.playerOn[2] = false;
        data.playerOn[3] = false;

        data.color[0] = Color.blue;
        data.color[1] = Color.blue;
        data.color[2] = Color.blue;
        data.color[3] = Color.blue;

        
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
