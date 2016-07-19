using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class SpawnChests : MonoBehaviour {

    public GameObject chest;
    public GameObject[] positions;
    GameObject go;
    List<GameObject> chests = new List<GameObject>();
    int aux = 0;
    int number;
    int numberOfChests = 0;
    int count = 0;
    float time = 1;


    // Use this for initialization
    void Start () {
        StartCoroutine("addChest");
	}

    IEnumerator addChest()
    {
        yield return new WaitForSeconds(time);
        if (chests.Count == 0) {
            number = Random.Range(0, positions.Length - 1);
            addChestPos(number);
            numberOfChests++;
        }
        else
        {
            if (numberOfChests < positions.Length - 4)
            {
                while (true)
                {
                    number = Random.Range(0, positions.Length - 1);
                    foreach (GameObject go in chests)
                    {
                        if (go.gameObject.transform.position == positions[number].transform.position)
                        {
                            aux++;
                        }
                    }
                    if (aux == 0)
                    {
                        break;
                    }
                    else
                    {
                        aux = 0;
                    }
                }
                addChestPos(number);
                numberOfChests++;
            }
            else
            {
                StartCoroutine("addChest");
            }
        }


    }

    private void addChestPos(int number)
    {
        go = (GameObject)Instantiate(chest, positions[number].transform.position, positions[number].transform.rotation);
        chests.Add(go);
        StartCoroutine("addChest");
        count++;
        if(count >= 1)
        {
            time = 5;
        }
    }

    // Update is called once per frame
    void Update () {
        
        for(int i = 0; i < chests.Count; i++)
        {
            if (chests[i].gameObject.GetComponent<Chest>().open == true)
            {
                chests.RemoveAt(i);
                numberOfChests--;
            }
        }
        
    }
}
