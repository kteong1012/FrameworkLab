using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyType
{
    None = 0,
    Boar = 1,
    Slime = 2,
}
public class EnemyController : BattleRoleController
{
    public EnemyController(EnemyModel model) : base(model)
    {
    }
}
