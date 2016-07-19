using UnityEngine;
using System.Collections;

public class InteractiveSelection : MonoBehaviour {
	
    public Sprite pressed;
    private bool buttonPressed = false;
    public GameObject playersController;
    private Sprite original;

    public bool p1Ready = false;
    public bool p2Ready = false;
    public bool p3Ready = false;
    public bool p4Ready = false;

	public GameObject floor;


    // Use this for initialization
    void Start () {
        original = GetComponent<SpriteRenderer>().sprite;
	}
	
	// Update is called once per frame
	void Update () {
	
	}



    void OnTriggerEnter2D(Collider2D coll)
    {
        if (!buttonPressed && coll.gameObject.CompareTag("Player"))
        {
            string name = coll.GetComponent<NewPlayerMovement>().inputScheme.name;
            if(name == "Player 1")
            {
                p1Ready = true;
            }
            else if(name == "Player 2")
            {
                p2Ready = true;
            }
            else if (name == "Player 3")
            {
                p3Ready = true;
            }
            else if (name == "Player 4")
            {
                p4Ready = true;
            }

            playersController.GetComponent<PressStart>().numberOfPlayersReady++;
            buttonPressed = true;
            GetComponent<SpriteRenderer>().sprite = pressed;
			Destroy (floor);
        }
    }

    public void Reset(string name)
    {
        if(name == "Player 1" && p1Ready)
        {
            p1Ready = false;
            playersController.GetComponent<PressStart>().numberOfPlayersReady--;
        }else if (name == "Player 2" && p2Ready)
        {
            p2Ready = false;
            playersController.GetComponent<PressStart>().numberOfPlayersReady--;
        }
        else if (name == "Player 3" && p3Ready)
        {
            p3Ready = false;
            playersController.GetComponent<PressStart>().numberOfPlayersReady--;
        }
        else if (name == "Player 4" && p4Ready)
        {
            p4Ready = false;
            playersController.GetComponent<PressStart>().numberOfPlayersReady--;
        }

        buttonPressed = false;
        GetComponent<SpriteRenderer>().sprite = original;
    }
}
