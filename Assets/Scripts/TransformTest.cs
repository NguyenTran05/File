using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformTest : MonoBehaviour
{
    [SerializeField]
    private Transform playerTransform;

    [SerializeField]
    private float movespeed;
    // Update is called once per frame
    void Update()
    {
        //Vecto Huong = Vi tri dich - vi tri bat dau
        Vector3 direction = playerTransform.position - transform.position;
        Debug.DrawRay(transform.position, direction, Color.red);
        Debug.Log("Distance from Enemy to player: " + direction.magnitude);

        //float distance = Vector3.Distance(transform.position, playerTransform.position);
        //Debug.Log("Distance from Enemy to player -2: " + distance);

        direction.Normalize();
        transform.Translate(direction * Time.deltaTime * movespeed);
    }
}
