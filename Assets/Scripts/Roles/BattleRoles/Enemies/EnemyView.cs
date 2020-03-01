using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyView : BattleRoleView
{
    #region Static Members
    #endregion

    #region Serialize Fields
    [SerializeField]private EnemyType _enemyType;
    [SerializeField]private Text _name;
    [SerializeField]private Text _hp;
    [SerializeField]private Text _attack;
    [SerializeField]private Text _defence;
    #endregion

    #region Private Fields
    private EnemyController _controller;
    private EnemyModel _model;
    #endregion

    public void Init(EnemyModel model)
    {
        if(_enemyType == EnemyType.None)
        {
            Debug.LogError("Incorrect enemy type!!");
            return;
        }
        InitControllerAndModel(model);
        InitView();
    }

    private void InitControllerAndModel(EnemyModel model)
    {
        _model = model;
        _controller = new EnemyController(_model);
    }
    protected virtual void InitView()
    {
        _name.text = string.Format("Lv.{0} {1}", _model.level, _model.enemyType.ToString());
        _hp.text = "hp: " + _model.hp;
        _attack.text = "attack: " + _model.attack;
        _defence.text = "defence: " + _model.defence;
    }
}
