using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class TestSO : MonoBehaviour
{
    public TextMeshProUGUI PlayerMaxHealth;
    public TextMeshProUGUI PlayerSpeed;
    public TextMeshProUGUI EnemyDamage;

     void Start()
    {
        if(DataManager.Instance != null)
        {
            DataManager.Instance.Init();
            LoadData();
        }
    }
   private void LoadData()
    {
        var GlobalConfig = DataManager.Instance.globalConfig;
        PlayerMaxHealth.text = $"PlayerMaxhealth: {GlobalConfig.globalConfig.PlayerMaxHeath}";
        PlayerSpeed.text = $"PlayerSpeed: {GlobalConfig.globalConfig.PlayerMoveSpeed}";
        EnemyDamage.text = $"EnemyDamage: {GlobalConfig.globalConfig.EnemyDamage}";
    }
    public void UpdateConfigData(int amount)
    {
        var globalconfig = DataManager.Instance.globalConfig;
        globalconfig.globalConfig.PlayerMaxHeath += amount;
        globalconfig.globalConfig.PlayerMoveSpeed += amount;
        globalconfig.globalConfig.EnemyDamage += amount;
        DataManager.Instance.SaveData();
        LoadData();

    }
}
