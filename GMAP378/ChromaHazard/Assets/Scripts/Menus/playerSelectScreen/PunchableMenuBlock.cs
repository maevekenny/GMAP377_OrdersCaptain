using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class PunchableMenuBlock : MonoBehaviour {

    public UnityEvent onSelect;
    public float selectTime;
    public Color selectColor;

    private SpriteRenderer renderer;
    private Color originalColor;
    private bool punched;

    // Use this for initialization
	void Start () {
        renderer = GetComponent<SpriteRenderer>();
        originalColor = renderer.color;
        punched = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    IEnumerator SetColor()
    {
        punched = true;
        renderer.color = selectColor;
        yield return new WaitForSeconds(selectTime);
        renderer.color = originalColor;
        punched = false;
    }

    public void Punch()
    {
        if (!punched)
        {
            StartCoroutine(SetColor());
            onSelect.Invoke();
        }
    }
}
