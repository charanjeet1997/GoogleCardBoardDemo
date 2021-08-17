using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CanonController : MonoBehaviour
{
    public CanonFire[] canons;
    public float minCanonFireTime, maxCanonFireTime, canonFireTime;
    private float currentCanonFireTime;
    private CanonFire currentCanon;
    private void Start()
    {
        canonFireTime = Random.Range(minCanonFireTime, maxCanonFireTime);
        currentCanon = canons[Random.Range(0, canons.Length)];
    }

    private void Update()
    {
        if (currentCanonFireTime < canonFireTime)
        {
            currentCanonFireTime += Time.deltaTime;
        }
        else
        {
            currentCanon.FireCanon();
            canonFireTime = Random.Range(minCanonFireTime, maxCanonFireTime);
            currentCanon = canons[Random.Range(0, canons.Length)];
            currentCanonFireTime = 0;
        }
    }
}
