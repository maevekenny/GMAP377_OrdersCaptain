using UnityEngine;
using System.Collections;

public class FloorCollision : MonoBehaviour {

    public FloorSprites FloorSprites;
    private bool iceFloor = false;
    private bool fastFloor = false;
    private bool bouncyFloor = false;



    IEnumerator changeSprite()
    {

        yield return new WaitForSeconds(5);
        this.GetComponent<SpriteRenderer>().sprite = FloorSprites.NormalFloor;
        setStatusToFalse();


    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("iceLaser"))
        {
            Destroy(other.gameObject);
            if (iceFloor == false) {
                setStatusToFalse();
                iceFloor = true;
                this.GetComponent<SpriteRenderer>().sprite = FloorSprites.IceFloor;
                StartCoroutine(changeSprite());
            }
        }
        else if (other.gameObject.CompareTag("fastLaser")){
            Destroy(other.gameObject);
            if (fastFloor == false) {
                setStatusToFalse();
                fastFloor = true;
                this.GetComponent<SpriteRenderer>().sprite = FloorSprites.FastFloor;
                StartCoroutine(changeSprite());
            }
        }
        else if (other.gameObject.CompareTag("bouncyLaser"))
        {
            Destroy(other.gameObject);
            if (bouncyFloor == false)
            {
                setStatusToFalse();
                bouncyFloor = true;
                this.GetComponent<SpriteRenderer>().sprite = FloorSprites.BouncyFloor;
                StartCoroutine(changeSprite());
            }
        }
        else if (other.gameObject.CompareTag("Player") && iceFloor)
        {
            other.GetComponent<PlayerController>().ColdStatus();
        }
        else if (other.gameObject.CompareTag("Player") && fastFloor)
        {
            other.GetComponent<PlayerController>().FastStatus();
        }
        else if (other.gameObject.CompareTag("Player") && bouncyFloor)
        {
            other.GetComponent<PlayerController>().Bounce();
        }
    }

    void setStatusToFalse()
    {
        iceFloor = false;
        fastFloor = false;
        bouncyFloor = false;
    }
   }
