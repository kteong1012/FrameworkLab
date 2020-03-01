using System.Collections.Generic;
using UnityEngine;

public class BattleManager : Singleton<BattleManager>
{
    private const string BACKGROUND_FOULDER = "Images/Battle/Backgrounds/";

    private BattleInfo _currentInfo;
    private List<EnemyView> _enemyViews;
    private BattleView _battleView;

    public void StartBattle(BattleInfo info)
    {
        _currentInfo = info;
        CreateEnemies();
        CreateHeroes();
        InitView();
    }
    private void CreateEnemies()
    {
        if (_enemyViews == null)
        {
            _enemyViews = new List<EnemyView>();
        }
        _enemyViews.Clear();
        EnemyModel[] enemyModels = _currentInfo.enemies;

        //实例化View并初始化
        foreach (var model in enemyModels)
        {
            string prefabPath = JsonUtility.GetEnemyPrefabPath(model.enemyType);
            GameObject prefab = Resources.Load<GameObject>(prefabPath);
            EnemyView view = ViewBase.CreateView<EnemyView>(prefab);
            view.Init(model);
            _enemyViews.Add(view);
        }
    }
    private void CreateHeroes()
    {

    }
    private void InitView()
    {
        if(_battleView == null)
        {
            _battleView = BattleView.Instance;
        }
        //Background
        string bgPath = BACKGROUND_FOULDER + _currentInfo.backgroundCode.ToString();
        Sprite sprite = Resources.Load<Sprite>(bgPath);
        _battleView.background.sprite = sprite;
        //Enemies Layout
        Vector2[] enemiesPositions = _currentInfo.enemiesPositions;
        for(int i = 0; i < _enemyViews.Count; i++)
        {
            RectTransform rect = _enemyViews[i].GetComponent<RectTransform>();
            rect.SetParent(_battleView.background.transform);
            UGUIUtility.Reset(ref rect);
            UGUIUtility.AlignAnchorAndPivot(SpriteAlignment.BottomLeft, ref rect);
            rect.localPosition = enemiesPositions[i];
        }
    }
}
