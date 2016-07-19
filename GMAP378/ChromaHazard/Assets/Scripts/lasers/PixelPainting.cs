using UnityEngine;
using System.Collections;

public class PixelPainting : MonoBehaviour {

    private int PixelAmount = 4;
    private float resetTime = 12;
    private int collisionX;
    private int collisionY;
    private Color color;
    Sprite _mySprite;
    Collider2D _myCollider;
    SpriteRenderer _mySpriterRender;
    Texture2D texture;
    public int xSize = 32;
    public int ySize = 32;
    private Color ActualColor;
    DataStorage data;
    DefaultLaserColors defaultLaserColors;

    void Start () {
        defaultLaserColors = new DefaultLaserColors();
        data = GameObject.Find("DataStorage").GetComponent<DataStorage>();
        ActualColor = Color.clear;
        _myCollider = GetComponent<Collider2D>();
        _mySpriterRender = GetComponent<SpriteRenderer>();
        _mySprite = _mySpriterRender.sprite;
        texture = new Texture2D(xSize, ySize, TextureFormat.ARGB32, false);
  }

    IEnumerator FadeInk()
    {
        yield return new WaitForSeconds(1);
        Fade();
        StartCoroutine("FadeInk");
    }

    void resetSprite()
    {
        if (data.inkDoesntVanish == "Disabled" || ActualColor == defaultLaserColors.eraserLaser)
        {
            StopAllCoroutines();
            ActualColor = Color.clear;
            _mySpriterRender.sprite = _mySprite;
        }

    }

    void Fade()
    {
        
            if (ActualColor != Color.clear)
            {
                for (int x = 0; x < xSize; x++)
                {
                    for (int y = 0; y < ySize; y++)
                    {
                        if(_mySpriterRender.sprite.texture.GetPixel(x, y) != _mySprite.texture.GetPixel(x, y))
                        {
                            Color color1 = _mySpriterRender.sprite.texture.GetPixel(x, y);
                            Color colorOrignal = _mySprite.texture.GetPixel(x, y);
                            float r;
                            float g;
                            float b;

                            if(colorOrignal.r > color1.r)
                            {
								r = (colorOrignal.r - color1.r) / (resetTime / 1.5f);
                                r = r + color1.r;
                            }
                            else
                            {
								r = (color1.r - colorOrignal.r) / (resetTime / 1.5f);
                                r = color1.r - r;
                            }

                            if (colorOrignal.g > color1.g)
                            {
								g = (colorOrignal.g - color1.g) / (resetTime / 1.5f);
                                g = g + color1.g;
                            }
                            else
                            {
								g = (color1.g - colorOrignal.g) / (resetTime / 1.5f);
                                g = color1.g - g;
                            }

                            if (colorOrignal.b > color1.b)
                            {
								b = (colorOrignal.b - color1.b) / (resetTime / 1.5f);
                                b = b + color1.b;
                            }
                            else
                            {
								b = (color1.b - colorOrignal.b) / (resetTime / 1.5f);
                                b = color1.b - b;
                            }

                            Color vecColor = new Vector4( r, g, b,1);
                            texture.SetPixel(x, y, vecColor); //_mySprite.texture.GetPixel(x, y)
                        }
                        
                    }
                }
                texture.Apply();
                _mySpriterRender.sprite = Sprite.Create(texture, new Rect(0f, 0f, xSize, ySize), new Vector2(0.5f, 0.5f), 100);
                _mySpriterRender.sprite.texture.filterMode = FilterMode.Point;

            }

                
        

    }

