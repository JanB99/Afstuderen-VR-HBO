using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AreaManager : MonoBehaviour
{

    public static AreaManager instance;
    
    private bool isInside = true;
    public event Action<bool> onInsideChange;

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
            onInsideChange(isInside);
            float amt =  Convert.ToInt32(isInside) * .2f + Convert.ToInt32(!isInside) * .5f;
            //FindObjectOfType<AudioManager>().SetVolume("Rain", amt);
            AudioManager.instance.SetVolume("Rain", amt);
        }
    }
}
