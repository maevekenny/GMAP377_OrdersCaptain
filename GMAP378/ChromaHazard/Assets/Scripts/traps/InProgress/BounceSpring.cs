using UnityEngine;
using System.Collections;

public class BounceSpring : MonoBehaviour {

    public GameObject spring2;
    private bool compress = false;
    private Rigidbody2D _rigid;
    public float power;
    private Rigidbody2D spring2rigid;

	// Use this for initialization
	void Start () {
        _rigid = GetComponent<Rigidbody2D>();
        spring2rigid = spring2.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        compress = false;
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Player")&&compress!=true)
        {
            compress = true;
            spring2rigid.AddForce(Vector2.up * power);
        }
    }
}
