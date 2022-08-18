using System;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Controller : MonoBehaviour
{
    private float speed = 0.1f;
    public Vector3 rocketRotation;
    private Vector2 rocketVectorMove;
    private Rigidbody2D rbPlayer;

    public ParticleSystem flameParticle;

    private void Start()
    {
        rbPlayer = GetComponent<Rigidbody2D>();
        rocketVectorMove = new Vector2(0, speed * Time.deltaTime);
        rocketRotation.z = 1f;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        Move();
    }

    public void Move()
    {
        transform.Rotate(rocketRotation);
        CheckTouchDown(TouchCount());
    }

    private Touch TouchCount()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            return touch;
        }
        return new Touch();
    }
    private void CheckTouchDown(Touch touch)
    {
        switch (touch.phase)
        {
            case TouchPhase.Stationary:
                TouchStationaryWork();
                break;
            case TouchPhase.Ended:
                TouchEndedWork();
                break;
        }
    }

    
    private void TouchStationaryWork()
    {
        AddForce();
        ActiveParticle(flameParticle, true);
    }
    private void TouchEndedWork()
    {
        ActiveParticle(flameParticle, false);
    }


    private void AddForce()
    {
        rbPlayer.AddRelativeForce(rocketVectorMove, ForceMode2D.Force);
    }

    private void ActiveParticle(ParticleSystem particle, bool isAcvtive)
    {
        if (isAcvtive) particle.Play();
        else particle.Stop();
    }
}