using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class EnemyModel : BattleRoleModel
{
    public EnemyType enemyType;
    public int level { get; private set; }
    public EnemyModel(EnemyType type)
    {
        this.enemyType = type;
        SetLevel(1);
    }
    public EnemyModel(EnemyType type, int level)
    {
        this.enemyType = type;
        SetLevel(level);
    }

    private void SetLevel(int level)
    {
        this.level = level > 0 ? level : 1;
        EnemyAttribution attribution = EnemyAttributionConfig.GetEnemyAttribution(enemyType);
        this.hp = Mathf.RoundToInt(attribution.hp + (level - 1) * attribution.hpGrowth);
        this.attack = Mathf.RoundToInt(attribution.attack + (level - 1) * attribution.attackGrowth);
        this.defence = Mathf.RoundToInt(attribution.defence + (level - 1) * attribution.defenceGrowth);
    }

}