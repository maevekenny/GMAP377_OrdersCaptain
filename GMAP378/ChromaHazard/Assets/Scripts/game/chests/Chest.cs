using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Chest : MonoBehaviour {

    public bool open = false;
    private bool opened = false;

    public GameObject empty;

    public GameObject bounceLaser;
    public GameObject fastLaser;
    public GameObject iceLaser;
    public GameObject gooLaser;
    public GameObject eraserLaser;
    public GameObject invisibility;
    public GameObject revertGravity;
    public GameObject lives;

    public string bounceLaserEnabled;
    public string fastLaserEnabled;
    public string iceLaserEnabled;
    public string gooLaserEnabled;
    public string eraserLaserEnabled;
    public string invisibilityEnabled;
    public string revertGravityEnabled;
    public string livesEnabled;

    private bool isBomb = false;

    List<GameObject> items = new List<GameObject>();
    public GameObject warning;
    public GameObject bomb;

    DataStorage data;

	// Use this for initialization
	void Start () {
        data = GameObject.Find("DataStorage").GetComponent<DataStorage>();


      bounceLaserEnabled = data.bounceLaserEnabled;
      fastLaserEnabled= data.fastLaserEnabled;
      iceLaserEnabled = data.iceLaserEnabled;
      gooLaserEnabled = data.gooLaserEnabled;
      eraserLaserEnabled = data.eraserLaserEnabled;
      invisibilityEnabled = data.invisibilityEnabled;
      revertGravityEnabled = data.revertGravityEnabled;
      livesEnabled = data.livesEnabled;

        if (bounceLaserEnabled == "Enabled")
        {
            items.Add(bounceLaser);
            items.Add(bounceLaser);
        }
         if (fastLaserEnabled == "Enabled")
        {
            items.Add(fastLaser);
            items.Add(fastLaser);
        }
         if (iceLaserEnabled == "Enabled")
        {
            items.Add(iceLaser);
            items.Add(iceLaser);
        }
         if (gooLaserEnabled == "Enabled")
        {
            items.Add(gooLaser);
            items.Add(gooLaser);
        }
         if (eraserLaserEnabled == "Enabled")
        {
            items.Add(eraserLaser);
            items.Add(eraserLaser);
        }
         if (invisibilityEnabled == "Enabled")
        {
            items.Add(invisibility);
        }
         if (revertGravityEnabled == "Enabled")
        {
            items.Add(revertGravity);
        }
         if (livesEnabled == "Enabled")
        {
            items.Add(lives);
        }

    }

    IEnumerator deleteChest()
    {
        yield return new WaitForSeconds(1f);
        Destroy(this.gameObject);
    }

        IEnumerator openChest()
    {
        
        yield return new WaitForSeconds(0.4f);
        warning.active = false;
        GameObject go = (GameObject)Instantiate(empty, new Vector2(transform.position.x, transform.position.y + 0.7f), transform.rotation); ;

        if (items.Count != 0)
        {
            go = (GameObject)Instantiate(items[Random.Range(0, items.Count)], new Vector2(transform.position.x, transform.position.y + 0.7f), transform.rotation);
            
        }

        if (data.bomb == "Enabled")
        {
            if (Random.Range(0, 4) == 1)
            {
                go = (GameObject)Instantiate(bomb, new Vector2(transform.position.x, transform.position.y + 0.7f), transform.rotation);
                isBomb = true;
            }

        }

        if (data.gameMode == "Dynamiteman")
        {
            go = (GameObject)Instantiate(bomb, new Vector2(transform.position.x, transform.position.y + 0.7f), transform.rotation);
            isBomb = true;


        }


        go.active = true;
        if (isBomb)
        {
            go.GetComponent<Bomb>().StartBombBehavior();
        }

    }

    // Update is called once per frame
    void Update () {

        if (open)
        {
            if (!opened)
            {
                opened = true;                
                StartCoroutine("openChest");
                StartCoroutine("deleteChest");
            }
        }

	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            open = true;
            GetComponent<Animator>().SetBool("open", true);
        }
    }
}
