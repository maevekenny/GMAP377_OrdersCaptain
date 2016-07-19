using UnityEngine;
using System.Collections;

public class PowerCellSpawnPos : MonoBehaviour {

    public GameObject[] positions;

	public GameObject getPowerCellPosition()
    {
        int i = Random.Range(0, positions.Length - 1);

        return positions[i];
    }
}
