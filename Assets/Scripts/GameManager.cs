using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instace;
    private const string AppleKey = "Apple";
    private int apples = 0;
    public int Apples => apples;

    public void UpdateApples(int value)
    {
        apples = value;
    }
    private void Awake()
    {
        if (Instace != null && Instace != this)
        {
            Destroy(this);
        }
        else
        {
            Instace= this;
            DontDestroyOnLoad(this);
        }
        apples = PlayerPrefs.GetInt(AppleKey, 0);

    }

    public void StartGame()
    {

    }
    public void PauseGame()
    {

    }
    public void ResumeGame()
    {

    }
    public void RestartGame()
    {

    }
    public void EndGame()
    {

    }
    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt(AppleKey, apples);
    }
}
