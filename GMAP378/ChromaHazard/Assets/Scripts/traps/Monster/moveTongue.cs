using UnityEngine;
using System.Collections;

public class moveTongue : MonoBehaviour {

    Rigidbody2D _myRigidBody;
    private bool collision = false;
    public GameObject delete;
    public float speedX = 1;
    public float speedY = 0;
    public bool movement = true;
    // Use this for initialization
    void Start () {
        _myRigidBody = GetComponent<Rigidbody2D>();
    }
    void OnCollisionEnter2D(Collision2D colli)
    {
        if (colli.gameObject.tag == "Player")
            //_rigidbody.velocity = new Vector2(-1 * speedX1, 1 * speedY1);
            collision = true;
    }
        IEnumerator returnObj()
    {
        yield return new WaitForSeconds(1);
        _myRigidBody.velocity = new Vector2(-1 * speedX, 1 * speedY);
        if (transform.position.x <= -8f)
			_myRigidBody.velocity = new Vector2(0f,0f);
    }
        IEnumerator returnObj2()
    {
        yield return new WaitForSeconds(0.1f);
        _myRigidBody.velocity = new Vector2(-2 * speedX, 1 * speedY);
        yield return new WaitForSeconds(0.1f);
        if (transform.position.x <= -8f )
			_myRigidBody.velocity = new Vector2(0f,0f);
    }
    // Update is called once per frame
    void Update () {
        if (movement)
        {
            _myRigidBody.velocity = new Vector2(1 * speedX, 1 * speedY);
            if (collision)
                StartCoroutine(returnObj2());
            else
                StartCoroutine(returnObj());
            

        }

    }
}
