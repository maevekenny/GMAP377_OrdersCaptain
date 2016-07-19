using UnityEngine;
using System.Collections;

public class Ground : MonoBehaviour {

    public int paintSize = 5;

    private Texture2D texture;
    private int pixelWidth;
    private int pixelHeight;
    private Bounds bounds;
    private BoxCollider2D boxCollider;
    private SpriteRenderer spriteRenderer;
    
    // Use this for initialization
	void Start () {
        boxCollider = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        getPixelDimensions();
        createTexture();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private void getPixelDimensions()
    {
        bounds = boxCollider.bounds;
        Vector3 min = Camera.main.WorldToScreenPoint(bounds.min);
        Vector3 max = Camera.main.WorldToScreenPoint(bounds.max);
        pixelWidth = Mathf.FloorToInt(max.x - min.x);
        pixelHeight = Mathf.FloorToInt(max.y - min.y);
    }

    public void paintPoint(Vector3 point, Color color)
    {
        // get point relative to object
        Vector3 pos = transform.position - point;
        // convert point to pixel units
        int y = texture.height/2 - Mathf.FloorToInt(pos.y / bounds.size.y * texture.height);
        int x = texture.width/2 - Mathf.FloorToInt(pos.x / bounds.size.x * texture.width);

        for (int i = x - paintSize; i < x + paintSize; i++) 
        {
            for (int j = y - paintSize ; j < y + paintSize; j++)
            {
                if (i >= 0 && i < texture.width && j >= 0 && j < texture.height)
                {
                    texture.SetPixel(i, j, color);
                }
            }
        }
            
        texture.Apply();
        // This cannot be the most efficient way
        spriteRenderer.sprite = Sprite.Create(texture, new Rect(0f, 0f, texture.width, texture.height), new Vector2(0.5f, 0.5f), 42f);
    }

    private void createTexture()
    {
        texture = new Texture2D(pixelWidth, pixelHeight);
        for (int y = 0; y < texture.height; y++)
        {
            for (int x = 0; x < texture.width; x++)
            {
                Color color = Color.grey;
                texture.SetPixel(x, y, color);
            }
        }
        texture.Apply();
        spriteRenderer.sprite = Sprite.Create(texture, new Rect(0f, 0f, texture.width, texture.height), new Vector2(0.5f, 0.5f), 42f);
    }
}
