using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class EnemyGeneration : MonoBehaviour
{
    public EnemyList enemyList;
    public SpriteRenderer spriteRenderer;

    public void GenerateEnemies()
    {
        //get the bounds of the spawning area
        Vector2 lowerBounds = Vector2.one * 3;
        Vector2 upperBounds = spriteRenderer.size - Vector2.one;

        int enemies = Random.Range(0, 4);
        for(int i = 0; i < enemies; i++)
        {
            Vector2 pos = new Vector2(Random.Range(lowerBounds.x, upperBounds.x), Random.Range(lowerBounds.y, upperBounds.y));
            print(pos);
            GameObject g = GameObject.Instantiate<GameObject>(enemyList.RandomEnemy(), pos, Quaternion.identity, this.transform.parent);
            g.transform.localPosition = pos;
        }
    }

}
