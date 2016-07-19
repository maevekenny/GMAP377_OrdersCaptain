using UnityEngine;
using System.Collections;

public class sonicwave : MonoBehaviour {

    private GameObject player1;
    public GameObject player2;
    public GameObject player3;
    private bool pickup = false;
    private bool inrange = false;
    public float power;
    public GameObject item;
    private Rigidbody2D _rigid;
    private Rigidbody2D _rigid2;
    private Rigidbody2D _rigid3;
    private float player1posX;
    private float player1posY;
    private float player2posX;
    private float player2posY;
    private float player3posX;
    private float player3posY;

    // Use this for initialization
    void Start () {
        _rigid = GetComponent<Rigidbody2D>();
        _rigid2 = player2.GetComponent<Rigidbody2D>();
        _rigid3 = player3.GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        player1posX = _rigid.transform.position.x;
        player1posY = _rigid.transform.position.y;
        player2posX = _rigid2.transform.position.x;
        player2posY = _rigid2.transform.position.y;
        player3posX = _rigid3.transform.position.x;
        player3posY = _rigid3.transform.position.y;




        if (Input.GetKey(KeyCode.Space) && pickup == true)
        {
            pickup = false;
            
            if ((player2posY - player1posY) < 5 && (player2posY - player1posY) > -5)
            {
                if ((player2posX - player1posX) < 5 && (player2posX - player1posX) > 0)
                {
                    _rigid2.AddForce(Vector2.right * power);
                }
                if ((player2posX - player1posX) < 0 && (player2posX - player1posX) > -5)
                {
                    _rigid2.AddForce(Vector2.left * power);
                }
            }

            if (player3posY - player1posY < 5 && player3posY - player1posY > -5)
            {
                if (player3posX - player1posX < 5 && player3posX - player1posX > 0)
                {
                    _rigid3.AddForce(Vector2.right * power);
                }
                if (player3posX - player1posX < 0 && player3posX - player1posX > -5)
                {
                    _rigid3.AddForce(Vector2.left * power);
                }
            }
        }
    }
            void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject==item && pickup != true)
        {
            pickup = true;
            DestroyObject(item);
        }
    }

    
   
}
