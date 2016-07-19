using UnityEngine;
using System.Collections;

public class SetColorVictory : MonoBehaviour {

    DataStorage data;
    public GameObject bombermanHead;

    // Use this for initialization
    void Start () {
        data = GameObject.Find("DataStorage").gameObject.GetComponent<DataStorage>();
        GetComponent<SpriteRenderer>().color = data.colorVictory;
        GameObject.Find("PlayerText").GetComponent<UnityEngine.UI.Text>().text = data.PlayerWinner;
        if(data.gameMode == "Dynamiteman")
        {
            bombermanHead.active = true;
            bombermanHead.GetComponent<SpriteRenderer>().color = data.colorVictory;
        }
        else
        {
            bombermanHead.active = false;
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
