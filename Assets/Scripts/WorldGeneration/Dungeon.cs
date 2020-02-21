using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dungeon : MonoBehaviour
{
    static int maxTriesPerRoom = 10;

    [Header("Map Info")]
    private RoomType[,] map;
    private GameObject[,] map_models;
    public Vector2Int mapDimensions;

    [Header("Generation Info")]
    public RoomTiles currentTileSet;
    public WorldTile startingRoom;
    public WorldTile endingRoom;

    public GameObject DebugPrefab;

    void Start()
    {
        GenerateMap(1);
        DebugDraw();
    }

    public void DebugDraw()
    {
        for(int x = 0; x < mapDimensions.x; x++)
        {
            for (int y = 0; y < mapDimensions.y; y++)
            {
                if (map[x, y] == RoomType.None)
                {
                    GameObject g; 
                    g = Instantiate<GameObject>(DebugPrefab, new Vector3(x * WorldTile.tileDimension, y * WorldTile.tileDimension, 0), Quaternion.identity);
                }
            }
        }
    }

    public void GenerateMap(int rooms)
    {
        int roomsGenerated = 0;

        for(int num = 0; num < rooms; num++)
        {
<<<<<<< HEAD
            WorldTile worldTile = currentTileSet.GetRandomTile();

            for(int tries = 0; tries < maxTriesPerRoom; tries++){
                Vector2Int newPosition = new Vector2Int(Random.Range(0, mapDimensions.x), Random.Range(0, mapDimensions.y));
                if (CheckSpotAvailable(newPosition, worldTile.Dimensions)){
                    AddTileToMap(worldTile, newPosition);
                    break;
                }
            }
        }
=======
            GenerateSection(roomsPerSection);
        }
    }

    public void GenerateSection(int roomsPerSection, RoomType roomType = RoomType.None, bool first = false)
    {
        RoomTiles tiles = tileGenerator.RandomRoomType();
>>>>>>> michaelTemp

        foreach(GameObject room in map_models)
        {

        }
    }

    /// <summary>
    /// Checks a position to see if a tile of the given dimensions can fit
    /// </summary>
    /// <param name="pos">Position on the map grid, bottom left of the tile</param>
    /// <param name="dimensions">Dimensions of the tile</param>
    /// <returns></returns>
    bool CheckSpotAvailable(Vector2Int pos, Vector2Int dimensions)
    {
        // check if the tile is too big on the x coordinate
        if (pos.x + dimensions.x >= mapDimensions.x)
            return false;

        // check if the tile is too big on the y coordinate
        if (pos.y + dimensions.y >= mapDimensions.y)
            return false;

        // loop through positions to check for conflict, going from bottom left
        for(int x = pos.x; x < pos.x+dimensions.x; x++)
        {
            for (int y = pos.y; y > mapDimensions.y - pos.y + dimensions.y; y--)
            {
                if(map[x,y] != RoomType.None)
                {
                    return false;
                }
            }
        }

        return true;
    }

    
    void AddTileToMap(WorldTile tile, Vector2Int position)
    {
        GameObject g = Instantiate<GameObject>(tile.Prefab);
        g.transform.position = new Vector2(position.x * WorldTile.tileDimension, position.y * WorldTile.tileDimension);

        for (int x = position.x; x < position.x + tile.Dimensions.x; x++)
        {
            for (int y = position.y; y > mapDimensions.y - position.y - tile.Dimensions.y; y--)
            {
                map[x, y] = tile.RoomType;
                map_models[x, y] = g;
            }
        }
    }
}
