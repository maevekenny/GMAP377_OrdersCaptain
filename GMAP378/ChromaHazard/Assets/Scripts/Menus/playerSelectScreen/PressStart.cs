using UnityEngine;
using System.Collections;

public class PressStart : MonoBehaviour {
    public int numberOfPlayers = 0;
    public int numberOfPlayersReady = 0;

    public GameObject buttonP1;
    public GameObject buttonP2;
    public GameObject buttonP3;
    public GameObject buttonP4;

    NewPlayerMovement p1;
    NewPlayerMovement p2;
    NewPlayerMovement p3;
    NewPlayerMovement p4;

    public SpawnPlayer[] spawns;
    public GameObject[] pressToJoinIcons;
    public Color[] playerColors;

    public string levelToLoad;
    public float loadLevelDelay;
	public bool isLoadingLevel = false;

    private bool start;
    private int[] currentPlayerColor;
    private bool[] playerJoined;

    // Use this for initialization
    void Start () {
        
        if (spawns.Length != 4)
        {
            Debug.Log("WARNING: There must be 4 player spawns set up.");
        }
        playerJoined = new bool[4];
        currentPlayerColor = new int[4];
	}

    IEnumerator LaunchLevel()
    {
		isLoadingLevel = true;
        yield return new WaitForSeconds(loadLevelDelay);
        Application.LoadLevel(levelToLoad);
    }

    public void ChangeColor_Player_1_Left()
    {
        cyclePlayerColor(false, 0);
    }

    public void ChangeColor_Player_1_Right()
    {
        cyclePlayerColor(true, 0);
    }

    public void ChangeColor_Player_2_Left()
    {
        cyclePlayerColor(false, 1);
    }

    public void ChangeColor_Player_2_Right()
    {
        cyclePlayerColor(true, 1);
    }

    public void ChangeColor_Player_3_Left()
    {
        cyclePlayerColor(false, 2);
    }

    public void ChangeColor_Player_3_Right()
    {
        cyclePlayerColor(true, 2);
    }

    public void ChangeColor_Player_4_Left()
    {
        cyclePlayerColor(false, 3);
    }

    public void ChangeColor_Player_4_Right()
    {
        cyclePlayerColor(true, 3);
    }

    private void cyclePlayerColor(bool up, int player)
    {
        if (up)
        {
            currentPlayerColor[player]++;
            currentPlayerColor[player] %= playerColors.Length;
        }
        else
        {
            currentPlayerColor[player]--;
            if (currentPlayerColor[player] < 0)
                currentPlayerColor[player] = playerColors.Length - 1;
        }
        spawns[player].getPlayerSpawned().GetComponent<SpriteRenderer>().color = playerColors[currentPlayerColor[player]];
        spawns[player].getPlayerSpawned().GetComponent<NewPlayerMovement>().playerNumberSprite.GetComponent<SpriteRenderer>().color = playerColors[currentPlayerColor[player]];
        spawns[player].getPlayerSpawned().GetComponent<NewPlayerMovement>().letterP.GetComponent<SpriteRenderer>().color = playerColors[currentPlayerColor[player]];
    }

