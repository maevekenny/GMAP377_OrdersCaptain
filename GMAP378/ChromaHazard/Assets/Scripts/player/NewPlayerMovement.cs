using UnityEngine;
using System.Collections;

public class NewPlayerMovement : MonoBehaviour
{

    public GameObject bomb;
    GameObject goBomb;
    public bool canBomb = true;
    private bool bombShot = false;
    private bool isThereBomb = false;

    public bool onMovablePlatformDown = false;

    public Vector2 gravityActual;

    public DefaulNumbers defaultNumbers;

    public GameObject Lives;
    public GameObject number1;
    public GameObject number2;
    public GameObject playerNumberSprite;
    public GameObject letterP;
    public GameObject BombermanHead;

    public GameObject Gun;
    public GameObject LaserGauge;
    private DefaultLaserColors defaultLaserColors;
    private Color originalColor;
    private float alphaValue = .6f;

    SpriteRenderer _myRenderer;
    public Player playerInstance;
    public InputScheme inputScheme;
    private Rigidbody2D _myRigidbody;
    private Animator _myAnimator;
    public GameObject BottomCheck;
    public GameObject SideCheck;
    public GameObject SideCheck_Left;
    public GameObject TopCheck;
    public LayerMask WallLayerMask;
    public LayerMask PlayerLayerMask;
    public LayerMask HeadLayerMask;
    public LayerMask PunchableBlockLayerMask;
    public GameObject handCheck;
    public GameObject back;
    public LayerMask BombLayerMask;

    private float XAxisValue;
    private float YAxisValue;
    private bool PlayingWithController;

    public float velocity = 2;
    private bool increase = false;
    private float acceleration;
    private float slowdown;
    public bool goingRight = true;
    private float decreaseVelocity;
    public float slowDownValue = 0.2f;
    public float acceleratioValue = 0.03f;
    private bool firstSlowdown = true;
    private bool firstAcceleration = false;
    private float velocityBKP;
    private float slowDownValueBKP;
    private float acceleratioValueBKP;

    private bool grounded = false;
    private bool gravityOn = true;

    private bool firstJump = false;
    public float jumpTime = 0.25f;
    public float jumpForce = 8;
    private bool jumping = false;
    private bool jumpCoroutine = false;
    public float slowdownValueOnAir = 0.2f;
    private float slowdownOnAir;
    private float decreaseVelocityOnAir;
    private float jumpForceBKP;

    public float gravityForce = 4;
    private bool falling = false;
    private float accelerationOnAir = 0;
    public float acceleratioValueOnAir = 0.15f;

    private Collider2D collBottom;
    private Collider2D collSide;
    private Collider2D collTop;
    private Collider2D hand;
    private Collider2D stunCollision;
    private Collider2D collSideLeft;

    private MouseAim laser;

    private bool canPlayFallAnimation = true;
    private bool OnLog = false;
    private bool bounceStatus = false;
    public float ResetStatusTime = 5;
    private bool fastStatus = false;
    private bool iceStatus = false;
    private Vector3 origin;
    public bool canMove = true;

    private bool punched = false;
    public float punchForce = 25;
    private float punchDirection;

    private bool stunned = false;
    public float stunTime = 2;
    private bool onConveyorBelt = false;
    private float ConveyorBeltDirection;
    private bool dead = false;

    private bool onGooWall = false;
    private bool enterOnGoo = false;
    private bool enterOnNormalArea = false;

    private int i;

    public GameObject explosionParticle;
    private Color laserColor;
    private bool explosionDelay = false;
    private bool firstExplosion = false;
    private bool offGravity = false;

    private int numberOfLives = 10;

    private bool lastStanding = false;
    private ParticleSystem floorParticles;
    private bool superPunch = false;

    private bool canRandom = true;

    DataStorage data;

    public GameObject NameOverHead;

    private bool dataChecked = false;

    private GameplayCamera screenShake;

