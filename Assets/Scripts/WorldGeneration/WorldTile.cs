using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RoomType
{
    None,
    Main,
    Vents,
    Baking,
    Gingerbread,
    Oven,
    Fridge
}

[CreateAssetMenu(menuName = "Generation/Tile")]
[System.Serializable]
public class WorldTile : ScriptableObject
{
    public static float tileDimension = 10f;

    public string Name;
    public Vector2Int Dimensions;
    public GameObject Prefab;
    public RoomType RoomType;
    public bool AnyAdjacent = false;
}
