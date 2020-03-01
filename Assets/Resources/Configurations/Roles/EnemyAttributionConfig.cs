using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[System.Serializable]
public class EnemyAttribution
{
    public EnemyType enemyType;
    public float hp;
    public float hpGrowth;
    public float attack;
    public float attackGrowth;
    public float defence;
    public float defenceGrowth;
}

public class EnemyAttributionConfig : ScriptableObject
{
    public const string RESOURCE_PATH = "Configurations/ConfigAssets/EnemyAttributionConfig";
    public EnemyAttribution[] attributions;

    public static EnemyAttribution GetEnemyAttribution(EnemyType type)
    {
        EnemyAttributionConfig config = Resources.Load<EnemyAttributionConfig>(RESOURCE_PATH);
        EnemyAttribution[] attributions = config.attributions;

        foreach (var attribution in attributions)
        {
            if(attribution.enemyType == type)
            {
                return attribution;
            }
        }
        return null;
    }
}