    // Use this for initialization
    void Start()
    {


        data = GameObject.Find("DataStorage").gameObject.GetComponent<DataStorage>();

        if (inputScheme.name == "Player 1")
        {
            playerNumberSprite.GetComponent<SpriteRenderer>().sprite = defaultNumbers.GetNumber(1);
        }else if (inputScheme.name == "Player 2")
        {
            playerNumberSprite.GetComponent<SpriteRenderer>().sprite = defaultNumbers.GetNumber(2);
        }
        else if (inputScheme.name == "Player 3")
        {
            playerNumberSprite.GetComponent<SpriteRenderer>().sprite = defaultNumbers.GetNumber(3);
        }
        else if (inputScheme.name == "Player 4")
        {
            playerNumberSprite.GetComponent<SpriteRenderer>().sprite = defaultNumbers.GetNumber(4);
        }


        if (data.gameMode == "Dynamiteman")
        {
            BombermanHead.active = true;
        }

        floorParticles = GetComponentInChildren<ParticleSystem>();
        floorParticles.Stop();

        if (data.superPunch == "Enabled")
        {
            superPunch = true;
        }
        else
        {
            superPunch = false;
        }



        if (data.gameMode == "Survival")
        {
            lastStanding = true;
        }
        else
        {
            lastStanding = false;
        }


        numberOfLives = data.numberOfLives;
        if (numberOfLives >= 19)
        {
            numberOfLives = 19;
        }
        if (numberOfLives >= 10)
        {
            number1.GetComponent<SpriteRenderer>().sprite = defaultNumbers.GetNumber(1);
        }
        if (numberOfLives < 10)
        {
            number1.GetComponent<SpriteRenderer>().sprite = null;
        }
        int aux = numberOfLives;
        if (aux >= 10)
        {
            aux -= 10;
        }
        number2.GetComponent<SpriteRenderer>().sprite = defaultNumbers.GetNumber(aux);

        if (!lastStanding)
        {
            Lives.gameObject.active = false;
        }



        _myRigidbody = GetComponent<Rigidbody2D>();
        _myAnimator = GetComponent<Animator>();
        laser = GetComponentInChildren<MouseAim>();
        PlayingWithController = inputScheme.IsController;
        _myRenderer = GetComponent<SpriteRenderer>();
        defaultLaserColors = new DefaultLaserColors();


        originalColor = inputScheme.color;

        origin = transform.position;
        velocityBKP = velocity;
        slowDownValueBKP = slowDownValue;
        acceleratioValueBKP = acceleratioValue;
        jumpForceBKP = jumpForce;
        GetComponent<SpriteRenderer>().color = inputScheme.color;

        playerNumberSprite.GetComponent<SpriteRenderer>().color = _myRenderer.color;
        letterP.GetComponent<SpriteRenderer>().color = _myRenderer.color;
        screenShake = Camera.main.GetComponent<GameplayCamera>();
    }

    IEnumerator ResetOffGravity()
    {
        yield return new WaitForSeconds(4f);
        offGravity = false;
    }


    IEnumerator ResetInvisibility()
    {
        yield return new WaitForSeconds(4f);
        _myRenderer.color = new Vector4(_myRenderer.color.r, _myRenderer.color.g, _myRenderer.color.b, 1);
    }

    IEnumerator DelayExplosion()
    {
        yield return new WaitForSeconds(0.5f);
        explosionDelay = true;
    }

    IEnumerator ResetPunchAnim()
    {
        yield return new WaitForSeconds(0.5f);
        _myAnimator.SetBool("punch", false);
    }

    IEnumerator ResetPlayer()
    {
        yield return new WaitForSeconds(1.5f);
        _myRenderer.color = originalColor;
        KillPlayer();
    }

    IEnumerator ResetStun()
    {
        yield return new WaitForSeconds(stunTime);
        _myRenderer.color = inputScheme.color;
        i = 0;
        stunned = false;
    }

    IEnumerator ResetStatus()
    {
        yield return new WaitForSeconds(ResetStatusTime);
        fastStatus = false;
        Clear();
    }

    IEnumerator ResetPunch()
    {
        yield return new WaitForSeconds(0.15f);
        punched = false;
    }

    private void SetFallAtributes()
    {
        onMovablePlatformDown = false;
        bounceStatus = false;
        falling = true;
        jumping = false;
        gravityOn = true;
        decreaseVelocityOnAir = 1;
        accelerationOnAir = 0;
    }

    private void SetJumpAtributes()
    {
        _myAnimator.SetBool("walking", false);
        _myAnimator.SetBool("stop", false);
        _myAnimator.SetBool("falling", false);
        _myAnimator.SetBool("sliding", false);
        _myAnimator.SetBool("punch", false);


        onMovablePlatformDown = false;
        decreaseVelocityOnAir = 1;
        slowdownOnAir = 1;
        _myAnimator.SetBool("jumping", true);
        firstJump = true;
        jumping = true;
        falling = false;
        grounded = false;
        gravityOn = false;
        jumpCoroutine = false;
    }

