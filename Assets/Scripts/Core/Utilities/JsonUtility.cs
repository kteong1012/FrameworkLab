using System.Collections;
using System.Collections.Generic;
using System.IO;
using LitJson;
using UnityEngine;

public class JsonUtility
{
    public static string GetEnemyPrefabPath(EnemyType type)
    {
        string jsonPath = "Configurations/Jsons/EnemyPrefabResourcePath";
        TextAsset ta = Resources.Load<TextAsset>(jsonPath);
        string jsonData = ta.text;
        Dictionary<string, string> dict = JsonMapper.ToObject<Dictionary<string, string>>(jsonData);
        string key = ((int)type).ToString();
        string value = "";
        dict.TryGetValue(key, out value);
        return value;
    }
}
