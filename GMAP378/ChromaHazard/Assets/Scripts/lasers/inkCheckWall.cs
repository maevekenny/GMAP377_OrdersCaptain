using UnityEngine;
using System.Collections;

public class inkCheckWall : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("floor"))
        {
            if(other.gameObject.GetComponent<PixelPainting>().MyActualColor() == Color.blue)
            {
                GetComponentInParent<PlayerController>().onIce = true;
            }
            else
            {
                GetComponentInParent<PlayerController>().onIce = false;
            }
        }
    }
}
