using UnityEngine;
using System.Collections;

public class MonsterMovement : MonoBehaviour {

    public GameObject tongue;
    public Vector3 tongueOrigin;
    private SpriteRenderer _mySpriteRender;
    public Sprite MonsterAttack;
    private Sprite originalSprite;
    private bool sink = false;
    private Vector3 origin;
    private bool moved = false;
    private bool attack = false;
    private int i = 0;
    public int numberOfPlayers = 0;
    public bool eating = false;

    public GameObject pointCheck_1;
    public GameObject pointCheck_2;
    public LayerMask PlayerLayerMask;
    Collider2D coll;
    // Use this for initialization
    void Start () {
        origin = transform.position;
        originalSprite = GetComponent<SpriteRenderer>().sprite;
        _mySpriteRender = GetComponent<SpriteRenderer>();
        tongueOrigin = tongue.transform.position;
    }
	
    
	// Update is called once per frame
	void Update () {

        coll = Physics2D.OverlapArea(pointCheck_1.transform.position, pointCheck_2.transform.position, PlayerLayerMask);

        if (coll != null)
        {
            if (coll.gameObject.CompareTag("Player"))
            {
                if (!moved)
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y - 0.4f);
                    moved = true;
                    attack = true;
                }
                _mySpriteRender.sprite = MonsterAttack;
            }
        }
        else
        {
            if (!eating)
            {
                ResetMonster();
            }
        }


                if (attack && i < 70)
        {
            tongue.transform.position = new Vector3(tongue.transform.position.x, tongue.transform.position.y - 0.02f);
            i++;
			SoundManager.instance.PlaySound ("monster");
        }
        
	}

    public void ResetTongue()
    {
        i = 0;
        tongue.transform.position = tongueOrigin;
    }

    public void ResetMonster()
    {
        transform.position = origin;
        _mySpriteRender.sprite = originalSprite;
        moved = false;
        attack = false;
        eating = false;
        ResetTongue();
    }

    
}
