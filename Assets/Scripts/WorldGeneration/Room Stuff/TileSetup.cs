using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSetup : MonoBehaviour
{
    //Top Right Bottom Left
    public Collider2D[] doorwayColliders;
    public SpriteRenderer[] doorwayFloors;
    public SpriteMask doorMask;
    public SpriteRenderer door;

    public void Setup(bool[] doorwayOpen)
    {
        for(int i = 0; i < 4; i++)
        {
            if (!doorwayOpen[i])
            {
                if(i == 0)
                {
                    door.enabled = false;
                    doorwayColliders[i].isTrigger = false;
                } else
                {
                    doorwayColliders[i].enabled = true;
                }
                doorwayColliders[i].usedByComposite = true;
                doorwayFloors[i].enabled = false;
            }
        }
    }
}
