using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Generation/Room Tile Holder")]
public class RoomTiles : ScriptableObject
{
    public RoomType roomType;
    public List<WorldTile> worldTiles = new List<WorldTile>();

    /// <summary>
    /// Get a random tile from the container
    /// </summary>
    /// <returns>Tile, or null if the list has no tiles</returns>
    public WorldTile GetRandomTile()
    {
        if (worldTiles.Count > 0)
            return worldTiles[Random.Range(0, worldTiles.Count)];
        else
            return null;
    }
}
