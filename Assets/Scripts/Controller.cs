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

    public ParticleSystem flameParticle;

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

    public void Move()
    {
        transform.Rotate(playerRotation); // Rotate player
     
        if (Input.touchCount>0)
        {
            Touch touch = Input.GetTouch(0);
            CheckTouchDown(touch);
        }
    }
    
    private void CheckTouchDown(Touch touch)
    {
        switch (touch.phase)
        {
            case TouchPhase.Stationary:
                TouchStationaryWork();
                break;
            case TouchPhase.Ended:
                ActiveParticle(flameParticle,false);
                break;
        }
    }

    private void TouchStationaryWork()
    {
        AddForce();
        ActiveParticle(flameParticle,true);
    }

    private void AddForce()
    {
        rbPlayer.AddRelativeForce(vectorMove, ForceMode2D.Force);
    }

    private void ActiveParticle(ParticleSystem particle,bool isAcvtive)
    {
        if (isAcvtive) particle.Play();
        else particle.Stop();
    }
}