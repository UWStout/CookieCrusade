using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSetup : MonoBehaviour
{
    //Top Right Bottom Left
    public WorldTile myTemplate;
    public Vector2Int myPosition; 
    public Collider2D[] doorwayColliders;
    public SpriteRenderer[] doorwayFloors;
    public SpriteMask[] doorMasks;
    public SpriteRenderer[] doors;

    public void Setup(RoomType[,] map)
    {
        for (int i = 0; i < doorwayFloors.Length; i++)
        {
            HallwaySetup s = doorwayFloors[i].GetComponent<HallwaySetup>();

            if (s.myAdjacent.x < 0 || s.myAdjacent.y < 0 ||
                s.myAdjacent.x >= map.GetLength(0) || s.myAdjacent.y >= map.GetLength(1) ||
                map[s.myAdjacent.x, s.myAdjacent.y] == RoomType.None
                )
            {
                Debug.Log(s.myAdjacent);
                if (s.top)
                {
                    doors[i].enabled = false;
                    doorwayColliders[i].isTrigger = false;
                }
                else
                {
                    doorwayColliders[i].enabled = true;
                }
                doorwayColliders[i].usedByComposite = true;
                doorwayFloors[i].enabled = false;
            }
        }
    }
}
