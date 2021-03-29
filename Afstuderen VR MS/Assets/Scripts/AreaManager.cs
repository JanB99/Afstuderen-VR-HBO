using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AreaManager : MonoBehaviour
{

    public static AreaManager instance;
    
    private bool isInside = true;
    public event Action<bool> OnInsideChange;

    void Awake()
    {
        instance = this;
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("House") || other.CompareTag("Shop")) {
            isInside = !isInside;
            OnInsideChange(isInside);
            AudioManager.instance.SetVolume("Rain", isInside ? .2f : .5f);
        }
    }
}
