using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    public GlobalConfigSO globalConfig;
    private string dataPath;


    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
    }

    public void Init()
    {
        dataPath = Application.persistentDataPath + "/GlobalConfig.json";
        LoadData();
    }

    private void WriteData()
    {
        string toJSON = JsonUtility.ToJson(globalConfig);
        File.WriteAllText(dataPath, toJSON);
    }
    private string ReadData()
    {
        if(File.Exists(dataPath))
        {
            return File.ReadAllText(dataPath);
        }
        return null;
    }
    public void LoadData()
    {
        string fromJson = ReadData();
        if(fromJson == null)
        {
            WriteData();
            fromJson = ReadData();
        }
        JsonUtility.FromJsonOverwrite(fromJson, globalConfig);

    }
    public void SaveData()
    {
        WriteData();
    }
}
