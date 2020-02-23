using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HallwaySetup : MonoBehaviour
{
    public Vector2Int connectDirection;
    public bool top;
    public Vector2Int myAdjacent
    {
        get
        {
            return transform.GetComponentInParent<TileSetup>().myPosition + connectDirection;
        }
    }
}
