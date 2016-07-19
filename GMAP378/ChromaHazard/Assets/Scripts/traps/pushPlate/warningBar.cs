using UnityEngine;
using System.Collections;

public class warningBar : MonoBehaviour {

	public GameObject playerDetector;
	private playerDetection _playerDetection;

	public float colorChangeRate;

	private SpriteRenderer _sprite;

	void Start () {
		_playerDetection = playerDetector.GetComponent<playerDetection> ();
		this.gameObject.transform.localScale = new Vector3 (_playerDetection.waitTime, 2f, 2f);
		_sprite = GetComponent<SpriteRenderer> ();
	}

	void Update () {
		if (_playerDetection.playerDetected) {
			this.gameObject.transform.localScale -= new Vector3 (Time.deltaTime, 0f, 0f);
			_sprite.color -= new Color (0f, colorChangeRate, 0f);
			_sprite.color += new Color (colorChangeRate, 0f, 0f);
		} else {
			this.gameObject.transform.localScale = new Vector3 (_playerDetection.waitTime, 2f, 2f);
			_sprite.color = Color.green;
		}
	}
}
