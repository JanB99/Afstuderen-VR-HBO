using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPlacementPlane : MonoBehaviour
{

    public static ObjectPlacementPlane instance;
    public Action OnObjectPlaced;

    public void Awake()
    {
        instance = this;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Task1Object"))
        {
            OnObjectPlaced();
        }
    }
}
