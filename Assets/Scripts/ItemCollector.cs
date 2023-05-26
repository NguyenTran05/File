using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    //Dinh nghia ham delegate
    public delegate void CollectApple(int apple);
    //Khai bao ham delegate
    public static CollectApple collectAppleDelegate;


    private int apples = 0;

    private void Start()
    {
        if (GameManager.Instace != null)
        {
            apples = GameManager.Instace.Apples;

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Apple"))
        {
            apples++;

            if(GameManager.Instace != null)
            {
                GameManager.Instace.UpdateApples(apples);
            }
            // Phat su kien 
            collectAppleDelegate(apples);
            Debug.Log($"Apple: {apples}");
            Destroy(collision.gameObject);

        }
    }
}
