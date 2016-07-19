using UnityEngine;
using System.Collections;

public class PauseController : MonoBehaviour {

	public InputScheme inputScheme;
	public GameObject pauseMenu;

	public bool isPaused = false;
	public bool canPause;
	public float pauseDelay;
	private float initialPauseDelay;

	public int levelSelectScreenNumber;
	public int mainMenuNumber;
	private int levelToLoad;

	public GameObject aButton;
	public GameObject continueObject;
	public GameObject xButton;
	public GameObject levelSelect;
	public GameObject bButton;
	public GameObject mainMenu;

	private SpriteRenderer _aButton;
	private SpriteRenderer _continue;
	private SpriteRenderer _xButton;
	private SpriteRenderer _levelSelect;
	private SpriteRenderer _bButton;
	private SpriteRenderer _mainMenu;

	// Use this for initialization
	void Start () {
		_aButton = aButton.GetComponent<SpriteRenderer> ();
		_continue = continueObject.GetComponent<SpriteRenderer> ();
		_xButton = xButton.GetComponent<SpriteRenderer> ();
		_levelSelect = levelSelect.GetComponent<SpriteRenderer> ();
		_bButton = bButton.GetComponent<SpriteRenderer> ();
		_mainMenu = mainMenu.GetComponent<SpriteRenderer> ();

		levelToLoad = Application.loadedLevel;
		initialPauseDelay = pauseDelay;
		pauseMenu.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {

		pauseDelay -= Time.deltaTime;

		if (pauseDelay < 0) {
			canPause = true;
		}

		if (canPause) {
			if ((Input.GetKeyDown (inputScheme.Pause) || Input.GetKeyDown(inputScheme.PauseKeyBoard)) && !isPaused) {
				pauseMenu.SetActive (true);
				isPaused = true;
				pauseDelay = initialPauseDelay;
				Time.timeScale = 0.0f;
			} else if ((Input.GetKeyDown (inputScheme.Pause) || Input.GetKeyDown(inputScheme.PauseKeyBoard)) && isPaused) {
				unpause ();
			}
			//canPause = false;
		}
		//end pause menu stuff

		if (isPaused) {
			if(Input.GetKeyDown (inputScheme.Jump)){
				Time.timeScale = 1f;
				_bButton.color = new Color (0.94f,0.81f,0.43f);
				_mainMenu.color = new Color (0.94f,0.81f,0.43f);
				Application.LoadLevel (mainMenuNumber);
			}else if(Input.GetKeyDown (inputScheme.Shoot)){
				_xButton.color = new Color (0.94f,0.81f,0.43f);
				_levelSelect.color = new Color (0.94f,0.81f,0.43f);
				Time.timeScale = 1f;
				Application.LoadLevel (levelSelectScreenNumber);
			}else if(Input.GetKeyDown (inputScheme.Punch)){
				_aButton.color = new Color(0.94f,0.81f,0.43f);
				_continue.color = new Color(0.94f,0.81f,0.43f);
				Application.LoadLevel(levelToLoad);
			}


		}
	}

	public void unpause(){
		_aButton.color = Color.white;
		_continue.color = Color.white;
		pauseMenu.SetActive (false);
		isPaused = false;
		pauseDelay = initialPauseDelay;
		Time.timeScale = 1f;
	}
}