	// Update is called once per frame
	void Update () {
        if(numberOfPlayers != 0 && numberOfPlayers == numberOfPlayersReady)
        {
            if (!start)
            {
                start = true;

                for (int i = 0; i < spawns.Length; i++)
                {
                    if (spawns[i].gameObject.active)
                    {
                        InputScheme scheme = spawns[i].getPlayerSpawned().GetComponent<NewPlayerMovement>().inputScheme;
                        scheme.color = playerColors[currentPlayerColor[i]];
                        GameObject.Find("DataStorage").gameObject.GetComponent<DataStorage>().color[i] = playerColors[currentPlayerColor[i]];

                        //Game.Instance.AddPlayer(i, "Player " + i, Color.red, scheme);
                    }
                }

                StartCoroutine(LaunchLevel());
            }
        }

        if (Input.GetKeyDown(KeyCode.Joystick1Button0))
        {
            if (!playerJoined[0])
            {
                if(p1 != null)
                {
                    p1.gameObject.active = true;
                    p1.transform.position = spawns[0].transform.position;
                }
                GameObject.Find("DataStorage").gameObject.GetComponent<DataStorage>().playerOn[0] = true;
                playerJoined[0] = true;
                numberOfPlayers++;
                spawns[0].gameObject.active = true;
                pressToJoinIcons[0].gameObject.active = false;
                //Spawn_1.active = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (!playerJoined[1])
            {
                if (p2 != null)
                {
                    p2.gameObject.active = true;
                    p2.transform.position = spawns[1].transform.position;
                }
                GameObject.Find("DataStorage").gameObject.GetComponent<DataStorage>().playerOn[1] = true;
                playerJoined[1] = true;
                numberOfPlayers++;
                spawns[1].gameObject.active = true;
                pressToJoinIcons[1].gameObject.active = false;
                //Spawn_2.active = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.Joystick2Button0))
        {
            if (!playerJoined[2])
            {
                if (p3 != null)
                {
                    p3.gameObject.active = true;
                    p3.transform.position = spawns[2].transform.position;
                }
                GameObject.Find("DataStorage").gameObject.GetComponent<DataStorage>().playerOn[2] = true;
                playerJoined[2] = true;
                numberOfPlayers++;
                spawns[2].gameObject.active = true;
                pressToJoinIcons[2].gameObject.active = false;
            }
            //Spawn_3.active = true;
        }
        if (Input.GetKeyDown(KeyCode.Joystick3Button0))
        {
            if (!playerJoined[3])
            {
                if (p4 != null)
                {
                    p4.gameObject.active = true;
                    p4.transform.position = spawns[3].transform.position;
                }
                GameObject.Find("DataStorage").gameObject.GetComponent<DataStorage>().playerOn[3] = true;
                playerJoined[3] = true;
                numberOfPlayers++;
                spawns[3].gameObject.active = true;
                pressToJoinIcons[3].gameObject.active = false;
                //Spawn_4.active = true;
            }
        }


        if (Input.GetKeyDown(KeyCode.Joystick1Button1))
        {
            if (playerJoined[0])
            {
                GameObject.Find("DataStorage").gameObject.GetComponent<DataStorage>().playerOn[0] = false;
                playerJoined[0] = false;
                numberOfPlayers--;
                spawns[0].gameObject.active = false;
                pressToJoinIcons[0].gameObject.active = true;
                GameObject[] gos = GameObject.FindGameObjectsWithTag("Player");
                for (int i = 0; i < gos.Length; i++)
                {
                    if (gos[i].gameObject.GetComponent<NewPlayerMovement>().inputScheme.name == "Player 1")
                    {
                        p1 = gos[i].GetComponent<NewPlayerMovement>();
                        p1.gameObject.active = false;
                        buttonP1.GetComponent<InteractiveSelection>().Reset("Player 1");
                    }

                }

                //Spawn_1.active = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (playerJoined[1])
            {
                GameObject.Find("DataStorage").gameObject.GetComponent<DataStorage>().playerOn[1] = false;
                playerJoined[1] = false;
                numberOfPlayers--;
                spawns[1].gameObject.active = false;
                pressToJoinIcons[1].gameObject.active = true;
                //Spawn_2.active = true;
                GameObject[] gos = GameObject.FindGameObjectsWithTag("Player");
                for (int i = 0; i < gos.Length; i++)
                {
                    if (gos[i].gameObject.GetComponent<NewPlayerMovement>().inputScheme.name == "Player 2")
                    {
                        p2 = gos[i].GetComponent<NewPlayerMovement>();
                        p2.gameObject.active = false;
                        buttonP2.GetComponent<InteractiveSelection>().Reset("Player 2");
                    }

                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Joystick2Button1))
        {
            if (playerJoined[2])
            {
                GameObject.Find("DataStorage").gameObject.GetComponent<DataStorage>().playerOn[2] = false;
                playerJoined[2] = false;
                numberOfPlayers--;
                spawns[2].gameObject.active = false;
                pressToJoinIcons[2].gameObject.active = true;
                GameObject[] gos = GameObject.FindGameObjectsWithTag("Player");
                for (int i = 0; i < gos.Length; i++)
                {
                    if (gos[i].gameObject.GetComponent<NewPlayerMovement>().inputScheme.name == "Player 3")
                    {
                        p3 = gos[i].GetComponent<NewPlayerMovement>();
                        p3.gameObject.active = false;
                        buttonP3.GetComponent<InteractiveSelection>().Reset("Player 3");
                    }

                }

            }
            //Spawn_3.active = true;
        }
        if (Input.GetKeyDown(KeyCode.Joystick3Button1))
        {
            if (playerJoined[3])
            {
                GameObject.Find("DataStorage").gameObject.GetComponent<DataStorage>().playerOn[3] = false;
                playerJoined[3] = false;
                numberOfPlayers--;
                spawns[3].gameObject.active = false;
                pressToJoinIcons[3].gameObject.active = true;
                //Spawn_4.active = true;
                GameObject[] gos = GameObject.FindGameObjectsWithTag("Player");
                for (int i = 0; i < gos.Length; i++)
                {
                    if (gos[i].gameObject.GetComponent<NewPlayerMovement>().inputScheme.name == "Player 4")
                    {
                        p4 = gos[i].GetComponent<NewPlayerMovement>();
                        p4.gameObject.active = false;
                        buttonP4.GetComponent<InteractiveSelection>().Reset("Player 4");
                    }

                }
            }
        }
    }
}
