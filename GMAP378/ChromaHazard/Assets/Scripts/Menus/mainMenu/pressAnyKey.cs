using UnityEngine;
using System.Collections;

public class pressAnyKey : MonoBehaviour {
	
	private GameObject _mainMenu;

	void Start () {
		_mainMenu = GameObject.Find ("mainMenu");
		_mainMenu.SetActive (false);
	}

	void Update () {
			if(Input.anyKeyDown){
				_mainMenu.SetActive(true);
				this.gameObject.SetActive(false);
		}
	}
}
