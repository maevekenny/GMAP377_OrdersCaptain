using UnityEngine;
using System.Collections;

public class ArrowsMovement : MonoBehaviour {

    Vector3 origin;
    public float velocity;
    public bool movement = true;
    public float DelayWaitTime;
    public float RespawnWaitTime;
    public bool right;
    private Rigidbody2D _myRigidbody;
    private SpriteRenderer spriteRender;
	private bool hasPlayedSound;

    // Use this for initialization
    void Start () {
        origin = transform.position;
        _myRigidbody = GetComponent<Rigidbody2D>();
        GetComponent<Collider2D>().enabled = false;
        StartCoroutine("Delay");
        spriteRender = GetComponent<SpriteRenderer>();
    }

    IEnumerator Delay()
    {
        
        this.transform.position = origin;
        yield return new WaitForSeconds(DelayWaitTime);
        movement = true;
        GetComponent<Collider2D>().enabled = true;

    }

    IEnumerator Respawn()
    {
        yield return new WaitForSeconds(RespawnWaitTime);
        spriteRender.enabled = true;
		hasPlayedSound = false;
        StartCoroutine(Delay());
    }

    // Update is called once per frame
    void Update () {
       
            if (right && movement)
            {
				if (!hasPlayedSound) {
					SoundManager.instance.PlaySound ("arrow");	
					hasPlayedSound = true;
				}
                _myRigidbody.velocity = new Vector2(velocity, 0);
				
            }
            else if(!right && movement)
            {
				if (!hasPlayedSound) {
					SoundManager.instance.PlaySound ("arrow");	
					hasPlayedSound = true;
				}
                _myRigidbody.velocity = new Vector2(velocity * -1, 0);
            }
            else
            {
            _myRigidbody.velocity = new Vector2(0, 0);
            }
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll != null)
        {
            if (coll.gameObject.CompareTag("floor"))
            {      
                this.movement = false;
                GetComponent<Collider2D>().enabled = false;
                spriteRender.enabled = false;
                StartCoroutine("Respawn");
            }
        }
    }
}
