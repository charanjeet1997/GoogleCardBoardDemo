using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CanonFire : MonoBehaviour
{
    public GameObject[] canonBalls;
    public Transform canonBallParent;
    public Transform canonStartPoint;
    public void FireCanon()
    {
        Instantiate(canonBalls[Random.Range(0, canonBalls.Length)].gameObject, canonStartPoint.transform.position, Quaternion.identity,canonBallParent);
    }
}
