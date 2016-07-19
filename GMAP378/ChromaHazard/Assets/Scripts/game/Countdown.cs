using UnityEngine;
using System.Collections;

public class Countdown : MonoBehaviour {

    public Sprite go; 
    public DefaulNumbers defaultNumbers;
    int number = 3;
    SpriteRenderer mySpriteRenderer;

    // Use this for initialization
    void Start () {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(CountDownStart());
              
    }

    IEnumerator CountDownStart()
    {
        Time.timeScale = .0000001f;

        yield return new WaitForSeconds(1f * .0000001f);

        mySpriteRenderer.sprite = defaultNumbers.GetNumber(2);

        yield return new WaitForSeconds(1f * .0000001f);

        mySpriteRenderer.sprite = defaultNumbers.GetNumber(1 );

        yield return new WaitForSeconds(1f * .0000001f);

        mySpriteRenderer.sprite = go;

        yield return new WaitForSeconds(1f * .0000001f);

        Time.timeScale = 1f;

        this.gameObject.active = false;
    }

   
}
