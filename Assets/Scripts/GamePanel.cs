using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GamePanel : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI applesText;

    private void OnEnable()
    {
        //Dang ky su kien
        ItemCollector.collectAppleDelegate += OnPlayerCollectApples;
    }
    private void Start()
    {
        applesText.text = GameManager.Instace.Apples.ToString();
    }
    private void OnDisable()
    {
        //Huy su kien
        ItemCollector.collectAppleDelegate -= OnPlayerCollectApples;

    }
    private void OnPlayerCollectApples(int value)
    {
        applesText.text = value.ToString();
    }
}
