using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Generation/Tile Generator")]
public class TileGenerator : ScriptableObject
{
    public List<RoomTiles> tilesets;

    public RoomTiles RandomRoomType()
    {
        return tilesets[UnityEngine.Random.Range(0, tilesets.Count)];
    }
}