        void PaintBlock(Color c, Vector3 pos, Vector2 normal)
    {
        ActualColor = c;

        if (ActualColor != defaultLaserColors.eraserLaser)
        {

            int xAux;
            float random;

            Vector3 hitSide = normal;

            if (hitSide.y < 0)
            {
                //top
                xAux = 1;
                collisionX = (int)Mathf.Floor((pos.x - (this.transform.position.x - _mySpriterRender.bounds.size.x / 2)) * 100);

                for (int y = 0; y < ySize; y++)
                {
                    if (y % 5 == 0)
                    {
                        if (xAux < 10)
                        {
                            xAux += 1;
                        }
                    }
                    for (int x = 0; x < xSize; x++)
                    {
                        random = Random.Range(0, PixelAmount);
                        if ((x < xSize - 0.1f && x >= collisionX - xAux && x <= collisionX + xAux && y > ySize - (ySize) - Random.Range(0, ySize / 4)) && random != 0)
                        {
                            color = c;
                            texture.SetPixel(x, y, color);
                        }
                        else
                        {
                            color = _mySpriterRender.sprite.texture.GetPixel(x, y);
                            texture.SetPixel(x, y, color);
                        }
                    }
                }


            }
            else if (hitSide.y > 0)
            {
                //Bottom
                xAux = 10;
                collisionX = (int)Mathf.Floor((pos.x - (this.transform.position.x - _mySpriterRender.bounds.size.x / 2)) * 100);

                for (int y = 0; y < ySize; y++)
                {
                    if (y % 5 == 0)
                    {
                        if (xAux > 1)
                        {
                            xAux -= 1;
                        }

                    }
                    for (int x = 0; x < xSize; x++)
                    {
                        random = Random.Range(0, PixelAmount);
                        if ((x < xSize - 0.1f && x >= collisionX - xAux && x <= collisionX + xAux) && y < ySize + Random.Range(0, ySize / 4) && random != 0)
                        {
                            color = c;
                            texture.SetPixel(x, y, color);
                        }
                        else
                        {
                            color = _mySpriterRender.sprite.texture.GetPixel(x, y);
                            texture.SetPixel(x, y, color);
                        }
                    }
                }

            }
            else if (hitSide.x > 0)
            {
                //Left
                xAux = 10;
                collisionY = (int)Mathf.Floor((pos.y - (this.transform.position.y - _mySpriterRender.bounds.size.y / 2)) * 100);

                for (int x = 0; x < xSize; x++)
                {
                    if (x % 5 == 0)
                    {
                        if (xAux > 1)
                        {
                            xAux -= 1;
                        }
                    }
                    for (int y = 0; y < ySize; y++)
                    {
                        random = Random.Range(0, PixelAmount);
                        if ((y < ySize - 0.1f && y >= collisionY - xAux && y <= collisionY + xAux) && x < xSize + Random.Range(0, xSize / 4) && random != 0)
                        {
                            color = c;
                            texture.SetPixel(x, y, color);
                        }
                        else
                        {
                            color = _mySpriterRender.sprite.texture.GetPixel(x, y);
                            texture.SetPixel(x, y, color);
                        }
                    }
                }

            }
            else if (hitSide.x < 0)
            {
                //Right
                xAux = 1;
                collisionY = (int)Mathf.Floor((pos.y - (this.transform.position.y - _mySpriterRender.bounds.size.y / 2)) * 100);

                for (int x = 0; x < xSize; x++)
                {
                    if (x % 5 == 0)
                    {
                        if (xAux < 10)
                        {
                            xAux += 1;
                        }

                    }
                    for (int y = 0; y < ySize; y++)
                    {
                        random = Random.Range(0, PixelAmount);
                        if ((y < ySize - 0.1f && y >= collisionY - xAux && y <= collisionY + xAux) && x > xSize - (xSize) - Random.Range(0, xSize / 4) && random != 0)
                        {
                            color = c;
                            texture.SetPixel(x, y, color);
                        }
                        else
                        {
                            color = _mySpriterRender.sprite.texture.GetPixel(x, y);
                            texture.SetPixel(x, y, color);
                        }
                    }
                }
            }

            texture.Apply();
            _mySpriterRender.sprite = Sprite.Create(texture, new Rect(0f, 0f, xSize, ySize), new Vector2(0.5f, 0.5f), 100);
            _mySpriterRender.sprite.texture.filterMode = FilterMode.Point;

            if (data.inkDoesntVanish == "Disabled")
            {
                StartCoroutine("FadeInk");
            }
        }
        else
        {
            resetSprite();
            
        }
    }

    IEnumerator ResetPainting()
    {
        yield return new WaitForSeconds(resetTime);
        resetSprite();
    }
     
    public void PaintPoint(Color color, Vector3 pos, Vector2 normal)
    {
        StopAllCoroutines();
        if (color != ActualColor)
        {
            resetSprite();
        }
        PaintBlock(color, pos, normal);
        StartCoroutine(ResetPainting());
    }
   
    public Color MyActualColor()
    {
        return ActualColor;
    }
    
}
