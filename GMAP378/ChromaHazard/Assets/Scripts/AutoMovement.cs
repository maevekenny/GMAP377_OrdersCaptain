using UnityEngine;
using System.Collections;

public class AutoMovement : MonoBehaviour {

    Rigidbody2D _myRigidBody;
    public float speedX = 1;
    public float speedY = 0;
    public bool movement = false;

    // Use this for initialization
    void Start () {
        _myRigidBody = GetComponent<Rigidbody2D>();

    }

    IEnumerator deleteObj()
    {

        yield return new WaitForSeconds(3);
        Destroy(this.gameObject);

    }

    // Update is called once per frame
    void Update () {
        if (movement)
        {
            _myRigidBody.velocity = new Vector2(1 * speedX, 1 * speedY);
            StartCoroutine(deleteObj());
        }
       
    }
}
