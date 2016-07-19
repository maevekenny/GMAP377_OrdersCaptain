using UnityEngine;
using System.Collections;

public class MoveBelt : MonoBehaviour {

    public GameObject belt;
    private Rigidbody2D _rigidbody;
    //private BoxCollider2D _collider;

    // Use this for initialization
    void Start () {
        //_collider = GetComponent<BoxCollider2D>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update () {

        _rigidbody.velocity = new Vector2(5, 0);

        if (transform.position.x > 10) DestroyObject(belt);

	}
}
