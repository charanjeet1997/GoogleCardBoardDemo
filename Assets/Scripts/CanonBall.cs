using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CanonBall : MonoBehaviour
{
    public float speed,maxSpeed,minSpeed;

    private void Start()
    {
        speed = Random.Range(minSpeed, maxSpeed);
        Destroy(this.gameObject,10);
    }

    private void Update()
    {
        transform.Translate(-Vector3.forward * speed * Time.deltaTime);
    }
}
