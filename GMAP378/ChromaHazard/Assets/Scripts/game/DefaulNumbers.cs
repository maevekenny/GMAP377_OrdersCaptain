using UnityEngine;
using System.Collections;

public class DefaulNumbers : MonoBehaviour {

    public Sprite number1;
    public Sprite number2;
    public Sprite number3;
    public Sprite number4;
    public Sprite number5;
    public Sprite number6;
    public Sprite number7;
    public Sprite number8;
    public Sprite number9;
    public Sprite number0;


    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public Sprite GetNumber(int number)
    {
        if (number == 1)
        {
            return number1;
        }
        else if (number == 2)
        {
            return number2;
        }
        else if (number == 3)
        {
            return number3;
        }
        else if (number == 4)
        {
            return number4;
        }
        else if (number == 5)
        {
            return number5;
        }
        else if (number == 6)
        {
            return number6;
        }
        else if (number == 7)
        {
            return number7;
        }
        else if (number == 8)
        {
            return number8;
        }
        else if (number == 9)
        {
            return number9;
        }
        else if (number == 0)
        {
            return number0;
        }
        else
        {
            return number0;
        }

    }

    
}
