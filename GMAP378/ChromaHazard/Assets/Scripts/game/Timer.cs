using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {

    DataStorage data;
    int timer;
    UnityEngine.UI.Text textField;
    private Color color = Color.white;

    // Use this for initialization
    void Start () {
        textField = this.GetComponent<UnityEngine.UI.Text>();
        data = GameObject.Find("DataStorage").gameObject.GetComponent<DataStorage>();

        if (data.gameMode != "King of The Hill")
        {
            this.gameObject.active = false;
        }
        else
        {
            timer = data.timer;
        }
        textField.text = "" + timer;
        
    }

    void Update()
    {
        textField.text = "" + timer;
        if(timer < 4)
        {
            textField.color = Color.red;
        }
        else
        {
            textField.color = color;
        }
    }

    IEnumerator reduceSecond()
    {
        yield return new WaitForSeconds(1);
        timer--;
        StartCoroutine("reduceSecond");
    }

    public void ActiveTimer(Color color)
    {
        this.color = color;
        StartCoroutine("reduceSecond");
    }

    public void DisableTimer()
    {
        this.color = Color.white;
        StopAllCoroutines();
        timer = data.timer;
    }

    public int getTime()
    {
        return timer;
    }
}
