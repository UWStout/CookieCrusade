using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Generation/Enemy Generator")]
public class EnemyList : ScriptableObject
{
    public List<GameObject> enemies;

    public GameObject RandomEnemy()
    {
        return enemies[UnityEngine.Random.Range(0, enemies.Count)];
    }
}
