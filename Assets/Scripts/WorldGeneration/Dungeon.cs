using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dungeon : MonoBehaviour
{
    static int maxTriesPerRoom = 100;

    [Header("Map Info")]
    private RoomType[,] map;
    private GameObject[,] map_models;
    public Vector2Int mapDimensions;

    [Header("Generation Info")]
    public TileGenerator tileGenerator;
    public WorldTile startingRoom;
    public WorldTile endingRoom;

    public List<GameObject> gs;

    public int generatedRooms = 100;
    public int zones = 4;

    void Start()
    {
        gs = new List<GameObject>();
        GenerateMap(generatedRooms);
    }

    public void GenerateMap(int rooms)
    {
        map = new RoomType[mapDimensions.x, mapDimensions.y];
        map_models = new GameObject[mapDimensions.x, mapDimensions.y];
        // Rooms to be generated ber section
        int roomsPerSection = generatedRooms / zones;

        //Starting Position
        GenerateTile(startingRoom, maxTriesPerRoom, true, true);

        //Starting section
        GenerateSection(roomsPerSection, startingRoom.RoomType, true);

        for (int i = 1; i < zones; i++)
        {
            GenerateSection(roomsPerSection);
        }

        //Ending Position
        GenerateTile(endingRoom, maxTriesPerRoom, true);

        foreach (GameObject room in map_models)
        {
            //code for triggering walls
            if (room != null)
            {
                room.GetComponent<TileSetup>().Setup(map);
            }
        }
    }

    public void GenerateSection(int roomsPerSection, RoomType roomType = RoomType.None, bool first = false)
    {
        RoomTiles tiles = tileGenerator.RandomRoomType();

        for (int roomsGenerated = 0; roomsGenerated < roomsPerSection;)
        {
            WorldTile worldTile = tiles.GetRandomTile();

            if (GenerateTile(worldTile, maxTriesPerRoom))
                roomsGenerated++;
        }
    }

    /// <summary>
    /// Generate a tile
    /// </summary>
    /// <param name="tile">Tile template being used</param>
    /// <param name="maxTries">Maximum number of tries, typically 'maxTriesPerRoom'</param>
    /// <param name="force">Force the placement, ignoring nearby tiles</param>
    /// <returns></returns>
    bool GenerateTile(WorldTile tile, int maxTries, bool anyAdjacent = false, bool force = false)
    {
        for (int tries = 0; tries < maxTries; tries++)
        {
            Vector2Int newPosition = new Vector2Int(Random.Range(0, mapDimensions.x), Random.Range(0, mapDimensions.y));
            if (CheckSpotAvailable(newPosition, tile.Dimensions, (anyAdjacent || tile.AnyAdjacent) ? RoomType.None : tile.RoomType, force))
            {
                AddTileToMap(tile, newPosition);
                return true;
            }
        }

        return false;
    }

    /// <summary>
    /// Checks a position to see if a tile of the given dimensions can fit
    /// </summary>
    /// <param name="pos">Position on the map grid, bottom left of the tile</param>
    /// <param name="dimensions">Dimensions of the tile</param>
    /// <returns></returns>
    bool CheckSpotAvailable(Vector2Int pos, Vector2Int dimensions, RoomType adjacentRoom = RoomType.None, bool forcePlace = false)
    {
        // check if the tile is too big on the x coordinate
        if (pos.x + dimensions.x >= mapDimensions.x)
            return false;

        // check if the tile is too big on the y coordinate
        if (pos.y + dimensions.y >= mapDimensions.y)
            return false;

        // loop through positions to check for conflict, going from bottom left
        for (int x = pos.x; x < pos.x + dimensions.x; x++)
        {
            for (int y = pos.y; y < pos.y + dimensions.y; y++)
            {
                if (map[x, y] != RoomType.None)
                {
                    return false;
                }
            }
        }

        if (forcePlace)
            return true;

        bool adjacent = false;

        //Loop through positions around tile to check for a connected location
        for (int x = 0; x < dimensions.x; x++)
        {
            if (pos.y - 1 >= 0)
            {
                if (adjacentRoom == RoomType.None)
                {
                    if (map[pos.x + x, pos.y - 1] != RoomType.None)
                        adjacent = true;
                }
                else
                {
                    if (map[pos.x + x, pos.y - 1] == adjacentRoom)
                        adjacent = true;
                }
            }
            if (pos.y + dimensions.y < mapDimensions.y)
            {
                if (adjacentRoom == RoomType.None)
                {
                    if (map[pos.x + x, pos.y + dimensions.y] != RoomType.None)
                        adjacent = true;
                }
                else
                {
                    if (map[pos.x + x, pos.y + dimensions.y] == adjacentRoom)
                        adjacent = true;
                }
            }
        }

        for (int y = 0; y < dimensions.y; y++)
        {
            if (pos.x - 1 >= 0)
            {
                if (adjacentRoom == RoomType.None)
                {
                    if (map[pos.x - 1, pos.y + y] != RoomType.None)
                        adjacent = true;
                }
                else
                {
                    if (map[pos.x - 1, pos.y + y] == adjacentRoom)
                        adjacent = true;
                }
            }
            if (pos.x + dimensions.x < mapDimensions.x)
            {
                if (adjacentRoom == RoomType.None)
                {
                    if (map[pos.x + dimensions.x, pos.y + y] != RoomType.None)
                        adjacent = true;
                }
                else
                {
                    if (map[pos.x + dimensions.x, pos.y + y] == adjacentRoom)
                        adjacent = true;
                }
            }
        }

        return adjacent;
    }


    void AddTileToMap(WorldTile tile, Vector2Int position)
    {
        GameObject g = Instantiate<GameObject>(tile.Prefab);
        g.transform.position = new Vector2(position.x * WorldTile.tileDimension, position.y * WorldTile.tileDimension);
        g.transform.SetParent(this.transform);
        g.GetComponent<TileSetup>().myTemplate = tile;
        g.GetComponent<TileSetup>().myPosition = position;

        gs.Add(g);

        for (int x = position.x; x < position.x + tile.Dimensions.x; x++)
        {
            for (int y = position.y; y < position.y + tile.Dimensions.y; y++)
            {
                map[x, y] = tile.RoomType;
                map_models[x, y] = g;
            }
        }
    }
}