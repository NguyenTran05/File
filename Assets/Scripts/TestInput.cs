using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestInput : MonoBehaviour
{
    private float directionX;
    private float directionY;
    // Update is called once per frame
    void Update()
    {
        directionX = Input.GetAxis("Horizontal");
        Debug.Log(directionX);
        directionY = Input.GetAxis("Vertical");
        Debug.Log(directionY);
        if (Input.GetButtonDown("Jump"))
        {
            Debug.Log("Jump");
        }
        if (Input.GetButton("Jump"))
        {
            Debug.Log("Jump is held down");
        }
        if(Input.GetMouseButtonDown(0))
        {
            Debug.Log("Left Mouse Click");
        }
        if (Input.GetMouseButton(0))
        {
            Debug.Log("Left Mouse Held Down");
        }
        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("Right Mouse Click");
        }
        if (Input.GetMouseButton(1))
        {
            Debug.Log("Right Mouse Held Down");
        }
        if (Input.GetKey(KeyCode.G))
        {
            Debug.Log("G is pressed");
        }
    }
}