    IEnumerator StartToFall()
    {
        yield return new WaitForSeconds(jumpTime);
        SetFallAtributes();
    }

    IEnumerator RandomizeInk()
    {
        yield return new WaitForSeconds(1);
        canRandom = true;
    }

    // Update is called once per frame
    void Update()
    {

        if (!grounded && !onMovablePlatformDown)
        {
            _myAnimator.SetBool("jumping", true);
        }
        else {
            _myAnimator.SetBool("jumping", false);
        }

        if (Time.deltaTime > 0.0000001f)
        {

            if (GameObject.Find("DataStorage").GetComponent<DataStorage>().randomInk == "Enabled" && canRandom) //Dont use variable data here ... it will stop work ink random ... i need to fix it later
            {
                canRandom = false;
                if (GetComponentInChildren<MouseAim>() != null)
                {
                    GetComponentInChildren<MouseAim>().RandomizeInk();
                }
                StartCoroutine("RandomizeInk");
            }


            BombermanHead.GetComponent<SpriteRenderer>().color = _myRenderer.color;
            if (goBomb != null)
            {
                if (GetComponentInChildren<MouseAim>() != null)
                {
                    goBomb.transform.position = GetComponentInChildren<MouseAim>().aim.position;
                    goBomb.transform.rotation = Quaternion.Euler(0f, 0f, Mathf.Atan2(GetComponentInChildren<MouseAim>().direction.y, GetComponentInChildren<MouseAim>().direction.x) * Mathf.Rad2Deg);
                }
            }

            if (canMove)
            {

                //---------------------- Begin Move Character ------------------------------
                XAxisValue = (int)(Input.GetAxisRaw(inputScheme.ControllerHorizontalAxisStick_1));
                YAxisValue = (int)(Input.GetAxisRaw(inputScheme.ControllerVerticalAxisStick_1));

                if ((Input.GetKey(inputScheme.Right) && !PlayingWithController) || (XAxisValue == 1 && PlayingWithController))
                {
                    if (goingRight && (!collSide && !stunned && !punched))
                    {
                        _myAnimator.SetBool("walking", true);
                        transform.Translate(Vector2.right * 0.01f * acceleration * velocity);
                    }
                    goingRight = true;
                }

                if ((Input.GetKey(inputScheme.Left) && !PlayingWithController) || (XAxisValue == -1 && PlayingWithController))
                {
                    if (!goingRight && (!collSide && !stunned && !punched))
                    {
                        _myAnimator.SetBool("walking", true);
                        transform.Translate(Vector2.left * 0.01f * acceleration * velocity * -1);
                    }
                    goingRight = false;
                }
                //---------------------- End Move Character -----------------------------

                //------------------------- Begin Set Acceleration -----------------------
                if ((((Input.GetKeyDown(inputScheme.Right) || Input.GetKeyDown(inputScheme.Left)) && !PlayingWithController) || (XAxisValue != 0 && !firstAcceleration && PlayingWithController)) && !stunned)
                {

                    firstSlowdown = false;
                    firstAcceleration = true;
                    increase = true;
                    acceleration = 0;
                    _myAnimator.SetBool("walking", true);
                }
                //------------------------- End Set Acceleration -----------------------

                //------------------------- Begin Set Slowdown ------------------------------
                if (((Input.GetKeyUp(inputScheme.Right) || Input.GetKeyUp(inputScheme.Left)) && !PlayingWithController) || (XAxisValue == 0 && !firstSlowdown && PlayingWithController))
                {

                    firstSlowdown = true;
                    firstAcceleration = false;
                    slowdown = 1;
                    increase = false;
                    _myAnimator.SetBool("walking", false);
                    float timeAux = 0;
                    if (slowDownValue >= 1)
                    {
                        timeAux = 1;
                    }
                    else
                    {
                        if (slowDownValue < 0.1)
                        {
                            timeAux = (1 - slowDownValue) * 1.5f;
                        }
                        else if (slowDownValue <= 0.025)
                        {
                            timeAux = (1 - slowDownValue) * 2f;
                        }
                        else
                        {
                            timeAux = (1 - slowDownValue);
                            timeAux -= timeAux * 0.3f;
                        }
                    }
                }
                //------------------------- End Set Slowdown ------------------------------

                //------------- Begin Acceleration and Slowdown ----------------
                if (increase)
                {
                    decreaseVelocity = 0;
                    acceleration += acceleratioValue;
                    if (acceleration >= 1)
                    {
                        acceleration = 1;
                    }
                    if (jumping || falling)
                    {
                        acceleration = 1;
                    }
                }
                else
                {
                    decreaseVelocity += 1;
                    if (decreaseVelocity % 3 == 0)
                    {
                        slowdown -= slowDownValue;
                    }

                    if (slowdown <= 0)
                    {
                        slowdown = 0;
                    }

                    if (goingRight && slowdown > 0 && !collSide && !stunned && !punched)
                    {
                        transform.Translate(Vector2.right * 0.01f * slowdown);
                    }
                    else if (!goingRight && slowdown > 0 && !collSide && !stunned && !punched)
                    {
                        transform.Translate(Vector2.left * 0.01f * slowdown * -1);
                    }
                }
                //------------------ End Acceleration and Slowdown ----------------------

                //------------------ Begin Jumping -------------------------------------
                if (jumping)
                {
                    decreaseVelocityOnAir += 1;
                    if (decreaseVelocityOnAir % 5 == 0)
                    {
                        slowdownOnAir -= slowdownValueOnAir;
                    }
                    if (slowdownOnAir <= 0)
                    {
                        slowdownOnAir = 0;
                    }
                    if (!bounceStatus)
                    {
                        transform.Translate(Vector2.up * 0.01f * jumpForce * slowdownOnAir);
                    }
                    else if (bounceStatus)
                    {
                        transform.Translate(Vector2.up * 0.01f * jumpForce * 1.5f * slowdownOnAir);
                    }

                    if (!jumpCoroutine)
                    {
                        StartCoroutine("StartToFall");
                        jumpCoroutine = true;
                    }

                }
                if ((Input.GetKeyDown(inputScheme.Jump)) && !stunned) // && !PlayingWithController || (YAxisValue == -1 && PlayingWithController && !firstJump)
                {
                    if ((!jumping && !falling) || grounded || onMovablePlatformDown || onGooWall)
                    {
                        SoundManager.instance.PlaySound("jump");
                        SetJumpAtributes();
                    }
                }
                if ((Input.GetKeyUp(inputScheme.Jump) && PlayingWithController && firstJump) || (YAxisValue == 0 && PlayingWithController && firstJump)) // && !PlayingWithController
                {
                    firstJump = false;
                }
                //------------------ End Jumping -------------------------------------

                //------------------ Begin Falling -------------------------------------
                if ((falling || !grounded) && !jumping && !onMovablePlatformDown)
                {
                    _myAnimator.SetBool("jumping", false);
                    if (canPlayFallAnimation)
                    {
                        _myAnimator.SetBool("falling", true);
                    }
                }
                //------------------ End Falling -------------------------------------

                //---------------------- Begin Collisions Check, Also Gravity ------------------------------
                collBottom = Physics2D.OverlapCircle(BottomCheck.transform.position, 0.05f, WallLayerMask);
                collSide = Physics2D.OverlapCircle(SideCheck.transform.position, 0.05f, WallLayerMask);
                collSideLeft = Physics2D.OverlapCircle(SideCheck_Left.transform.position, 0.05f, WallLayerMask);
                collTop = Physics2D.OverlapCircle(TopCheck.transform.position, 0.01f, WallLayerMask);
                stunCollision = Physics2D.OverlapCircle(BottomCheck.transform.position, 0.05f, HeadLayerMask);


                if (collSide && collSide != null)
                {
                    if (collSide.gameObject.CompareTag("floor"))
                    {
                        if (collSide.gameObject.GetComponent<PixelPainting>().MyActualColor() == defaultLaserColors.gooLaser)
                        {
                            if (!enterOnGoo)
                            {
                                accelerationOnAir = 0;
                                enterOnGoo = true;
                            }
                            enterOnNormalArea = false;
                            onGooWall = true;
                            _myAnimator.SetBool("sliding", true);
                        }
                        else
                        {
                            _myAnimator.SetBool("sliding", false);
                        }
                    }
                }
                else
                {
                    if (!enterOnNormalArea)
                    {
                        accelerationOnAir = 0;
                        enterOnNormalArea = true;
                    }
                    enterOnGoo = false;
                    onGooWall = false;
                    _myAnimator.SetBool("sliding", false);
                }

                if (falling && !jumping)
                {
                    if (stunCollision != null)
                    {
                        if (stunCollision.gameObject.CompareTag("head") && Physics2D.OverlapCircle(new Vector2(TopCheck.transform.position.x, TopCheck.transform.position.y + 0.1f), 0.1f, WallLayerMask) == null)
                        {
                            Bounce();
                            stunCollision.gameObject.GetComponentInParent<NewPlayerMovement>().SetStun();
                        }
                    }
                }

                if (collTop)
                {
                    StopCoroutine("StartToFall");
                    SetFallAtributes();
                }

                if (!collBottom)
                {
                    falling = true;
                    grounded = false;
                    if (gravityOn)
                    {
                        decreaseVelocityOnAir += 1;
                        if (decreaseVelocityOnAir % 2 == 0)
                        {
                            accelerationOnAir += acceleratioValueOnAir;
                        }
                        if (slowdownOnAir >= 3)
                        {
                            accelerationOnAir = 3;
                        }
                        if (!onGooWall)
                        {
                            if (!onMovablePlatformDown)
                            {
                                gravityActual = (Vector2.down * 0.01f * gravityForce * accelerationOnAir);
                            }

                            transform.Translate(gravityActual);
                        }
                        else
                        {
                            if (!onMovablePlatformDown)
                            {
                                gravityActual = (Vector2.down * 0.01f * gravityForce * accelerationOnAir * 0.05f);
                            }

                            transform.Translate(gravityActual);
                        }

                    }
                }
                else
                {
                    if (collBottom != null)
                    {
                        if (collBottom.gameObject.CompareTag("floor") || collBottom.gameObject.CompareTag("notPaintableFloor") || collBottom.gameObject.CompareTag("conveyorBelt"))
                        {
                            _myAnimator.SetBool("jumping", false);
                            jumpCoroutine = false;
                            grounded = true;
                            falling = false;
                            accelerationOnAir = 0;
                            _myAnimator.SetBool("falling", false);

                        }
                        if (collBottom.gameObject.CompareTag("conveyorBelt") && !dead)
                        {
                            onConveyorBelt = true;
                            if ((collBottom.gameObject.GetComponent<ConveyorbeltMovement>().RightDirection == true))
                            {
                                ConveyorBeltDirection = 1;
                            }
                            else
                            {
                                ConveyorBeltDirection = -1;
                            }
                        }
                        if (collBottom.gameObject.CompareTag("floor") || collBottom.gameObject.CompareTag("notPaintableFloor"))
                        {
                            onConveyorBelt = false;
                        }
                    }
                    else
                    {

                        onConveyorBelt = false;
                    }

                    hand = Physics2D.OverlapCircle(handCheck.transform.position, 0.08f, BombLayerMask);
                    if (hand != null)
                    {
                        if (hand.gameObject.CompareTag("bomb") && data.pickableBombs == "Enabled")
                        {
                            if (canBomb && hand.gameObject.GetComponent<Bomb>().picket == false)
                            {
                                Destroy(hand.gameObject);
                                isThereBomb = true;
                                bombShot = false;
                                canBomb = false;
                                goBomb = (GameObject)Instantiate(bomb, this.transform.position, this.transform.rotation);
                                goBomb.active = true;
                                goBomb.transform.parent = GetComponentInChildren<MouseAim>().transform;
                                goBomb.transform.position = GetComponentInChildren<MouseAim>().aim.position;
                                goBomb.transform.rotation = Quaternion.Euler(0f, 0f, Mathf.Atan2(GetComponentInChildren<MouseAim>().direction.y, GetComponentInChildren<MouseAim>().direction.x) * Mathf.Rad2Deg);
                                goBomb.GetComponent<Bomb>().ChangeLayerToIgnore();
                                goBomb.GetComponent<Bomb>().picket = true;
                            }
                        }
                    }

                }
                //---------------------- End Collisions Check, Also Gravity ------------------------------

                //----------------------- Begin Shoot --------------------------------------------
                if (Input.GetKey(inputScheme.Shoot) && !stunned)
                {
                    laser.ShootLaser();

                    SoundManager.instance.StartLoopedSound("laser_shoot", 0.2f);

                    if (!bombShot && isThereBomb)
                    {
                        isThereBomb = false;
                        bombShot = true;
                        canBomb = true;
                        goBomb.GetComponent<Bomb>().ResetBomb();
                        goBomb.GetComponent<Bomb>().ShootBomb(GetComponentInChildren<MouseAim>().direction);

                        goBomb = null;
                    }


                }
                else
                {
                    SoundManager.instance.StopLoopedSound();
                    laser.TurnOffLaser();
                }
                //----------------------- End Shoot --------------------------------------------

                //-------------------- Begin Punch ---------------------------------------


                if (Input.GetKey(inputScheme.Punch))
                {
                    hand = Physics2D.OverlapCircle(handCheck.transform.position, 0.04f, PlayerLayerMask);
                    if (hand)
                    {
                        if (!superPunch)
                        {
                            if (goingRight)
                            {
                                hand.gameObject.GetComponent<NewPlayerMovement>().SetPunch(1);
                            }
                            else
                            {
                                hand.gameObject.GetComponent<NewPlayerMovement>().SetPunch(-1);
                            }
                        }
                        if (superPunch)
                        {
                            hand.gameObject.GetComponent<NewPlayerMovement>().DeathAreaCollision("punch");
                        }


                    }

                    hand = Physics2D.OverlapCircle(handCheck.transform.position, 0.04f, BombLayerMask);
                    if (hand)
                    {
                        if (goingRight)
                        {
                            hand.gameObject.GetComponent<Bomb>().ActivateBomb(1);
                        }
                        else
                        {
                            hand.gameObject.GetComponent<Bomb>().ActivateBomb(-1);
                        }
                    }

                    //----- for punching blocks in main menu -----
                    var block = Physics2D.OverlapCircle(handCheck.transform.position, 0.04f, PunchableBlockLayerMask);
                    if (block)
                    {
                        block.gameObject.GetComponent<PunchableMenuBlock>().Punch();
                    }
                }

                //---------------------- End Punch --------------------------------------

                //------------------ Begin Rotate Animation Side ------------------------
                if (goingRight)
                {
                    transform.eulerAngles = new Vector3(0, 0, 0);
                    NameOverHead.transform.eulerAngles = new Vector3(0, 0, 0);
                    Lives.transform.eulerAngles = new Vector3(0, 0, 0);
                    
                }

                else if (!goingRight)
                {
                    transform.eulerAngles = new Vector3(0, 180, 0);
                    NameOverHead.transform.eulerAngles = new Vector3(0, 0, 0);
                    Lives.transform.eulerAngles = new Vector3(0, 0, 0);
                    
                }
                //----------------- End Rotate Animation Side ----------------------------

                if (offGravity)
                {
                    transform.eulerAngles = new Vector3(180, transform.eulerAngles.y, 0);
                }

                //------------------ Begin Effects -------------------------------------
                if (iceStatus)
                {
                    if (goingRight)
                    {
                        transform.Translate(Vector2.right * 0.01f * velocityBKP * 0.3f);
                    }
                    else
                    {
                        transform.Translate(Vector2.left * 0.01f * velocityBKP * 0.3f * -1);
                    }
                }


            }// <----------- This is from the first if of the code (canMove && !punched) DONT MOVE

            if (Input.GetKeyDown(inputScheme.Punch))
            {
                StopCoroutine("ResetPunchAnim");
                _myAnimator.SetBool("punch", true);
                SoundManager.instance.PlaySound("punch");
                StartCoroutine("ResetPunchAnim");
            }

            if (punched)
            {
                float aux = 1;
                if (GetComponentInChildren<MouseAim>() != null)
                {
                    GetComponentInChildren<MouseAim>().GetComponentInChildren<ParticleSystem>().Play();
                }
                StartCoroutine("ResetPunch");
                if (collSide || collSideLeft)
                {
                    StopCoroutine("ResetPunch");
                    punched = false;
                }
                if (collBottom == null)
                {
                    aux = 0.5f;
                }
                if (goingRight && !collSide && !collSideLeft)
                {
                    transform.Translate(Vector2.right * 0.01f * punchForce * 0.3f * punchDirection * aux);
                }
                else if (!goingRight && !collSide && !collSideLeft)
                {
                    transform.Translate(Vector2.left * 0.01f * punchForce * 0.3f * punchDirection * aux);
                }
            }

            if (stunned)
            {
                if (i % 10 == 0)
                {
                    _myRenderer.color = Color.clear;
                }
                else
                {
                    _myRenderer.color = inputScheme.color;
                }
                i++;
            }

            if (onConveyorBelt && !dead)
            {
                if (goingRight)
                {
                    transform.Translate(Vector2.right * 0.01f * velocityBKP * 0.3f * ConveyorBeltDirection);
                }
                else
                {
                    transform.Translate(Vector2.left * 0.01f * velocityBKP * 0.3f * ConveyorBeltDirection);
                }
            }

            //----XXXXX
            if (jumping || falling || XAxisValue == 0 || !Input.GetKey(inputScheme.Right) || !Input.GetKey(inputScheme.Left))
            {
                StopParticles();
            }


            //-------------------- End Effects -------------------------------------

            //--------------------- Begin Explosion Particles ----------------------
            if (explosionDelay && !firstExplosion)
            {
                firstExplosion = true;
                int aux = 0;
                for (aux = 0; aux < 200; aux++)
                {
                    GameObject ep = (GameObject)Instantiate(explosionParticle, transform.position, transform.rotation);
                    ep.active = true;
                    ep.GetComponent<ExplosionParticle>().color = laserColor;

                    SoundManager.instance.PlaySound("explode");
                    screenShake.ShakeForSeconds(1.2f);
                }
            }
            //------------------ End Explosion Particles --------------------------
        }
    }

