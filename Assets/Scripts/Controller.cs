using System;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Controller : MonoBehaviour
{
    private float speed = 0.1f;
    public Vector3 playerRotation;
    private Vector2 vectorMove;
    private Rigidbody2D rbPlayer;
    
    private void Start()
    {
        playerRotation.z = 1f;
        rbPlayer = GetComponent<Rigidbody2D>();
        vectorMove = new Vector2(0, speed * Time.deltaTime);
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        transform.Rotate(playerRotation); // Rotate player
        // Touch * * *
        //if (Input.GetTouch(0).phase == TouchPhase.Stationary)
          //  AddForce();
        CheckTouchDown(KeyCode.Space);
    }

    private void CheckTouchDown(KeyCode key)
    {
        if (Input.GetKey(key))
            KeyDownWork();
    }

    private void KeyDownWork()
    {
        AddForce();
    }

    private void AddForce()
    {
        rbPlayer.AddRelativeForce(vectorMove, ForceMode2D.Force);
    }

}