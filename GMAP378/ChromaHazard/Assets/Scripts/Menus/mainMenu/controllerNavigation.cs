using UnityEngine;
using System.Collections;

public class controllerNavigation : MonoBehaviour {

	public InputScheme inputScheme;

	public GameObject[] menuItems;

	[HideInInspector]public int location; 

	public float menuDelay;
	private float initialInputDelay;
	private bool canMoveMenu = false;
	// Use this for initialization
	void Start () {
		initialInputDelay = menuDelay;

		if (menuItems[0] != null) {
			this.gameObject.transform.position = menuItems[0].transform.position;
			location = 0;
		} else {
		}
			
	}
	
	// Update is called once per frame
	void Update () {
		menuDelay -= Time.deltaTime;

		if (menuDelay <= 0) {
			canMoveMenu = true;
		}
			
		if (Input.GetAxis ("All_Vertical") >= 0.95f && canMoveMenu) {
			location++;
			canMoveMenu = false;
			menuDelay = initialInputDelay;
		} else if (Input.GetAxis ("All_Vertical") <= -0.95f && canMoveMenu) {
			location--;
			canMoveMenu = false;
			menuDelay = initialInputDelay;
		}

		moveLocation ();
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.name == menuItems [location].gameObject.name) {
			menuItems [location].GetComponent<chromaHazardGUIElement>()._sprite.color = menuItems [location].GetComponent<chromaHazardGUIElement> ().hover;
			menuItems [location].GetComponent<chromaHazardGUIElement>().mouseOver = true;

			if (col.gameObject.name == "MatchSettings" || col.gameObject.name == "MainMenu") {
				this.gameObject.transform.localScale = new Vector3 (1f, 0.7f, 1f);
			}else if (col.gameObject.name == "CreditsMainMenu") {
				this.gameObject.transform.localScale = new Vector3 (2f, 0.7f, 1f);
			} else {
				this.gameObject.transform.localScale = new Vector3 (1f, 1f, 1f);
			}
		} else {
		}
	}

	void OnTriggerStay2D(Collider2D stayCol){
		if (Input.GetKey (inputScheme.Punch) && canMoveMenu) {
			stayCol.gameObject.GetComponent<chromaHazardGUIElement>()._isButtonPressed = true;
		}

	}

	void OnTriggerExit2D(Collider2D exitCol){
		if (exitCol.gameObject.name == menuItems [1].gameObject.name) {
			menuItems [1].GetComponent<chromaHazardGUIElement> ()._sprite.color = menuItems [1].GetComponent<chromaHazardGUIElement> ().normal;
			menuItems [1].GetComponent<chromaHazardGUIElement> ().mouseOver = false;
		}else if (exitCol.gameObject.name == menuItems [location-1].gameObject.name) {
			menuItems [location-1].GetComponent<chromaHazardGUIElement> ()._sprite.color = menuItems [1].GetComponent<chromaHazardGUIElement> ().normal;
			menuItems [location-1].GetComponent<chromaHazardGUIElement> ().mouseOver = false;
		} else if (exitCol.gameObject.name == menuItems [location+1].gameObject.name) {
			menuItems [location+1].GetComponent<chromaHazardGUIElement> ()._sprite.color = menuItems [1].GetComponent<chromaHazardGUIElement> ().normal;
			menuItems [location+1].GetComponent<chromaHazardGUIElement> ().mouseOver = false;
		} else {
		}

	}

	void moveLocation(){
		if (location < 0) {
			location = 0;
		} else if(location >= menuItems.Length){
			location = menuItems.Length;
		}else {
			this.gameObject.transform.position = menuItems [location].transform.position;
		} 


	}
}