    //--------------------- Begin Status ---------------------------------- 
    public void ClearMovementStatus()
    {
        iceStatus = false; //I call Clear every time that the player step on ink ... so, in order to keep pushing the player while he is on ice ... it is necessary to create other function to reset some attributes
    }

    public void AddLife()
    {
        if (lastStanding)
        {
            numberOfLives++;
            if (numberOfLives >= 19)
            {
                numberOfLives = 19;
            }
            if (numberOfLives >= 10)
            {
                number1.GetComponent<SpriteRenderer>().sprite = defaultNumbers.GetNumber(1);
            }
            int aux = numberOfLives;
            if (aux >= 10)
            {
                aux -= 10;
            }
            number2.GetComponent<SpriteRenderer>().sprite = defaultNumbers.GetNumber(aux);
        }
    }

    public void PlayParticles(Color color)
    {
        if (!(!Input.GetKey(inputScheme.Right) && !Input.GetKey(inputScheme.Left)) || XAxisValue != 0 || onGooWall)
        {
            floorParticles.startColor = color;
            floorParticles.Play();
        }
    }

    public void StopParticles()
    {
        floorParticles.Stop();
    }

    public void Clear()
    {
        if (!fastStatus)
        {
            velocity = velocityBKP;
            slowDownValue = slowDownValueBKP;
            acceleratioValue = acceleratioValueBKP;
            jumpForce = jumpForceBKP;
        }
    }

