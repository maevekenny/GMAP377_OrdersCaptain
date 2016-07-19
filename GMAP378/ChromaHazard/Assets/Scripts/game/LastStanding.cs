using UnityEngine;
using System.Collections;

public class LastStanding : MonoBehaviour {

    GameObject[] gos;
    public NewPlayerMovement player;
    
    private bool lastStanding = false;
    private bool bomberman = false;
    DataStorage data;

    // Use this for initialization
    void Start () {
        data = GameObject.Find("DataStorage").gameObject.GetComponent<DataStorage>();

        if (data.gameMode == "Survival")
        {
            lastStanding = true;
        }
        else
        {
            lastStanding = false;
        }


        if (data.gameMode == "Dynamiteman")
        {
            bomberman = true;
        }
        else
        {
            bomberman = false;
        }

    }
	
	// Update is called once per frame
	void Update () {


        if (Application.loadedLevelName == "New_Jungle" || Application.loadedLevelName == "New_Industry" || Application.loadedLevelName == "Canyon")
        {
            gos = GameObject.FindGameObjectsWithTag("Player");

            if (lastStanding) {
                if (gos.Length <= 1)
                {
                    data.lastLevel = Application.loadedLevel;
                    EndGame(gos[0].gameObject.GetComponent<NewPlayerMovement>());

                }
            }

            if (bomberman)
            {
                if (gos.Length <= 1)
                {
                    data.lastLevel = Application.loadedLevel;
                    EndGame(gos[0].gameObject.GetComponent<NewPlayerMovement>());

                }
            }

        }
    }

    public void EndGame(NewPlayerMovement player)
    {
        data.colorVictory = player.GetComponent<SpriteRenderer>().color;
        data.PlayerWinner = player.inputScheme.name;
        Game.Instance.GameOver(player.inputScheme.name);
    }
}
