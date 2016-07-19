using UnityEngine;
using System.Collections;

public class InkCheckColor : MonoBehaviour {

    Collider2D collider;
    private LayerMask WallLayerMask;
    private DefaultLaserColors defaultLaserColors;
    private NewPlayerMovement player;

    // Use this for initialization
    void Start () {
        player = GetComponentInParent<NewPlayerMovement>();
        WallLayerMask = player.WallLayerMask;
        defaultLaserColors = new DefaultLaserColors();
    }

    // Update is called once per frame
    void Update()
    {

        collider = Physics2D.OverlapCircle(this.transform.position, 0.05f, WallLayerMask);
        if (collider != null)
        {
            if (collider.gameObject.CompareTag("floor"))
            {
                Color color = collider.GetComponent<PixelPainting>().MyActualColor();
                if (color == defaultLaserColors.bounceLaser)
                {
                    player.Bounce();
                    player.PlayParticles(defaultLaserColors.bounceLaser);
                }
                else if (color == defaultLaserColors.iceLaser)
                {
                    player.ColdStatus();
                    player.PlayParticles(defaultLaserColors.iceLaser);
                }
                else if (color == defaultLaserColors.fastLaser)
                {
                    player.FastStatus();
                    player.PlayParticles(defaultLaserColors.fastLaser);
                }
                else if (color == defaultLaserColors.gooLaser)
                {
                    player.GooStatus();
                    player.PlayParticles(defaultLaserColors.gooLaser);
                }
                else if (color == Color.clear)
                {
                    player.ClearMovementStatus();
                    player.Clear();
                    player.StopParticles();
                }
            }
        }
    }

    
}
