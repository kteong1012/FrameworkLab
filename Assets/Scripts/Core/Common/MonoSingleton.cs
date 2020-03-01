using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInstance
{
    public static GameObject gameInstace = null;
}
public class MonoSingleton<T> : MonoBehaviour where T:MonoSingleton<T>
{
    protected static T _instance;
    public static T Instance
    {
        get
        {
            if (_instance != null && _instance.gameObject != GameInstance.gameInstace)
            {
                Debug.LogWarning("Instance of " + typeof(T).Name + " is already created at gameobject (" + _instance.gameObject.name + ").");
                return _instance;
            }
            if (GameInstance.gameInstace == null)
            {
                GameInstance.gameInstace = new GameObject("MonoSingletons");
                DontDestroyOnLoad(GameInstance.gameInstace);
            }
            _instance = GameInstance.gameInstace.GetComponent<T>();
            if (_instance == null)
            {
                _instance = GameInstance.gameInstace.AddComponent(typeof(T)) as T;
            }

            return _instance;
        }
    }
    protected virtual void Start()
    {
        _instance = GetComponent<T>();
    }
}
