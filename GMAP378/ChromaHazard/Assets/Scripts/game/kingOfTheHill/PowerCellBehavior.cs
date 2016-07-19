using UnityEngine;
using System.Collections;

public class PowerCellBehavior : MonoBehaviour {

    NewPlayerMovement player = null;
    Timer timer;
    public GameObject bright;
    private bool onPlayer = false;

    IEnumerator TeleportReverseDelay()
    {
        yield return new WaitForSeconds(.5f);
        GetComponent<Animator>().SetBool("TeleportReverse", false);
    }

    IEnumerator TeleportDelay()
    {
        this.transform.position = GameObject.Find("PowerCellSpawnPositions").gameObject.GetComponent<PowerCellSpawnPos>().getPowerCellPosition().transform.position;
        yield return new WaitForSeconds(.5f);
        GetComponent<Animator>().SetBool("Teleport", false);
        GetComponent<Animator>().SetBool("TeleportReverse", true);
        StartCoroutine("TeleportReverseDelay");
    }

    // Use this for initialization
    void Start () {
        GetComponent<Animator>().SetBool("TeleportReverse", true);
        StartCoroutine("TeleportReverseDelay");
        timer = GameObject.Find("Timer").GetComponent<Timer>();
        bright.GetComponent<SpriteRenderer>().color = Color.red;
    }
	
	// Update is called once per frame
	void Update () {
	if(player != null)
        {
            if (player.isDead())
            {
                PlayerIsDead();
            }
        }
        if (timer.getTime() <= 0)
        {
            GameObject.Find("DataStorage").GetComponent<DataStorage>().lastLevel = Application.loadedLevel;
            GameObject.Find("DeathsController").GetComponent<LastStanding>().EndGame(player);
        }

    }

    public void PlayerIsDead()
    {
        this.gameObject.layer = LayerMask.NameToLayer("PowerCell");
        
        player = null;
        this.transform.parent = null;
        timer.DisableTimer();
        bright.GetComponent<SpriteRenderer>().color = Color.red;
        
        onPlayer = false;
        ResetPowerCell();
    }

    public void ResetPowerCell()
    {
        this.gameObject.layer = LayerMask.NameToLayer("PowerCell");
        this.transform.parent = null;
        GetComponent<Animator>().SetBool("Teleport", true);
        StartCoroutine("TeleportDelay");
        
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll != null)
        {
            if (coll.gameObject.CompareTag("Player") && !onPlayer)
            {
                this.gameObject.layer = LayerMask.NameToLayer("IgnoreEverything");
                onPlayer = true;
                player = coll.gameObject.GetComponent<NewPlayerMovement>();
                this.transform.position = player.GetComponent<NewPlayerMovement>().back.transform.position;
                this.transform.parent = player.transform;
                bright.GetComponent<SpriteRenderer>().color = player.GetComponent<SpriteRenderer>().color;
                if (player != null)
                {
                    timer.ActiveTimer(player.GetComponent<SpriteRenderer>().color);
                }
                
            }
            if (coll.gameObject.CompareTag("deathArea"))
            {

                ResetPowerCell();
            }
        }
    }
}
