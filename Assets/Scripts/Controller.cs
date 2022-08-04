using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    public float speed;
    public Vector3 rot;
    private bool IsGameOver;
    public GameObject gameoverText;
    
    private void Awake()
    {
        rot.z = 3f;
        speed = 5f;
    }
    
    // Update is called once per frame
    void FixedUpdate()
    {
        if (!IsGameOver)
        {
            Move();
            transform.Rotate(rot);
        }
    }

    private void Move()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            transform.Translate(0, speed * Time.deltaTime, 0);
        }
    }


    private void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Collided ...");
        IsGameOver = true;
        gameoverText.SetActive(true);
    }
}