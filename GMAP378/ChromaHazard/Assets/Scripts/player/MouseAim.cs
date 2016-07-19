using UnityEngine;
using System.Collections;

public class MouseAim : MonoBehaviour {

    private DefaultLaserColors defaultLaserColors;
    private bool isController;

    public Vector2 direction;

    public Transform aim;
    public float laserLength;
    public LayerMask groundLayer;
    public SpriteRenderer gauge;
    public float maxShootTime;
    public float shootRechargeRate; 

    //public Transform shoot;
    public int rotationOffSet = 0;
    public float shootingVelocity = 3;
    bool canShoot = true;
    float rotationZ;

    private Transform laserOrigin;
    private LineRenderer line;
    public Color color = Color.red; // TODO: default color?
    private string ControllerHorizontalAxisStick_2;
    private string ControllerVerticalAxisStick_2;

    private float shootTime;
    private Vector3 maxGaugeSize;
    private bool charging;

    public ParticleSystem particles;

    DataStorage data;
    private bool canRandom = true;

    NewPlayerMovement player;

    public void Start()
    {
        isController = GetComponentInParent<NewPlayerMovement>().inputScheme.IsController;

        player = GetComponentInParent<NewPlayerMovement>();

        ControllerHorizontalAxisStick_2 = GetComponentInParent<NewPlayerMovement>().inputScheme.ControllerHorizontalAxisStick_2;
        ControllerVerticalAxisStick_2 = GetComponentInParent<NewPlayerMovement>().inputScheme.ControllerVerticalAxisStick_2;

        particles = GetComponentInChildren<ParticleSystem>();
        
        laserOrigin = aim;
        
        line = GetComponent<LineRenderer>();
        line.SetColors(color, color);
        line.enabled = false;

        gauge.color = color;
        shootTime = maxShootTime;
        maxGaugeSize = gauge.transform.localScale;
        charging = true;

        data = GameObject.Find("DataStorage").GetComponent<DataStorage>();

        defaultLaserColors = new DefaultLaserColors();
        if(data.defaultLaser == Color.clear)
        {
            UpdateLaserColor(defaultLaserColors.getColors()[Random.Range(0, defaultLaserColors.getColors().Length)]);
        }
        else
        {
            UpdateLaserColor(data.defaultLaser);
        }
        

       
        
    }

    public void RandomizeInk()
    {
        if (Application.loadedLevelName != "PlayerSelection")
        {
            UpdateLaserColor(defaultLaserColors.getColors()[Random.Range(0, defaultLaserColors.getColors().Length)]);
        }
    }

    void Update () {

        if (Time.deltaTime > 0.0000001f)
        {   
            if(Application.loadedLevelName == "PlayerSelection")
            {
                UpdateLaserColor(defaultLaserColors.bounceLaser);
            }
            // using controller input

            if (isController)
            {
                Vector3 gunDirection = Vector3.zero;
                gunDirection.x = Input.GetAxis(ControllerHorizontalAxisStick_2);
                gunDirection.y = Input.GetAxis(ControllerVerticalAxisStick_2);

                direction = gunDirection;
                direction.Normalize();
                direction = new Vector2(direction.x/3, direction.y/3);
                setRotation(gunDirection);
            }

            // using keyboard input

            else
            {
                if (Camera.main != null)
                {
                    Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
                    difference.Normalize();

                    direction = difference;
                    setRotation(difference);
                }
            }

            // recharge laser
            if (charging && shootTime < maxShootTime)
            {
                shootTime += shootRechargeRate * Time.deltaTime;
            }

            // set gauge scaling
            Vector3 gaugeScale = gauge.transform.localScale;
            gaugeScale.x = maxGaugeSize.x * shootTime / maxShootTime;
            gauge.transform.localScale = gaugeScale;
        }
    }

    private void setRotation(Vector3 gunDirection)
    {
        rotationZ = Mathf.Atan2(gunDirection.y, gunDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotationZ + rotationOffSet);
    }

    public void TurnOffLaser()
    {
        charging = true;
        if (line != null)
        {
            line.enabled = false;
        }
        if (particles != null) {
            particles.Stop();
        }
    }

    public void UpdateLaserColor(Color c)
    {
        GetComponentInParent<NewPlayerMovement>().setLaserColor(c);
        color = c;
        line.SetColors(c, c);
        gauge.color = c;
        particles.startColor = c;
    }

    public void ShootLaser()
    {
        // decharge laser
        charging = false;
        if (shootTime <= 0f)
        {
            line.enabled = false;
            SoundManager.instance.PlaySound("laser_down");
            return;
        }

        // turn on laser
        line.enabled = true;
        particles.Play();

        // update laser positions
        float rad = rotationZ * Mathf.Deg2Rad;
        Vector3 origin = laserOrigin.position;
        Vector3 end = new Vector3(
            laserLength * Mathf.Cos(rad), 
            laserLength * Mathf.Sin(rad), 
            origin.z);
        RaycastHit2D hit = Physics2D.Raycast(origin, end, laserLength, groundLayer);
        if (hit.collider != null)
        {
            end = hit.point;
            PixelPainting p;
            if ((p = hit.collider.gameObject.GetComponent<PixelPainting>()) != null)
            {
                // paint ground
                p.PaintPoint(color, hit.point, -hit.normal);
            }
        }

        // update line renderer
        line.SetPosition(0, origin);
        line.SetPosition(1, end);

        // update laser timing fill
        shootTime -= Time.deltaTime;
    }
}
