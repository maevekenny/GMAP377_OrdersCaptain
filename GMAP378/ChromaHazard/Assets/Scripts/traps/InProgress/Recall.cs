using UnityEngine;
using System.Collections;

public class Recall : MonoBehaviour {

    public GameObject checkpoint;
    private Rigidbody2D _rigid;
    private float posX;
    private float posY;
    private bool saved = false;
    private bool recall = true;

	// Use this for initialization
	void Start () {

        _rigid = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {

        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (saved == true)
            {
                this.gameObject.transform.position = new Vector3(posX,posY,0);
                saved = false;
                Destroy(GameObject.Find("CheckP(Clone)"));
            }

            if (recall == true)
            {
                recall = false;
                if (saved == false)
                {
                    posX = _rigid.transform.position.x;
                    posY = _rigid.transform.position.y;
                    Instantiate(checkpoint, new Vector3(posX, posY, 0),Quaternion.identity);
                    saved = true;
                }
            }
        }
    }
}
