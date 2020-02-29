using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInstance
{
    public static GameObject gameInstace = null;
}
public class MonoSingleton<T> : MonoBehaviour where T:MonoSingleton<T>
{
    private static T _instance;
    public static T Instance
    {
        get
        {
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
            else if (_instance.gameObject != GameInstance.gameInstace)
            {
                Debug.LogWarning("Instance of " + typeof(T).Name + " is already created at gameobject (" + _instance.gameObject.name + ").");
            }
            return _instance;
        }
    }
}
