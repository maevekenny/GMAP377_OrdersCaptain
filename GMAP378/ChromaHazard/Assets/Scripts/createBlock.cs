using UnityEngine;
using System.Collections;

public class createBlock : MonoBehaviour {
    public GameObject block;
    private float timer = 0.07f;
	// Use this for initialization
	void Start () {
    }

    void CreateBlock()
    {
        timer -= Time.deltaTime;
        if(timer<0)
        {
            Instantiate(block,new Vector3(-10f,0f,0f),new Quaternion());
            timer = 0.07f;
        }
    }

    // Update is called once per frame
    void Update () {

            CreateBlock();
	}
}
