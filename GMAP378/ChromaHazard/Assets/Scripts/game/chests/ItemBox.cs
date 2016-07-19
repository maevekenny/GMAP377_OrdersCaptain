using UnityEngine;
using System.Collections;

public class ItemBox : MonoBehaviour
{
	private ItemBoxAnimation _itemAnimation;

    //public Transform itemLaser;
    private DefaultLaserColors defaultLaserColors;
    public bool bounceLaser = false;
    public bool fastLaser = false;
    public bool iceLaser = false;
    public bool gooLaser = false;
    public bool invisibility = false;
    public bool offGravity = false;
    public bool life = false;
    public bool eraser = false;

    void Start()
    {
		_itemAnimation = GetComponent<ItemBoxAnimation> ();

        defaultLaserColors = new DefaultLaserColors();
        StartCoroutine("Delay");
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(3);
		_itemAnimation.animationState = "destroying";
    }

        void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (bounceLaser)
            {
                other.GetComponentInChildren<MouseAim>().UpdateLaserColor(defaultLaserColors.bounceLaser);
            }
            else if (fastLaser)
            {
                other.GetComponentInChildren<MouseAim>().UpdateLaserColor(defaultLaserColors.fastLaser);
            }
            else if (iceLaser)
            {
                other.GetComponentInChildren<MouseAim>().UpdateLaserColor(defaultLaserColors.iceLaser);
            }
            else if (gooLaser)
            {
                other.GetComponentInChildren<MouseAim>().UpdateLaserColor(defaultLaserColors.gooLaser);
            }
            else if (eraser)
            {
                other.GetComponentInChildren<MouseAim>().UpdateLaserColor(defaultLaserColors.eraserLaser);
            }
            else if (invisibility)
            {
                other.GetComponent<NewPlayerMovement>().SetInvisibility();
            }
            else if (offGravity)
            {
                other.GetComponent<NewPlayerMovement>().SetOffGravity();
            }
            else if (life)
            {
                other.GetComponent<NewPlayerMovement>().AddLife();
            }
			_itemAnimation.animationState = "destroying";
        }
    }
}
