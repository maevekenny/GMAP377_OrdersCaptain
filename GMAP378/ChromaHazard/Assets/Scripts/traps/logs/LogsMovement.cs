using UnityEngine;
using System.Collections;

public class LogsMovement : MonoBehaviour {

    private bool soundPlaying;

    public float sinkVelocity;
    private bool sink = false;
    private Vector3 origin;

    public GameObject pointCheck_1;
    public GameObject pointCheck_2;
    public LayerMask PlayerLayerMask;

    Collider2D coll;

    public Vector2 gravity = Vector2.down * 0.01f * .5f;

    // Use this for initialization
    void Start () {
        origin = transform.position;
        soundPlaying = false;
    }
	
    
	// Update is called once per frame
	void FixedUpdate () {

        coll = Physics2D.OverlapArea(pointCheck_1.transform.position, pointCheck_2.transform.position, PlayerLayerMask);

        if(coll != null)
        {
            if (coll.gameObject.CompareTag("Player"))
            {
                coll.gameObject.GetComponent<NewPlayerMovement>().SetOnMovablePlatformDown(gravity);
                if (!sink)
                {
                    sink = true;
                    if (!soundPlaying)
                    {
                        StartCoroutine("playSound");
                    }
                }  
            }
        }
        else
        {
            sink = false;
        }

        if (sink)
        {
            transform.Translate(gravity);
			
        }
        else if (!sink && transform.position.y <= origin.y)
        {
            transform.Translate(Vector2.up * 0.01f * .5f);
        }        
	}


    IEnumerator playSound()
    {
        soundPlaying = true;
        SoundManager.instance.PlaySound("log");
        yield return new WaitForSeconds(4f);
        soundPlaying = false;
    }
}
