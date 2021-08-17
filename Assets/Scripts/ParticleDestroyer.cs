using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleDestroyer : MonoBehaviour
{
    public ParticleSystem particleSystem;

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(particleSystem.main.duration);
        Destroy(particleSystem.gameObject);
    }
}
