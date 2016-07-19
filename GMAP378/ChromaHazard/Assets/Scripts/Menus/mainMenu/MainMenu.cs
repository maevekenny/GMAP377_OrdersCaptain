using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainMenu : MonoBehaviour {

    public string selectLevelName;
    public GameObject playerSelectScreen;
    public Button[] options;

    public string verticalSelectAxis; // this should be mapped to all joysticks vertical axis
    public string keyboardVerticalSelectAxis; // this should be mapped to keyboard vertical axis
    public string selectButton; // all joysticks "a"
    public string keyboardSelectButton; // keyboard enter

    private bool usingController;
    private int activeOption;
    private bool hasSwitched;

	// Use this for initialization
	void Start () {
        playerSelectScreen.SetActive(false);
        usingController = false;
        hasSwitched = false;
	}
	
	// Update is called once per frame
	void Update () {
        
        // CONTROLLER/KEYBOARD INPUT
        
        if (usingController)
        {
            if (!hasSwitched)
            {
                if (ScrollUp())
                {
                    hasSwitched = true;

                    // cycle backwards through options
                    activeOption -= 1;
                    if (activeOption < 0)
                        activeOption = options.Length - 1;
                }

                if (ScrollDown())
                {
                    hasSwitched = true;

                    // cycle forwards through options
                    activeOption += 1;
                    activeOption %= options.Length;
                }

                if (Select())
                {
                    // TODO: chose current option
                }
            }
            else
            {
                // TODO: Highlight curent option
                // Deselect previous option

                hasSwitched = false;
            }
        }
	}

    private bool ScrollUp()
    {
        return (Input.GetAxis(verticalSelectAxis) < 0 || Input.GetAxis(keyboardVerticalSelectAxis) < 0);
    }

    private bool ScrollDown()
    {
        return (Input.GetAxis(verticalSelectAxis) > 0 || Input.GetAxis(keyboardVerticalSelectAxis) > 0);
    }

    private bool Select()
    {
        return (Input.GetButtonDown(selectButton) || Input.GetButtonDown(keyboardSelectButton));
    }

    public void OpenPlayerSelectScreen()
    {
        playerSelectScreen.SetActive(true);
    }

    public void ClosePlayerSelectScreen()
    {
        playerSelectScreen.SetActive(false);
    }

    public void OpenLevelSelectScreen()
    {
        Application.LoadLevel(selectLevelName);
    }
}
