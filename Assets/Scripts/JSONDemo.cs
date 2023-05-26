using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;
public class JSONDemo : MonoBehaviour
{
    public TextMeshProUGUI playerName;
    public TextMeshProUGUI playerLevel;
    public TextMeshProUGUI playerGold;
    public ListPlayer listPlayer;
    private string json;
    private string dataPath;

    private void Awake()
    {
        dataPath= Application.persistentDataPath + "/PlayerData.json";
        Debug.Log(dataPath);
    }
    void Start()
    {
        //PlayerData playerdata = new PlayerData
        //{
        //    Name = "Cat",
        //    Level = 1,
        //    Gold = 100
        //};
        //json = JsonUtility.ToJson(PlayerData);
        json = JsonUtility.ToJson(listPlayer);
        Debug.Log(json);
    }
    public void LoadPlayerData()
    {
        string loadJSON = File.ReadAllText(dataPath);
        if(loadJSON != null)
        {
            //PlayerData loadedPlayeData = JsonUtility.FromJson<PlayerData>(loadJSON);
            //playerName.text = $"Player Name: {loadedPlayeData.Name}";
            //playerLevel.text = $"Player Level: {loadedPlayeData.Level}";
            //playerGold.text = $"Player Gold: {loadedPlayeData.Gold}";
            ListPlayer loadedPlayeData = JsonUtility.FromJson<ListPlayer>(loadJSON);
            playerName.text = $"Player Name: {loadedPlayeData.playerDatas[2].Name}";
            playerLevel.text = $"Player Level: {loadedPlayeData.playerDatas[2].Level}";
            playerGold.text = $"Player Gold: {loadedPlayeData.playerDatas[2].Gold}";
        }
    }
    public void SavePlayerData()
    {
        File.WriteAllText(dataPath, json);

    }
    public void UpdatePlayerData()
    {
        PlayerData newData = new PlayerData
        {
            Name = "Kai",
            Level = 2,
            Gold = 200
        };
        playerName.text = $"Player Name: {newData.Name}";
        playerLevel.text = $"Player Level: {newData.Level}";
        playerGold.text = $"Player Gold: {newData.Gold}";
        json = JsonUtility.ToJson(newData);
        SavePlayerData();
    }
}
