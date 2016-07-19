using UnityEngine;
using System.Collections;

public class FanTrap : MonoBehaviour {
    private Rigidbody2D _rigidbody;
    public float FanPower;
    //private BoxCollider2D _collider;
    // Use this for initialization
    void Start () {
        _rigidbody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
	    if(transform.position.x>-5f&&transform.position.x<5f)
        {
            if(transform.position.y>-10f&&transform.position.y<0)
            {
                _rigidbody.AddForce(Vector2.up * FanPower);
            }
        }
	}
}
