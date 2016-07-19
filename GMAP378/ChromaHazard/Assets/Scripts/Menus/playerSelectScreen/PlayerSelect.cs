using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerSelect : MonoBehaviour {

    public KeyCode PressToJoin;
    public KeyCode PressToStart;
    public KeyCode PressToReturn;
    public string SelectAxis;

    public KeyCode AltPressToJoin;
    public KeyCode AltPressToStart;
    public KeyCode AltPressToReturn;
    public KeyCode AltPressSelectLeft;
    public KeyCode AltPressSelectRight;

    public InputScheme PrimaryInputScheme;
    public InputScheme AltInputScheme;

    public Color[] characterColors;

    private GameObject pressToJoinPanel;
    private Text playerName;
    private Image characterPortrait;
    private Text playerReady;
    private GameObject selectionPanel;
    private int currentCharacter;
    private bool swapped;
    private bool altInput;

    // Use this for initialization
	void Start () {
        Ready = false;
        Joined = false;

        selectionPanel = transform.Find("Selection").gameObject;
        pressToJoinPanel = transform.Find("Press").gameObject;
        playerName = selectionPanel.transform.Find("Name").gameObject.GetComponent<Text>();
        characterPortrait = selectionPanel.transform.Find("Character").Find("Panel").Find("Portrait").gameObject.GetComponent<Image>();
        playerReady = transform.Find("Ready").gameObject.GetComponent<Text>();
        currentCharacter = 0;
        swapped = false;
        altInput = false;

        PlayerNone();
	}
	
	// Update is called once per frame
	void Update () {
	    if (!Joined && (Input.GetKeyDown(PressToJoin) || Input.GetKeyDown(AltPressToJoin)))
        {
            PlayerJoin();

            if (Input.GetKeyDown(AltPressToJoin))
            {
                altInput = true;
            }
        }

        if (Joined && !Ready) 
        {
            if ((Input.GetKeyDown(PressToStart) || Input.GetKeyDown(AltPressToStart)))
            {
                PlayerReady();
            }
            if ((Input.GetKeyDown(PressToReturn) || Input.GetKeyDown(AltPressToReturn)))
            {
                PlayerNone();
            }

            if (!swapped)
            {
                if (Input.GetAxis(SelectAxis) < -0.5f || Input.GetKeyDown(AltPressSelectLeft))
                {
                    currentCharacter--;
                    if (currentCharacter < 0)
                        currentCharacter = characterColors.Length - 1;
                    swapped = true;
                }
                else if (Input.GetAxis(SelectAxis) > 0.5f || Input.GetKeyDown(AltPressSelectRight))
                {
                    currentCharacter++;
                    currentCharacter %= characterColors.Length;
                    swapped = true;
                }
            }
            if (swapped)
            {
                if (Mathf.Abs(Input.GetAxis(SelectAxis)) < 0.2f)
                {
                    swapped = false;
                }
            }

            characterPortrait.color = characterColors[currentCharacter];
        }

        if (Ready && (Input.GetKeyDown(PressToReturn) || Input.GetKeyDown(AltPressToReturn)))
        {
            PlayerJoin();
        }
	}

    public bool Ready
    {
        get;
        private set;
    }

    public bool Joined
    {
        get;
        private set;
    }

    public string Name
    {
        get
        {
            return playerName.text;
        }
    }

    public Color CharacterColor
    {
        get
        {
            return characterColors[currentCharacter];
        }
    }

    public InputScheme Scheme
    {
        get
        {
            if (altInput)
                return AltInputScheme;
            return PrimaryInputScheme;
        }
    }

    public void PlayerNone()
    {
        pressToJoinPanel.gameObject.SetActive(true);
        selectionPanel.gameObject.SetActive(false);
        playerReady.gameObject.SetActive(false);
        Joined = false;
    }

    public void PlayerJoin()
    {
        pressToJoinPanel.gameObject.SetActive(false);
        selectionPanel.gameObject.SetActive(true);
        playerReady.gameObject.SetActive(false);
        Joined = true;
        Ready = false;
    }

    public void PlayerReady()
    {
        pressToJoinPanel.gameObject.SetActive(false);
        selectionPanel.gameObject.SetActive(false);
        playerReady.gameObject.SetActive(true);
        Ready = true;
    }
}
