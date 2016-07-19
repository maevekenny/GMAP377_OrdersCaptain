using UnityEngine;
using System.Collections;

public class Bomb : MonoBehaviour {

    public GameObject deathArea;
    public GameObject explosionParticle;
    private bool exploding = false;
    DefaultLaserColors defaultLaserColors;
    private Color[] colors;
    public bool picket = false;
    DataStorage data;

    // Use this for initialization
    void Start () {
        data = GameObject.Find("DataStorage").GetComponent<DataStorage>();
        defaultLaserColors = new DefaultLaserColors(); 

    }

    public void StartBombBehavior()
    {
        GetComponent<Rigidbody2D>().gravityScale = 1;
        StartCoroutine("DelayStartBomb");
    }

    IEnumerator DelayStartBomb()
    {
        yield return new WaitForSeconds(.1f);
        ChangeLayerToNormal();
        yield return new WaitForSeconds(2.9f);
        StartBomb();
    }


    public void StartBomb()
    {
        GetComponent<Animator>().SetBool("start", true);
    }

    public void ChangeLayerToIgnore()
    {
        this.gameObject.layer = LayerMask.NameToLayer("IgnoreEverything");
    }

    public void ChangeLayerToNormal()
    {
        this.gameObject.layer = LayerMask.NameToLayer("Bomb");
    }

   public void Destroy()
    {
        Destroy(this.gameObject);
    }

    public void Explode()
    {
        deathArea.active = true;
        ExplodeParticles();
        exploding = true;
        GetComponent<Rigidbody2D>().angularDrag = 9999999;
        GetComponent<Animator>().speed = 3;
    }
        
    public void ResetBomb()
    {
        
        this.transform.parent = null;
        this.transform.eulerAngles = new Vector3(0, 0, 0);
        StartBombBehavior();
    }

        void ExplodeParticles () {

        Color color = defaultLaserColors.getColors()[Random.Range(0, defaultLaserColors.getColors().Length)];

        int aux = 0;
        for (aux = 0; aux < 200; aux++)
        {
            GameObject ep = (GameObject)Instantiate(explosionParticle, transform.position, transform.rotation);
            ep.active = true;
            ep.GetComponent<ExplosionParticle>().color = color;
        }

    }

    public void ShootBomb(Vector2 dir)
    {
        GetComponent<Rigidbody2D>().AddForce(dir * 700);
    }

    public void ActivateBomb(int direction)
    {
        if (!exploding && data.pushableBomb == "Enabled")
        {
            if (direction == 1)
            {
                GetComponent<Rigidbody2D>().AddForce(Vector2.right * 100);
            }
            else if (direction == -1)
            {
                GetComponent<Rigidbody2D>().AddForce(Vector2.left * 100);
            }
            StartBomb();
        }
    }
}
