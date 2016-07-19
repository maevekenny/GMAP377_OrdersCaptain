using UnityEngine;
using System.Collections;

public class loop : MonoBehaviour {

    public Transform obj;

    void OnTriggerEnter2D(Collider2D other)
    {
        other.transform.position = obj.transform.position;
    }

}
