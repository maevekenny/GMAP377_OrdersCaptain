using UnityEngine;
using System.Collections;

public class ExplosionParticle : MonoBehaviour {

    public Color color;
    private float i = 0;

	// Use this for initialization
	void Start () {
        GetComponent<SpriteRenderer>().color = color;
        GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-100,100),Random.Range(0,400)));
	}
	
	// Update is called once per frame
	void Update () {
        if(i % 5 == 0)
        {
            transform.localScale = new Vector3(transform.localScale.x * .9f, transform.localScale.y * .9f, transform.localScale.z);
        }
        i++;
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll != null)
        {
            if (coll.gameObject.CompareTag("floor"))
            {
                coll.gameObject.GetComponent<PixelPainting>().PaintPoint(color, coll.contacts[0].point, -coll.contacts[0].normal);
                Destroy(this.gameObject);
            }
            if (coll.gameObject.CompareTag("Log"))
            {
                
                Destroy(this.gameObject);
            }
        }
        
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll != null)
        {
            if (coll.gameObject.CompareTag("deathArea"))
            {
                Destroy(this.gameObject);
            }
        }
    }
}
