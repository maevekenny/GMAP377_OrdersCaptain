using UnityEngine;
using System.Collections;

public class TongueTrap : MonoBehaviour {

    public GameObject wholeTongue;
    private SpriteRenderer _mySpriteRender;
    public Sprite TongueAttack;
    private Sprite originalSprite;
    private bool grabbed = false;
    private Vector3 origin;
    private NewPlayerMovement player;
    public Vector3 tongueOrigin;

    // Use this for initialization
    void Start () {
        originalSprite = GetComponent<SpriteRenderer>().sprite;
        _mySpriteRender = GetComponent<SpriteRenderer>();
        origin = transform.position;
    }
	
	// Update is called once per frame
	void Update () {

        if (grabbed && transform.position.y < origin.y)
        {
            wholeTongue.transform.position = new Vector3(wholeTongue.transform.position.x, wholeTongue.transform.position.y + 0.02f);
            player.transform.position = this.transform.position;
        }

        if (grabbed && transform.position.y >= origin.y)
        {
            grabbed = false;
            GetComponentInParent<MonsterMovement>().eating = false;
            _mySpriteRender.sprite = originalSprite;
            GetComponentInParent<MonsterMovement>().numberOfPlayers--;
            player.KillPlayer();
            GetComponentInParent<MonsterMovement>().ResetTongue();
            wholeTongue.transform.position = new Vector3(wholeTongue.transform.position.x, wholeTongue.transform.position.y - 0.4f);
            GetComponentInParent<MonsterMovement>().ResetMonster();
        }

	}

    public void ResetTongue()
    {
        _mySpriteRender.sprite = originalSprite;
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll != null)
        {
            if (coll.gameObject.CompareTag("Player"))
            {
                player = coll.gameObject.GetComponent<NewPlayerMovement>();
                grabbed = true;
                GetComponentInParent<MonsterMovement>().eating = true;
                _mySpriteRender.sprite = TongueAttack;
                coll.transform.position = this.transform.position;
            }
        }
    }
}
