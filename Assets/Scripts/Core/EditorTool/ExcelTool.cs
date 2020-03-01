using Excel;
using System.Data;
using System.IO;
using UnityEngine;

namespace EditorTool
{
    public class ExcelConfig
    {
        public const string EXCEL_FOLDER_PATH = "Assets/Excels/";
        public const string ASSETS_FOLDER_PATH = "Assets/Resources/Configurations/ConfigAssets/";
        public static string GetExcelPath(string fileName)
        {
            return EXCEL_FOLDER_PATH + fileName + ".xlsx";
        }
    }

    public class ExcelTool
    {
        /// <summary>
        /// 读取表数据，生成对应的数组
        /// </summary>
        /// <param name="filePath">excel文件全路径</param>
        /// <returns>Item数组</returns>
        public static EnemyAttribution[] CreateEnemyModelArrayWithExcel(string filePath)
        {
            //获得表数据
            int columnNum = 0, rowNum = 0;
            DataRowCollection collect = ReadExcel(filePath, ref columnNum, ref rowNum);

            //根据excel的定义，第二行开始才是数据
            EnemyAttribution[] array = new EnemyAttribution[rowNum - 1];
            for (int i = 1; i < rowNum; i++)
            {
                EnemyAttribution enemyModel = new EnemyAttribution();
                //解析每列的数据
                enemyModel.enemyType = (EnemyType)int.Parse(collect[i][0].ToString());
                enemyModel.hp = float.Parse(collect[i][1].ToString());
                enemyModel.hpGrowth = float.Parse(collect[i][2].ToString());
                enemyModel.attack = float.Parse(collect[i][3].ToString());
                enemyModel.attackGrowth = float.Parse(collect[i][4].ToString());
                enemyModel.defence = float.Parse(collect[i][5].ToString());
                enemyModel.defenceGrowth = float.Parse(collect[i][6].ToString());
                array[i - 1] = enemyModel;
            }
            return array;
        }

        /// <summary>
        /// 读取excel文件内容
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <param name="columnNum">行数</param>
        /// <param name="rowNum">列数</param>
        /// <returns></returns>
        private static DataRowCollection ReadExcel(string filePath, ref int columnNum, ref int rowNum)
        {
            FileStream stream = File.Open(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
            IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
            DataSet result = excelReader.AsDataSet();
            //Tables[0] 下标0表示excel文件中第一张表的数据
            columnNum = result.Tables[0].Columns.Count;
            rowNum = result.Tables[0].Rows.Count;
            return result.Tables[0].Rows;
        }
    }
}