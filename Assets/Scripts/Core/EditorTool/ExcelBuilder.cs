using EditorTool;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class ExcelBuilder : Editor
{
    [MenuItem("ExcelBuilder/CreateEnemyConfig")]
    public static void CreateEnemyConfig()
    {
        string fileName = "EnemyAttributionConfig";
        EnemyAttributionConfig config = CreateInstance<EnemyAttributionConfig>();
        config.attributions = ExcelTool.CreateEnemyModelArrayWithExcel(ExcelConfig.GetExcelPath(fileName));
        if(!Directory.Exists(ExcelConfig.ASSETS_FOLDER_PATH))
        {
            Directory.CreateDirectory(ExcelConfig.ASSETS_FOLDER_PATH);
        }
        string assetPath = string.Format("{0}{1}.asset", ExcelConfig.ASSETS_FOLDER_PATH, fileName);
        AssetDatabase.CreateAsset(config, assetPath);
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
    }
}
