using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Rigidbody2D))]
[RequireComponent (typeof (BoxCollider2D))]

public class PlayerController : MonoBehaviour {

    public float playerAcceleration;
    public float maxPlayerSpeed;
    public float playerJumpPower;
    public InputScheme inputScheme;
    public Color stunColor;

    private Vector2 _origin;
    private Rigidbody2D _rigidbody;
    private LineRenderer _line;
    private BoxCollider2D _collider;
    private SpriteRenderer _renderer;
    private float playerAcceleration_original;
    private float maxPlayerSpeed_original;
    private float playerJumpPower_original;
    //private bool _grounded;
    //private Vector3 _target;
    private MouseAim laser;
    private Color originalColor;

    private bool coldStatus = false;
    private bool fastStatus = false;
    private bool stun = false;
    private bool grounded = false;
    private bool onWall = false;
    public bool onIce = false;
    private float FallVecocity = 1;

    public Player playerInstance;

    public int Deaths
    {
        get;
        private set;
    }

    // Use this for initialization
    void Start () 
    {
        _origin = this.transform.position;
        _rigidbody = GetComponent<Rigidbody2D>();
        _collider = GetComponent<BoxCollider2D>();
        _renderer = GetComponent<SpriteRenderer>();
        playerAcceleration_original = playerAcceleration;
        maxPlayerSpeed_original = maxPlayerSpeed;
        playerJumpPower_original = playerJumpPower;
        laser = GetComponentInChildren<MouseAim>();
        originalColor = _renderer.color;
        Deaths = 0;
}

    IEnumerator returnToOriginalStatus()
    {

        yield return new WaitForSeconds(2.5f);
        playerAcceleration = playerAcceleration_original;
        maxPlayerSpeed = maxPlayerSpeed_original;
        playerJumpPower = playerJumpPower_original;
        coldStatus = false;
        fastStatus = false;
    }

    IEnumerator endStun()
    {

        yield return new WaitForSeconds(2);
        stun = false;
    }


    // Update is called once per frame
    void Update () 
    {
        if (stun == false)
        {
            if (Input.GetKey(inputScheme.Shoot))
            {
                laser.ShootLaser();
            }
            else
            {
                laser.TurnOffLaser();
            }

            /*
            if (Input.GetAxis(inputScheme.LeftRightAxis) < 0)
            {
                //_rigidbody.AddForce(Vector2.left * playerAcceleration);
                _rigidbody.velocity = new Vector2(Input.GetAxis(inputScheme.LeftRightAxis) * playerAcceleration, _rigidbody.velocity.y * FallVecocity);
            }
            else if (Input.GetAxis(inputScheme.LeftRightAxis) > 0)
            {
                //_rigidbody.AddForce(Vector2.right * playerAcceleration);
                _rigidbody.velocity = new Vector2(Input.GetAxis(inputScheme.LeftRightAxis) * playerAcceleration, _rigidbody.velocity.y * FallVecocity);
            }
            else
            {
                _rigidbody.velocity = new Vector2(0, _rigidbody.velocity.y);
            }
            */
            /*

            if (inputScheme.Jump == inputScheme.Swap)
            {
                if (Input.GetAxis("LeftHorizontal") < 0)
                {
                    _rigidbody.AddForce(Vector2.left * playerAcceleration);
                    _rigidbody.velocity = new Vector2(Input.GetAxis("LeftHorizontal") * playerAcceleration, _rigidbody.velocity.y * FallVecocity);
                }
                else if (Input.GetAxis("LeftHorizontal") > 0)
                {
                    _rigidbody.AddForce(Vector2.left * playerAcceleration);
                    _rigidbody.velocity = new Vector2(Input.GetAxis("LeftHorizontal") * playerAcceleration, _rigidbody.velocity.y * FallVecocity);
                }
            }
            else
            {
                if (Input.GetAxis(inputScheme.LeftRightAxis) < 0)
                {
                    _rigidbody.AddForce(Vector2.left * playerAcceleration);
                    _rigidbody.velocity = new Vector2(Input.GetAxis("All_Horizontal") * playerAcceleration, _rigidbody.velocity.y * FallVecocity);
                }
                else if (Input.GetAxis(inputScheme.LeftRightAxis) > 0)
                {
                    _rigidbody.AddForce(Vector2.right * playerAcceleration);
                    _rigidbody.velocity = new Vector2(Input.GetAxis("All_Horizontal") * playerAcceleration, _rigidbody.velocity.y * FallVecocity);
                }
            } */

            if (onWall)
            {
                FallVecocity = 0.2f;
            }
            else
            {
                FallVecocity = 1;
            }

            
            if (_rigidbody.velocity.y == 0)
            {
                grounded = true;
            }

            if (grounded)
            {
                /*if(inputScheme.Jump == inputScheme.Swap)
                {
                    if(Input.GetAxis("LeftVertical")>0)
                    {
                        Bounce();
                        grounded = false;
                    }
                }
                else
                {*/
                    if (Input.GetKeyDown(inputScheme.Jump))
                    {
                        Bounce();
                        grounded = false;
                    }
               /* }
                    if (Input.GetAxis("LeftVertical")>0)
                    {
                        Bounce();
                        grounded = false;
                    }
                 * */

                // TODO: different player acceleration in air vs on the ground?

            }
        }

        // set stunned color
        if (stun)
        {
            _renderer.color = stunColor;
        }
        else
        {
            _renderer.color = originalColor;
        }
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("deathArea"))
        {
            playerInstance.Death();
            // TODO: Check to see how many players are still alive,
            // if only 1
            Game.Instance.GameOver("Player 1");
        }
        else if (other.gameObject.CompareTag("head") && _rigidbody.velocity.y < 0)
        {

            Bounce();
            other.GetComponentInParent<PlayerController>().stunPlayer();
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("wall"))
        {
            if (onIce)
            {
                onWall = true;
                grounded = true;
            }
              
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("wall"))
        {
            onWall = false;
        }
    }

    public void ColdStatus()
    {
        if (coldStatus == false)
        {
            playerJumpPower -= playerJumpPower * 0.50f;
            playerAcceleration -= playerAcceleration * 0.60f;
            maxPlayerSpeed -= maxPlayerSpeed * 0.60f;
            StartCoroutine(returnToOriginalStatus());
            coldStatus = true;
        }
    }

    public void FastStatus()
    {
        if (fastStatus == false)
        {
            playerJumpPower += playerJumpPower * 0.50f;
            playerAcceleration += playerAcceleration * 0.50f;
            maxPlayerSpeed += maxPlayerSpeed * 0.80f;
            StartCoroutine(returnToOriginalStatus());
            fastStatus = true;
        }
    }

    public void Bounce()
    {
        _rigidbody.velocity = new Vector2(0, 0);
        _rigidbody.AddForce(Vector2.up * playerJumpPower);
    }

    public void stunPlayer()
    {
        if (stun == false)
        {
            stun = true;
            StartCoroutine(endStun());
        }
    }
}
