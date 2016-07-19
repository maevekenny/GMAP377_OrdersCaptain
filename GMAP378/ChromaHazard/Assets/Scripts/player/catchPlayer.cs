using UnityEngine;
using System.Collections;

public class catchPlayer : MonoBehaviour {
    public GameObject tongue;
    public GameObject player;
    private Rigidbody2D _rigidbody;
    private BoxCollider2D _collider;
    private bool collision = false;
    public float speedX1 = 1;
    public float speedY1 = 0;
    // Use this for initialization
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _collider = GetComponent<BoxCollider2D>();
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject == tongue)
            //_rigidbody.velocity = new Vector2(-1 * speedX1, 1 * speedY1);
            collision = true;
        // Update is called once per frame

    }
    void Update()
    {
        if (collision)
            _rigidbody.velocity = new Vector2(-2 * speedX1, 1 * speedY1);
        if (transform.position.x <= -8f)
            Destroy(player);
    }

}
