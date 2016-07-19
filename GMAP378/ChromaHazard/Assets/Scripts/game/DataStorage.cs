using UnityEngine;
using System.Collections;

public class DataStorage : MonoBehaviour {

    public int lastLevel = 0;

    public Color defaultLaser;
    public string gameMode;
    public int numberOfLives;
    public int timer;
    public Color[] color = new Color[4];
    public bool[] playerOn = new bool[4];
    public string superPunch;
    public string bomb;
    public string pushableBomb;
    public string inkDoesntVanish;
    public string pickableBombs;

    public Color colorVictory = Color.blue;
    public string PlayerWinner = "Player X";

    public string bounceLaserEnabled = "Enabled";
    public string fastLaserEnabled = "Enabled";
    public string iceLaserEnabled = "Enabled";
    public string gooLaserEnabled = "Enabled";
    public string eraserLaserEnabled = "Enabled";
    public string invisibilityEnabled = "Enabled";
    public string revertGravityEnabled = "Enabled";
    public string livesEnabled = "Enabled";
    DefaultLaserColors defaultLaserColors;
    public string randomInk;

    // Use this for initialization
    void Start () {

        GameObject[] gos = GameObject.FindGameObjectsWithTag("DataStorage");
        defaultLaserColors = new DefaultLaserColors();

        defaultLaser = defaultLaserColors.bounceLaser;
        gameMode = "Survival";
        numberOfLives = 10;
        timer = 10;
        superPunch = "Disabled";
        bomb = "Disabled";
        pushableBomb = "Disabled";
        inkDoesntVanish = "Disabled";
        pickableBombs = "Disabled";
        randomInk = "Disabled";

        color[0] = Color.blue;
        color[1] = Color.blue;
        color[2] = Color.blue;
        color[3] = Color.blue;

        playerOn[0] = false;
        playerOn[1] = false;
        playerOn[2] = false;
        playerOn[3] = false;

        if (gos.Length >= 2)
        {
            Destroy(this);
        }
        else {
            DontDestroyOnLoad(this);
        }
        
    }
	
	// Update is called once per frame
	void Update () {
        
    }
}
