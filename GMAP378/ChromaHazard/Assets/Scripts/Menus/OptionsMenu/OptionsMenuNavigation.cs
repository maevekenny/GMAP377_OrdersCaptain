using UnityEngine;
using System.Collections;

public class OptionsMenuNavigation : MonoBehaviour {
    public InputScheme inputScheme;

    public GameObject[] menuItems;
    bool canMoveMenu = true;
    float axisVer;
    float axisHor;
    int i = 0;
    int min;
    int max;

	// Use this for initialization
	void Start () {
	
            min = 0;
            max = menuItems.Length - 1;

        if (menuItems[0].GetComponent<SpriteRenderer>())
        {
            menuItems[0].GetComponent<SpriteRenderer>().color = new Color(0.94f, 0.81f, 0.43f);
        }
        else
        {
            menuItems[0].GetComponent<UnityEngine.UI.Text>().color = new Color(0.94f, 0.81f, 0.43f);
        }

    }

    IEnumerator JustDelay()
    {
        yield return new WaitForSeconds(0.25f);
        canMoveMenu = true;
    }

        IEnumerator Delay(int number)
    {
        if (menuItems[i].GetComponent<SpriteRenderer>())
        {
            menuItems[i].GetComponent<SpriteRenderer>().color = Color.white;
        }
        else
        {
            menuItems[i].GetComponent<UnityEngine.UI.Text>().color = Color.white;
        }
       
        yield return new WaitForSeconds(0.25f);

        i += number;

        if(i > max)
        {
            i = min;
        }else if (i < min)
        {
            i = max;
        }

        if (menuItems[i].GetComponent<SpriteRenderer>())
        {
            menuItems[i].GetComponent<SpriteRenderer>().color = new Color(0.94f, 0.81f, 0.43f);
        }
        else
        {
            menuItems[i].GetComponent<UnityEngine.UI.Text>().color = new Color(0.94f, 0.81f, 0.43f);
        }
        

        canMoveMenu = true;
    }

	// Update is called once per frame
	void Update () {
        axisVer = Input.GetAxisRaw("All_Vertical");
        axisHor = Input.GetAxisRaw("All_Horizontal");

        if (axisVer > 0.9f && canMoveMenu)
        {
            canMoveMenu = false;
            StartCoroutine(Delay(1));
        }

        if (axisVer < -0.9f && canMoveMenu)
        {
            StartCoroutine(Delay(-1));
            canMoveMenu = false;
        }

        if (axisHor > 0.9f && canMoveMenu)
        {
            if (menuItems[i].GetComponent<SpriteRenderer>())
            {
                canMoveMenu = false;
                StartCoroutine(Delay(1));
            }
            else {
                canMoveMenu = false;
                StartCoroutine("JustDelay");
                if (menuItems[i].GetComponent<ClickOnButtonMenuOptions>())
                {
                    menuItems[i].GetComponent<ClickOnButtonMenuOptions>().ClickRightButton(i);
                }
            }
            
        }

        if (axisHor < -0.9f && canMoveMenu)
        {
            if (menuItems[i].GetComponent<SpriteRenderer>())
            {
                canMoveMenu = false;
                StartCoroutine(Delay(-1));
            }
            else {
                canMoveMenu = false;
                StartCoroutine("JustDelay");
                if (menuItems[i].GetComponent<ClickOnButtonMenuOptions>())
                {
                    menuItems[i].GetComponent<ClickOnButtonMenuOptions>().ClickLeftButton(i);
                }
            }
            
        }

        if (Input.GetKeyDown(KeyCode.JoystickButton0))
        {
            if (menuItems[i].GetComponent<backToMainMenu>())
            {
                menuItems[i].GetComponent<backToMainMenu>().LoadScene();
            }
        }
    }
}