    public void GooStatus()
    {
        iceStatus = false;
        fastStatus = false;
        Clear();
        StopCoroutine("ResetStatus");
        velocity = 1.5f;
        acceleratioValue = 0.1f;
        slowDownValue = 0.8f;
        StartCoroutine("ResetStatus");
    }

    public void ColdStatus()
    {
        iceStatus = true;
        fastStatus = false;
        Clear();
        StopCoroutine("ResetStatus");
        velocity = 2.5f;
        acceleratioValue = 0.003f;
        slowDownValue = 0.003f;
		jumpForce = jumpForce * 0.75f;
        StartCoroutine("ResetStatus");
    }

    public void FastStatus()
    {
        iceStatus = false;
        fastStatus = false;
        Clear();
        StopCoroutine("ResetStatus");
        velocity = 3f;
        acceleratioValue = 0.3f;
        slowDownValue = 0.8f;
        jumpForce = jumpForce * 1.3f;
        fastStatus = true;
        StartCoroutine("ResetStatus");
    }

    public void Bounce()
    {
        iceStatus = false;
        fastStatus = false;
        Clear();
        bounceStatus = true;
        SetJumpAtributes();
    }

    public void KillPlayer()
    {
        if (lastStanding)
        {
            numberOfLives--;
            if (numberOfLives < 10)
            {
                number1.GetComponent<SpriteRenderer>().sprite = null;
            }

            number2.GetComponent<SpriteRenderer>().sprite = defaultNumbers.GetNumber(numberOfLives);
        }

        _myAnimator.SetBool("dead", false);
        if (numberOfLives > 0)
        {
            StopAllCoroutines();

            if (GetComponentInChildren<PowerCellBehavior>() != null)
            {
                GetComponentInChildren<PowerCellBehavior>().PlayerIsDead();

            }

            if (data.gameMode == "Dynamiteman")
            {
                BombermanHead.active = true;

            }
            if (goBomb != null)
            {
                Destroy(goBomb.gameObject);
            }
            NameOverHead.active = true;
            goBomb = null;
            canBomb = true;
            bombShot = false;
            isThereBomb = false;
            onMovablePlatformDown = false;
            iceStatus = false;
            canRandom = true;
            offGravity = false;
            stunned = false;
            firstExplosion = false;
            explosionDelay = false;
            dead = false;
            Gun.active = true;
            LaserGauge.active = true;
            canMove = true;
            GetComponent<Collider2D>().enabled = true;
            if (lastStanding)
            {
                Lives.active = true;
            }
            _myAnimator.SetBool("walking", false);
            _myAnimator.SetBool("stop", false);
            _myAnimator.SetBool("jumping", false);
            _myAnimator.SetBool("falling", false);
            _myAnimator.SetBool("sliding", false);
            _myAnimator.SetBool("punch", false);

            transform.position = origin;
        }
        else
        {
            this.gameObject.active = false;
        }
    }

