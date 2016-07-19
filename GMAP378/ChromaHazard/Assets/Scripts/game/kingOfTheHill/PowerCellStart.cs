using UnityEngine;
using System.Collections;

public class PowerCellStart : MonoBehaviour {

    public PowerCellSpawnPos positions;
    public GameObject powerCellPrefab;
    private GameObject powerCell;

	// Use this for initialization
	void Start () {
        if (GameObject.Find("DataStorage").gameObject.GetComponent<DataStorage>().gameMode == "King of The Hill")
        {
            GameObject go = positions.getPowerCellPosition();
            powerCell = (GameObject)Instantiate(powerCellPrefab, go.transform.position, go.transform.rotation);
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
