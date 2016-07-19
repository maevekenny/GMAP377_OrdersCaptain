using UnityEngine;
using System.Collections;

public class DefaultLaserColors {

    

    public Color bounceLaser = new Vector4(.92f,.73f,.56f,1);
    public Color iceLaser = new Vector4(.5f,1,1,1);
    public Color fastLaser = new Vector4(.81f,.11f,.58f,1);
    public Color gooLaser = new Vector4(.28f,.71f,.28f,1);
    public Color eraserLaser = new Vector4(1, 1, 1, 0.7f);

    public Color[] getColors() {
        Color[] colors = new Color[5];

        colors[0] = bounceLaser;
        colors[1] = iceLaser;
        colors[2] = fastLaser;
        colors[3] = gooLaser;
        colors[4] = eraserLaser;

        return colors;
        }

}
