using UnityEngine;
using System.Collections;

public class ChangeGameMode : MonoBehaviour
{

    private string mode;
    private int lives;
    private int flagTime;
    private string superPunch;
    private string bomb;
    private string pushableBombs;
    private string inkDoesntVanish;
    private string pickableBombs;
    private string randomInk;

    public string bounceLaser;
    public string fastLaser;
    public string iceLaser;
    public string gooLaser;
    public string eraserLaser;
    public string invisibility;
    public string gravity;
    public string livesitem;


    public bool gameMode = false;
    public bool numberOfLives = false;
    public bool flagTimeCheck = false;
    public bool superPunchOn = false;
    public bool bombOn = false;
    public bool pushableBombsOn = false;
    public bool inkDoesntVanishOn = false;
    public bool pickableBombsOn = false;
    public bool randomInkOn = false;

    public bool bounceLaserOn = false;
    public bool fastLaserOn = false;
    public bool iceLaserOn = false;
    public bool gooLaserOn = false;
    public bool eraserLaserOn = false;
    public bool invisibilityOn = false;
    public bool gravityOn = false;
    public bool livesitemOn = false;
    public bool defaultLaserOn = false;

    DefaultLaserColors defaultLaserColors;

    Color defaultLaser;

    DataStorage data;

    // Use this for initialization
    void Start()
    {
        defaultLaserColors = new DefaultLaserColors();
        data = GameObject.Find("DataStorage").GetComponent<DataStorage>();

        defaultLaser = data.defaultLaser;

        mode = data.gameMode;
        lives = data.numberOfLives;
        flagTime = data.timer;
        superPunch = data.superPunch;
        bomb = data.bomb;
        pushableBombs = data.pushableBomb;
        inkDoesntVanish = data.inkDoesntVanish;
        pickableBombs = data.pickableBombs;
        randomInk = data.randomInk;

        bounceLaser = data.bounceLaserEnabled;
        fastLaser = data.fastLaserEnabled;
        iceLaser = data.iceLaserEnabled;
        gooLaser = data.gooLaserEnabled;
        eraserLaser = data.eraserLaserEnabled;
        invisibility = data.invisibilityEnabled;
        gravity = data.revertGravityEnabled;
        livesitem = data.livesEnabled;


        if (defaultLaserOn)
        {
            if(defaultLaser == defaultLaserColors.bounceLaser)
            {
                this.GetComponent<UnityEngine.UI.Text>().text = "Bounce";
            }
            else if (defaultLaser == defaultLaserColors.fastLaser)
            {
                this.GetComponent<UnityEngine.UI.Text>().text = "Haste";
            }
            else if (defaultLaser == defaultLaserColors.iceLaser)
            {
                this.GetComponent<UnityEngine.UI.Text>().text = "Ice";
            }
            else if (defaultLaser == defaultLaserColors.gooLaser)
            {
                this.GetComponent<UnityEngine.UI.Text>().text = "Goo";
            }
            else if (defaultLaser == defaultLaserColors.eraserLaser)
            {
                this.GetComponent<UnityEngine.UI.Text>().text = "Eraser";
            }
            else if (defaultLaser == Color.clear)
            {
                this.GetComponent<UnityEngine.UI.Text>().text = "Random";
            }
        }

        if (bounceLaserOn)
        {
            this.GetComponent<UnityEngine.UI.Text>().text = bounceLaser;
        }
        if (fastLaserOn)
        {
            this.GetComponent<UnityEngine.UI.Text>().text = fastLaser;
        }
        if (iceLaserOn)
        {
            this.GetComponent<UnityEngine.UI.Text>().text = iceLaser;
        }
        if (gooLaserOn)
        {
            this.GetComponent<UnityEngine.UI.Text>().text = gooLaser;
        }
        if (eraserLaserOn)
        {
            this.GetComponent<UnityEngine.UI.Text>().text = eraserLaser;
        }
        if (gravityOn)
        {
            this.GetComponent<UnityEngine.UI.Text>().text = gravity;
        }
        if (livesitemOn)
        {
            this.GetComponent<UnityEngine.UI.Text>().text = livesitem;
        }
        if (invisibilityOn)
        {
            this.GetComponent<UnityEngine.UI.Text>().text = invisibility;
        }


        if (randomInkOn)
        {
            this.GetComponent<UnityEngine.UI.Text>().text = randomInk;
        }

        if (pickableBombsOn)
        {
            this.GetComponent<UnityEngine.UI.Text>().text = pickableBombs;
        }

        if (inkDoesntVanishOn)
        {
            this.GetComponent<UnityEngine.UI.Text>().text = inkDoesntVanish;
        }

        if (pushableBombsOn)
        {
            this.GetComponent<UnityEngine.UI.Text>().text = pushableBombs;
        }

        if (bombOn)
        {
            this.GetComponent<UnityEngine.UI.Text>().text = bomb;
        }

        if (gameMode)
        {
            this.GetComponent<UnityEngine.UI.Text>().text = mode;
        }
        if (numberOfLives)
        {
            this.GetComponent<UnityEngine.UI.Text>().text = "" + lives;
        }
        if (flagTimeCheck)
        {
            this.GetComponent<UnityEngine.UI.Text>().text = "" + flagTime;
        }
        if (superPunchOn)
        {
            this.GetComponent<UnityEngine.UI.Text>().text = "" + superPunch;
        }

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeLaserIncrease()
    {
        if (this.GetComponent<UnityEngine.UI.Text>().text == "Bounce")
        {
            this.GetComponent<UnityEngine.UI.Text>().text = "Haste";
            data.GetComponent<DataStorage>().defaultLaser = defaultLaserColors.fastLaser;
        }
        else if (this.GetComponent<UnityEngine.UI.Text>().text == "Haste")
        {
            this.GetComponent<UnityEngine.UI.Text>().text = "Ice";
            data.GetComponent<DataStorage>().defaultLaser = defaultLaserColors.iceLaser;
        }
        else if (this.GetComponent<UnityEngine.UI.Text>().text == "Ice")
        {
            this.GetComponent<UnityEngine.UI.Text>().text = "Goo";
            data.GetComponent<DataStorage>().defaultLaser = defaultLaserColors.gooLaser;
        }
        else if (this.GetComponent<UnityEngine.UI.Text>().text == "Goo")
        {
            this.GetComponent<UnityEngine.UI.Text>().text = "Eraser";
            data.GetComponent<DataStorage>().defaultLaser = defaultLaserColors.eraserLaser;
        }
        else if (this.GetComponent<UnityEngine.UI.Text>().text == "Eraser")
        {
            this.GetComponent<UnityEngine.UI.Text>().text = "Random";
            data.GetComponent<DataStorage>().defaultLaser = Color.clear;
        }
        else if (this.GetComponent<UnityEngine.UI.Text>().text == "Random")
        {
            this.GetComponent<UnityEngine.UI.Text>().text = "Bounce";
            data.GetComponent<DataStorage>().defaultLaser = defaultLaserColors.bounceLaser;
        }

    }

    public void ChangeLaserDecrease()
    {
        if (this.GetComponent<UnityEngine.UI.Text>().text == "Bounce")
        {
            this.GetComponent<UnityEngine.UI.Text>().text = "Random";
            data.GetComponent<DataStorage>().defaultLaser = Color.clear;
        }
        else if (this.GetComponent<UnityEngine.UI.Text>().text == "Random")
        {
            this.GetComponent<UnityEngine.UI.Text>().text = "Eraser";
            data.GetComponent<DataStorage>().defaultLaser = defaultLaserColors.eraserLaser;
        }
        else if (this.GetComponent<UnityEngine.UI.Text>().text == "Eraser")
        {
            this.GetComponent<UnityEngine.UI.Text>().text = "Goo";
            data.GetComponent<DataStorage>().defaultLaser = defaultLaserColors.gooLaser;
        }
        else if (this.GetComponent<UnityEngine.UI.Text>().text == "Goo")
        {
            this.GetComponent<UnityEngine.UI.Text>().text = "Ice";
            data.GetComponent<DataStorage>().defaultLaser = defaultLaserColors.iceLaser;
        }
        else if (this.GetComponent<UnityEngine.UI.Text>().text == "Ice")
        {
            this.GetComponent<UnityEngine.UI.Text>().text = "Haste";
            data.GetComponent<DataStorage>().defaultLaser = defaultLaserColors.fastLaser;
        }
        else if (this.GetComponent<UnityEngine.UI.Text>().text == "Haste")
        {
            this.GetComponent<UnityEngine.UI.Text>().text = "Bounce";
            data.GetComponent<DataStorage>().defaultLaser = defaultLaserColors.bounceLaser;
        }

    }

    public void ChangeModeIncrease()
    {
        if (this.GetComponent<UnityEngine.UI.Text>().text == "Survival")
        {
            this.GetComponent<UnityEngine.UI.Text>().text = "King of The Hill";
            data.GetComponent<DataStorage>().gameMode = "King of The Hill";
        }
        else if (this.GetComponent<UnityEngine.UI.Text>().text == "King of The Hill")
        {
            this.GetComponent<UnityEngine.UI.Text>().text = "Dynamiteman";
            data.GetComponent<DataStorage>().gameMode = "Dynamiteman";
        }
        else if (this.GetComponent<UnityEngine.UI.Text>().text == "Dynamiteman")
        {
            this.GetComponent<UnityEngine.UI.Text>().text = "Survival";
            data.GetComponent<DataStorage>().gameMode = "Survival";
        }

    }

    public void ChangeModeDecrease()
    {
        if (this.GetComponent<UnityEngine.UI.Text>().text == "Survival")
        {
            this.GetComponent<UnityEngine.UI.Text>().text = "Dynamiteman";
            data.GetComponent<DataStorage>().gameMode = "Dynamiteman";
        }
        else if (this.GetComponent<UnityEngine.UI.Text>().text == "King of The Hill")
        {
            this.GetComponent<UnityEngine.UI.Text>().text = "Survival";
            data.GetComponent<DataStorage>().gameMode = "Survival";
        }
        else if (this.GetComponent<UnityEngine.UI.Text>().text == "Dynamiteman")
        {
            this.GetComponent<UnityEngine.UI.Text>().text = "King of The Hill";
            data.GetComponent<DataStorage>().gameMode = "King of The Hill";
        }

    }

    public void reduceLife()
    {
        lives--;
        if (lives <= 1)
        {
            lives = 1;
        }
        this.GetComponent<UnityEngine.UI.Text>().text = "" + lives;
        data.GetComponent<DataStorage>().numberOfLives = lives;
    }

    public void increaseLife()
    {
        lives++;
        if (lives >= 19)
        {
            lives = 19;
        }
        this.GetComponent<UnityEngine.UI.Text>().text = "" + lives;
        data.GetComponent<DataStorage>().numberOfLives = lives;
    }


    public void reduceTimer()
    {
        flagTime--;
        if (flagTime <= 5)
        {
            flagTime = 5;
        }
        this.GetComponent<UnityEngine.UI.Text>().text = "" + flagTime;
        data.GetComponent<DataStorage>().timer = flagTime;
    }

    public void increaseTimer()
    {
        flagTime++;
        if (flagTime >= 60)
        {
            flagTime = 60;
        }
        this.GetComponent<UnityEngine.UI.Text>().text = "" + flagTime;
        data.GetComponent<DataStorage>().timer = flagTime;
    }

    public void ChangePunch()
    {
        if (this.GetComponent<UnityEngine.UI.Text>().text == "Disabled")
        {
            this.GetComponent<UnityEngine.UI.Text>().text = "Enabled";
            data.GetComponent<DataStorage>().superPunch = "Enabled";
        }
        else
        {
            this.GetComponent<UnityEngine.UI.Text>().text = "Disabled";
            data.GetComponent<DataStorage>().superPunch = "Disabled";
        }

    }

    public void ChangeBomb()
    {
        if (this.GetComponent<UnityEngine.UI.Text>().text == "Disabled")
        {
            this.GetComponent<UnityEngine.UI.Text>().text = "Enabled";
            data.GetComponent<DataStorage>().bomb = "Enabled";
        }
        else
        {
            this.GetComponent<UnityEngine.UI.Text>().text = "Disabled";
            data.GetComponent<DataStorage>().bomb = "Disabled";
        }

    }

    public void ChangePushableBombs()
    {
        if (this.GetComponent<UnityEngine.UI.Text>().text == "Disabled")
        {
            this.GetComponent<UnityEngine.UI.Text>().text = "Enabled";
            data.GetComponent<DataStorage>().pushableBomb = "Enabled";
        }
        else
        {
            this.GetComponent<UnityEngine.UI.Text>().text = "Disabled";
            data.GetComponent<DataStorage>().pushableBomb = "Disabled";
        }

    }

    public void ChangeInk()
    {
        if (this.GetComponent<UnityEngine.UI.Text>().text == "Disabled")
        {
            this.GetComponent<UnityEngine.UI.Text>().text = "Enabled";
            data.GetComponent<DataStorage>().inkDoesntVanish = "Enabled";
        }
        else
        {
            this.GetComponent<UnityEngine.UI.Text>().text = "Disabled";
            data.GetComponent<DataStorage>().inkDoesntVanish = "Disabled";
        }

    }

    public void ChangeBounce()
    {
        if (this.GetComponent<UnityEngine.UI.Text>().text == "Disabled")
        {
            this.GetComponent<UnityEngine.UI.Text>().text = "Enabled";
            data.GetComponent<DataStorage>().bounceLaserEnabled = "Enabled";
        }
        else
        {
            this.GetComponent<UnityEngine.UI.Text>().text = "Disabled";
            data.GetComponent<DataStorage>().bounceLaserEnabled = "Disabled";
        }

    }

    public void ChangeFast()
    {
        if (this.GetComponent<UnityEngine.UI.Text>().text == "Disabled")
        {
            this.GetComponent<UnityEngine.UI.Text>().text = "Enabled";
            data.GetComponent<DataStorage>().fastLaserEnabled = "Enabled";
        }
        else
        {
            this.GetComponent<UnityEngine.UI.Text>().text = "Disabled";
            data.GetComponent<DataStorage>().fastLaserEnabled = "Disabled";
        }

    }

    public void ChangeIce()
    {
        if (this.GetComponent<UnityEngine.UI.Text>().text == "Disabled")
        {
            this.GetComponent<UnityEngine.UI.Text>().text = "Enabled";
            data.GetComponent<DataStorage>().iceLaserEnabled = "Enabled";
        }
        else
        {
            this.GetComponent<UnityEngine.UI.Text>().text = "Disabled";
            data.GetComponent<DataStorage>().iceLaserEnabled = "Disabled";
        }

    }

    public void ChangeGoo()
    {
        if (this.GetComponent<UnityEngine.UI.Text>().text == "Disabled")
        {
            this.GetComponent<UnityEngine.UI.Text>().text = "Enabled";
            data.GetComponent<DataStorage>().gooLaserEnabled = "Enabled";
        }
        else
        {
            this.GetComponent<UnityEngine.UI.Text>().text = "Disabled";
            data.GetComponent<DataStorage>().gooLaserEnabled = "Disabled";
        }

    }

    public void ChangeEraser()
    {
        if (this.GetComponent<UnityEngine.UI.Text>().text == "Disabled")
        {
            this.GetComponent<UnityEngine.UI.Text>().text = "Enabled";
            data.GetComponent<DataStorage>().eraserLaserEnabled = "Enabled";
        }
        else
        {
            this.GetComponent<UnityEngine.UI.Text>().text = "Disabled";
            data.GetComponent<DataStorage>().eraserLaserEnabled = "Disabled";
        }

    }

    public void ChangeInvisibility()
    {
        if (this.GetComponent<UnityEngine.UI.Text>().text == "Disabled")
        {
            this.GetComponent<UnityEngine.UI.Text>().text = "Enabled";
            data.GetComponent<DataStorage>().invisibilityEnabled = "Enabled";
        }
        else
        {
            this.GetComponent<UnityEngine.UI.Text>().text = "Disabled";
            data.GetComponent<DataStorage>().invisibilityEnabled = "Disabled";
        }

    }

    public void ChangeGravity()
    {
        if (this.GetComponent<UnityEngine.UI.Text>().text == "Disabled")
        {
            this.GetComponent<UnityEngine.UI.Text>().text = "Enabled";
            data.GetComponent<DataStorage>().revertGravityEnabled = "Enabled";
        }
        else
        {
            this.GetComponent<UnityEngine.UI.Text>().text = "Disabled";
            data.GetComponent<DataStorage>().revertGravityEnabled = "Disabled";
        }

    }

    public void ChangeLivesItem()
    {
        if (this.GetComponent<UnityEngine.UI.Text>().text == "Disabled")
        {
            this.GetComponent<UnityEngine.UI.Text>().text = "Enabled";
            data.GetComponent<DataStorage>().livesEnabled = "Enabled";
        }
        else
        {
            this.GetComponent<UnityEngine.UI.Text>().text = "Disabled";
            data.GetComponent<DataStorage>().livesEnabled = "Disabled";
        }

    }


    public void ChangePickableBombs()
    {
        if (this.GetComponent<UnityEngine.UI.Text>().text == "Disabled")
        {
            this.GetComponent<UnityEngine.UI.Text>().text = "Enabled";
            data.GetComponent<DataStorage>().pickableBombs = "Enabled";
        }
        else
        {
            this.GetComponent<UnityEngine.UI.Text>().text = "Disabled";
            data.GetComponent<DataStorage>().pickableBombs = "Disabled";
        }

    }

    public void ChangeRandomInk()
    {
        if (this.GetComponent<UnityEngine.UI.Text>().text == "Disabled")
        {
            this.GetComponent<UnityEngine.UI.Text>().text = "Enabled";
            data.GetComponent<DataStorage>().randomInk = "Enabled";
        }
        else
        {
            this.GetComponent<UnityEngine.UI.Text>().text = "Disabled";
            data.GetComponent<DataStorage>().randomInk = "Disabled";
        }

    }
}
