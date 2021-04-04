using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AreaManager : MonoBehaviour
{

    public static AreaManager instance;
    
    private bool isInside = true;
    private bool keyPickedUp = false;
    public event Action<bool> OnInsideChange;
    public event Action OnOpenDoor;

    void Awake()
    {
        instance = this;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("House") || other.CompareTag("Shop")) {
            isInside = !isInside;
            OnInsideChange(isInside);
            AudioManager.instance.SetVolume("Rain", isInside ? .2f : .5f);
        }

        if (other.CompareTag("DoorCollider") && keyPickedUp) {

            OnOpenDoor();
            AssignmentManager.instance.Assignment3Complete();
            Destroy(GameObject.FindGameObjectWithTag("Task3Object").gameObject);
        }
    }

    public void OnPickUp() {
        keyPickedUp = true;
    }

    public void OnDetachFromHand()
    {
        keyPickedUp = false;
    }
}