    public void SetPunch(float direction)
    {
        punched = true;
        punchDirection = direction;
    }

    public void SetOnMovablePlatformDown(Vector2 vecGravity)
    {
        onMovablePlatformDown = true;
        gravityActual = vecGravity;
    }

    public void SetStun()
    {
        if (!stunned)
        {
            stunned = true;
            StartCoroutine("ResetStun");
        }
    }

    public void setLaserColor(Color color)
    {
        laserColor = color;
    }

    public bool isDead()
    {
        return dead;
    }

    public void SetInvisibility()
    {
        StopCoroutine("ResetInvisibility");
        _myRenderer.color = new Vector4(_myRenderer.color.r, _myRenderer.color.g, _myRenderer.color.b, .25f);
        StartCoroutine("ResetInvisibility");
    }

    public void SetOffGravity()
    {
        StopCoroutine("ResetOffGravity");
        offGravity = true;
        StartCoroutine("ResetOffGravity");
    }

    public void DeathAreaCollision(string name)
    {
        NameOverHead.active = false;
        BombermanHead.active = false;
        canMove = false;
        _myRenderer.color = new Vector4(_myRenderer.color.r, _myRenderer.color.g, _myRenderer.color.b, alphaValue);
        _myAnimator.SetBool("dead", true);
        Gun.active = false;
        LaserGauge.active = false;

        switch (name)
        {
            case "Gears":
                SoundManager.instance.PlaySound("gear");
                break;
            case "sawblade2":
                SoundManager.instance.PlaySound("saw");
                break;
        }

        if (!dead)
        {
            Lives.active = false;
            GetComponent<Collider2D>().enabled = false;
            StartCoroutine("DelayExplosion");
            StartCoroutine("ResetPlayer");
            dead = true;
        }
    }
    //--------------------- End Status ---------------------------------- 

    //----------------------- Begin Trigger Collisions Check --------------------

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("deathArea"))
        {
            DeathAreaCollision(other.gameObject.name);

            //playerInstance.Death();
            //Game.Instance.GameOver("PLayer Name");
        }
        else if (other.gameObject.CompareTag("deathBombArea"))
        {
            if (data.gameMode == "Dynamiteman")
            {
                Destroy(this.gameObject);
            }
            else {
                DeathAreaCollision(other.gameObject.name);
            }
        }
        else if (other.gameObject.CompareTag("Log"))
        {
            canPlayFallAnimation = false;
            OnLog = true;
        }
        else if (other.gameObject.CompareTag("tongue"))
        {
            canMove = false;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Log"))
        {
            canPlayFallAnimation = true;
            OnLog = false;
        }
    }

    //----------------------- End Trigger Collisions Check --------------------


}
