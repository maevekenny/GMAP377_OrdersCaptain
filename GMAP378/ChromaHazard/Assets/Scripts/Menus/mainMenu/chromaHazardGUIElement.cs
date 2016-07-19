using UnityEngine;
using System.Collections;

public class chromaHazardGUIElement : MonoBehaviour {

	//public Sprite hoverSprite;
	[HideInInspector]public bool _isButtonPressed = false;
	public bool mouseOver;

	public Color normal;
	public Color hover;
	public Color pressed;
	
	public SpriteRenderer _sprite;
	private Sprite _originalSprite;

	void Start(){
		_sprite = GetComponent<SpriteRenderer> ();
		_originalSprite = _sprite.sprite;
	}

	void OnMouseDown(){
		
		_isButtonPressed = true;
	}

	void OnMouseUp(){
		_sprite.color = normal;
		_isButtonPressed = false;
	}

	void OnMouseEnter(){
		mouseOver = true;
	}

	void OnMouseOver(){
		_sprite.color = hover;
	}

	void OnMouseExit(){
		_sprite.color = normal;
		mouseOver = false;
	}

	void Update(){
		if (_isButtonPressed) {
			_sprite.color = pressed;
		}
	}
}
