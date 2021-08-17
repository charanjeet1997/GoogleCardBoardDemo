using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonBallPhysics : MonoBehaviour
{
    public Rigidbody canonBall_RB;
    public float cannonForce;
    public float destroyTime;
    private bool isCollided;
    private void Start()
    {
        canonBall_RB.AddForce(transform.forward * cannonForce);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (isCollided == false)
        {
            canonBall_RB.useGravity = true;
            Destroy(this.gameObject,destroyTime);
            isCollided = true;
        }
    }
}
