using UnityEngine;
using System.Collections;

public class PlayerCamera : MonoBehaviour {

    
    Camera camera;
    public Camera playerCamera;
    bool cameraMoved = false;
    NewPlayerMovement player;

    // Use this for initialization
    void Start () {

        camera = GameObject.Find("Main Camera").GetComponent<Camera>();
        player = GetComponentInParent<NewPlayerMovement>();
        playerCamera.transform.parent = null;
    }
	
	// Update is called once per frame
	void Update () {

        if (cameraMoved)
        {
            playerCamera.transform.position = new Vector3(player.transform.position.x, player.transform.position.y+0.3f, playerCamera.transform.position.z);
        }

        if (Input.GetKeyDown(KeyCode.C) && this.gameObject.GetComponent<NewPlayerMovement>().inputScheme.name == "Player 1")
        {
            



            if (!cameraMoved )
            {
                
                    camera.gameObject.active = false;
                    playerCamera.gameObject.active = true;
               
                    cameraMoved = true;
                
            }
            else
            {
                camera.gameObject.active = true;
                playerCamera.gameObject.active = false;
                cameraMoved = false;
            }
        }

        
    }
}
