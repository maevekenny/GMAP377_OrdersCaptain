using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerInfoDisplay : MonoBehaviour {

    // TODO: Break player data out of PlayerController class and into own Player class
    public PlayerController player;

    // TODO: Have players be namable
    public Text playerName;
    // TODO: Show player deaths in a better way than numbers, with icons?
    public Text playerDeaths;
    
    // Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        playerDeaths.text = "" + player.Deaths;
	}
}
