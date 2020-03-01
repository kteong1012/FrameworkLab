using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BattleInfo
{
    public EnemyModel[] enemies;
    public int backgroundCode;
    public Vector2[] enemiesPositions;
    public Vector2[] heroesPositions;
}