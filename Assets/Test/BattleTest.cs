using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleTest : MonoBehaviour
{
    public int background;
    public EnemyType[] types;
    public int[] levels;

    public void StartBattle()
    {
        int enemyCount = types.Length;
        BattleInfo battleInfo = new BattleInfo();
        battleInfo.enemies = new EnemyModel[enemyCount];
        battleInfo.enemiesPositions = new Vector2[enemyCount];
        battleInfo.backgroundCode = background;
        for(int i = 0; i < enemyCount; i++)
        {
            battleInfo.enemies[i] = new EnemyModel(types[i], levels[i]);
            battleInfo.enemiesPositions[i] = new Vector2(i * 110, 10);
        }
        BattleManager.Instance.StartBattle(battleInfo);
    }
}
