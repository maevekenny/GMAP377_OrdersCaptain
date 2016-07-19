using UnityEngine;
using System.Collections;

public class SpawnPlayer : MonoBehaviour {
        
    public GameObject prefab;
    public int playerNumber;
    public Transform shoot;
    private bool playerOn = false;

    private GameObject spawnedPlayer;
    
    // Use this for initialization
	void Start () {
        // If no players were set up, ie, we are launching from the level directly
        InputScheme defaultScheme = new InputScheme();
       

        playerOn = GameObject.Find("DataStorage").GetComponent<DataStorage>().playerOn[playerNumber - 1];
   
        if(Input.GetJoystickNames().Length < 4)
        {
            //------------
            if (!wasConfigured() && playerNumber == 1)
            {
                // Create default input setup

                defaultScheme.Left = KeyCode.LeftArrow;
                defaultScheme.Right = KeyCode.RightArrow;
                defaultScheme.Jump = KeyCode.Joystick1Button4;
                defaultScheme.Shoot = KeyCode.Joystick1Button5;
                defaultScheme.ControllerHorizontalAxisStick_1 = "Joystick_1_Horizontal";
                defaultScheme.ControllerVerticalAxisStick_1 = "Joystick_1_Vertical";
                defaultScheme.ControllerHorizontalAxisStick_2 = "Joystick_1_Secondary_Horizontal";
                defaultScheme.ControllerVerticalAxisStick_2 = "Joystick_1_Secondary_Vertical";
                defaultScheme.IsController = true;
                defaultScheme.color = GameObject.Find("DataStorage").GetComponent<DataStorage>().color[0];
                defaultScheme.Punch = KeyCode.Joystick1Button0;
                //defaultScheme.Punch = Axis??;
                defaultScheme.name = "Player 1";

                if (playerOn)
                {
                    setUpPlayer(defaultScheme, null);
                }
            }
            else if (!wasConfigured() && playerNumber == 2)
            {
                // Create default input setup

                defaultScheme.Left = KeyCode.A;
                defaultScheme.Right = KeyCode.D;
                defaultScheme.Jump = KeyCode.Space;
                defaultScheme.Shoot = KeyCode.Mouse0;
                defaultScheme.ControllerHorizontalAxisStick_1 = "Joystick_1_Horizontal";
                defaultScheme.ControllerVerticalAxisStick_1 = "Joystick_1_Vertical";
                defaultScheme.ControllerHorizontalAxisStick_2 = "Joystick_1_Secondary_Horizontal";
                defaultScheme.ControllerVerticalAxisStick_2 = "Joystick_1_Secondary_Vertical";
                defaultScheme.IsController = false;
				defaultScheme.color = new Color(1f,.62f,.34f);
                defaultScheme.Punch = KeyCode.Mouse1;
                defaultScheme.name = "Player 2";


                if (playerOn)
                {
                    setUpPlayer(defaultScheme, null);
                }
            }
            else if (!wasConfigured() && playerNumber == 3)
            {
                // Create default input setup

                defaultScheme.Left = KeyCode.LeftArrow;
                defaultScheme.Right = KeyCode.RightArrow;
                defaultScheme.Jump = KeyCode.Joystick2Button4;
                defaultScheme.Shoot = KeyCode.Joystick2Button5;
                defaultScheme.ControllerHorizontalAxisStick_1 = "Joystick_2_Horizontal";
                defaultScheme.ControllerVerticalAxisStick_1 = "Joystick_2_Vertical";
                defaultScheme.ControllerHorizontalAxisStick_2 = "Joystick_2_Secondary_Horizontal";
                defaultScheme.ControllerVerticalAxisStick_2 = "Joystick_2_Secondary_Vertical";
                defaultScheme.IsController = true;
				defaultScheme.color = new Color(1f,.21f,.21f);
                defaultScheme.Punch = KeyCode.Joystick2Button0;
                //defaultScheme.Punch = Axis??;
                defaultScheme.name = "Player 3";

                if (playerOn)
                {
                    setUpPlayer(defaultScheme, null);
                }
            }
            else if (!wasConfigured() && playerNumber == 4)
            {
                // Create default input setup

                defaultScheme.Left = KeyCode.LeftArrow;
                defaultScheme.Right = KeyCode.RightArrow;
                defaultScheme.Jump = KeyCode.Joystick3Button4;
                defaultScheme.Shoot = KeyCode.Joystick3Button5;
                defaultScheme.ControllerHorizontalAxisStick_1 = "Joystick_3_Horizontal";
                defaultScheme.ControllerVerticalAxisStick_1 = "Joystick_3_Vertical";
                defaultScheme.ControllerHorizontalAxisStick_2 = "Joystick_3_Secondary_Horizontal";
                defaultScheme.ControllerVerticalAxisStick_2 = "Joystick_3_Secondary_Vertical";
                defaultScheme.IsController = true;
				defaultScheme.color = new Color (.32f, 1f, .38f);
                defaultScheme.Punch = KeyCode.Joystick3Button0;
                //defaultScheme.Punch = Axis??;
                defaultScheme.name = "Player 4";


                if (playerOn)
                {
                    setUpPlayer(defaultScheme, null);
                }
            }
            // If this player has been set up in the player slect screen
            else if (playerConfigured())
            {
                Player player = Game.Instance.Players[playerNumber - 1];
                setUpPlayer(player.ControllerScheme, player);

            }
            //------------
        }
        else if(Input.GetJoystickNames().Length >= 4)
        {
            //------------
            if (!wasConfigured() && playerNumber == 1)
            {
                // Create default input setup

                defaultScheme.Left = KeyCode.LeftArrow;
                defaultScheme.Right = KeyCode.RightArrow;
                defaultScheme.Jump = KeyCode.Joystick1Button4;
                defaultScheme.Shoot = KeyCode.Joystick1Button5;
                defaultScheme.ControllerHorizontalAxisStick_1 = "Joystick_1_Horizontal";
                defaultScheme.ControllerVerticalAxisStick_1 = "Joystick_1_Vertical";
                defaultScheme.ControllerHorizontalAxisStick_2 = "Joystick_1_Secondary_Horizontal";
                defaultScheme.ControllerVerticalAxisStick_2 = "Joystick_1_Secondary_Vertical";
                defaultScheme.IsController = true;
                defaultScheme.color = GameObject.Find("DataStorage").GetComponent<DataStorage>().color[0];
                defaultScheme.Punch = KeyCode.Joystick1Button0;
                //defaultScheme.Punch = Axis??;
                defaultScheme.name = "Player 1";

                if (playerOn)
                {
                    setUpPlayer(defaultScheme, null);
                }
            }
            else if (!wasConfigured() && playerNumber == 2)
            {
                // Create default input setup

                defaultScheme.Left = KeyCode.LeftArrow;
                defaultScheme.Right = KeyCode.RightArrow;
                defaultScheme.Jump = KeyCode.Joystick2Button4;
                defaultScheme.Shoot = KeyCode.Joystick2Button5;
                defaultScheme.ControllerHorizontalAxisStick_1 = "Joystick_2_Horizontal";
                defaultScheme.ControllerVerticalAxisStick_1 = "Joystick_2_Vertical";
                defaultScheme.ControllerHorizontalAxisStick_2 = "Joystick_2_Secondary_Horizontal";
                defaultScheme.ControllerVerticalAxisStick_2 = "Joystick_2_Secondary_Vertical";
                defaultScheme.IsController = true;
				defaultScheme.color = new Color(1f,.62f,.34f);
                defaultScheme.Punch = KeyCode.Joystick2Button0;
                //defaultScheme.Punch = Axis??;
                defaultScheme.name = "Player 2";


                if (playerOn)
                {
                    setUpPlayer(defaultScheme, null);
                }
            }
            else if (!wasConfigured() && playerNumber == 3)
            {
                // Create default input setup

                defaultScheme.Left = KeyCode.LeftArrow;
                defaultScheme.Right = KeyCode.RightArrow;
                defaultScheme.Jump = KeyCode.Joystick3Button4;
                defaultScheme.Shoot = KeyCode.Joystick3Button5;
                defaultScheme.ControllerHorizontalAxisStick_1 = "Joystick_3_Horizontal";
                defaultScheme.ControllerVerticalAxisStick_1 = "Joystick_3_Vertical";
                defaultScheme.ControllerHorizontalAxisStick_2 = "Joystick_3_Secondary_Horizontal";
                defaultScheme.ControllerVerticalAxisStick_2 = "Joystick_3_Secondary_Vertical";
                defaultScheme.IsController = true;
				defaultScheme.color = new Color(1f,.21f,.21f);
                defaultScheme.Punch = KeyCode.Joystick3Button0;
                //defaultScheme.Punch = Axis??;
                defaultScheme.name = "Player 3";

                if (playerOn)
                {
                    setUpPlayer(defaultScheme, null);
                }
            }
            else if (!wasConfigured() && playerNumber == 4)
            {
                // Create default input setup

                defaultScheme.Left = KeyCode.LeftArrow;
                defaultScheme.Right = KeyCode.RightArrow;
                defaultScheme.Jump = KeyCode.Joystick4Button4;
                defaultScheme.Shoot = KeyCode.Joystick4Button5;
                defaultScheme.ControllerHorizontalAxisStick_1 = "Joystick_4_Horizontal";
                defaultScheme.ControllerVerticalAxisStick_1 = "Joystick_4_Vertical";
                defaultScheme.ControllerHorizontalAxisStick_2 = "Joystick_4_Secondary_Horizontal";
                defaultScheme.ControllerVerticalAxisStick_2 = "Joystick_4_Secondary_Vertical";
                defaultScheme.IsController = true;
				defaultScheme.color = new Color (.32f, 1f, .38f);
                defaultScheme.Punch = KeyCode.Joystick4Button0;
                //defaultScheme.Punch = Axis??;
                defaultScheme.name = "Player 4";


                if (playerOn)
                {
                    setUpPlayer(defaultScheme, null);
                }
            }
            // If this player has been set up in the player slect screen
            else if (playerConfigured())
            {
                Player player = Game.Instance.Players[playerNumber - 1];
                setUpPlayer(player.ControllerScheme, player);

            }
            //------------
        }

        

        

           
	}

    private bool wasConfigured()
    {
        return (Game.Instance.Players.Count > 0);
    }

    private bool playerConfigured()
    {
        return (Game.Instance.Players.Count >= playerNumber);
    }

    private void setUpPlayer(InputScheme scheme, Player p)
    {
        // Instantiate player prefab
        GameObject player = Instantiate(prefab, transform.position, transform.localRotation) as GameObject;
        NewPlayerMovement controller = player.GetComponentInChildren<NewPlayerMovement>();
        MouseAim aim = player.GetComponentInChildren<MouseAim>();

        // Add player transform to Camera
        GameplayCamera c = Camera.main.GetComponent<GameplayCamera>();
        if (c != null)
        {
            c.AddPlayerTransform(player.transform);
        }

        // set up player variables
        //aim.shoot = shoot;
        //aim.isController = scheme.IsController;
        controller.inputScheme = scheme;
        controller.playerInstance = p;
        spawnedPlayer = player;

    }

    public GameObject getPlayerSpawned()
    {
        return spawnedPlayer;
    }
}
