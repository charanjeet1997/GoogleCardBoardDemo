using System;
using System.Collections;
using System.Collections.Generic;
using RaycastSelectionManager;
using UnityEngine;

public class VRPhysicsRaycast : MonoBehaviour
{
    public SelectionManager selectionManager;
    private RaycastHit _hit;

    public float maxShootTime;
    private float currentShootTime = 0;
    public GameObject canonBallPrefab;
    public Transform canonBallInstantiateTransform;

    public bool isSelected;

    private void Start()
    {
        currentShootTime = maxShootTime;
    }

    private void Update()
    {
        selectionManager.OnSelectorRaycast(new Ray(transform.position,transform.forward),out _hit,Mathf.Infinity );
        isSelected = selectionManager.IsSelectableSelected();
        if (selectionManager.IsSelectableSelected())
        {
            if (currentShootTime < maxShootTime)
            {
                currentShootTime += Time.deltaTime;
            }
            else
            {
                Instantiate(canonBallPrefab, canonBallInstantiateTransform.position, transform.rotation);
                currentShootTime = 0;
            }
        }
    }
}
