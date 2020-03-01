using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BattleRoleState
{
    Idle = 0,
    Attacking = 1,
    Attacked = 2,
    Stunned = 3,
    Death = 4,
}

public abstract class BattleRoleModel : RoleModel
{
    public int hp;
    public int attack;
    public int defence;
    public BattleRoleState state;
}
