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
    private Vector2 vectorMove;
    private Rigidbody2D rPlayer;
    private bool IsGameOver;
    public GameObject gameoverText;
    
    private void Awake()
    {
        rot.z = 1f;
        speed = 0.1f;
    }

    private void Start()
    {
        rPlayer = GetComponent<Rigidbody2D>();
        vectorMove = new Vector2(0, speed * Time.deltaTime);
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
           rPlayer.AddRelativeForce(vectorMove,ForceMode2D.Force);
        }
    }


    private void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Collided ...");
        IsGameOver = true;
        gameoverText.SetActive(true);
    }
}