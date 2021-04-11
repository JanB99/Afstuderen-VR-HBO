using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{

    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
      
        AreaManager.instance.OnOpenDoor += StartOpenDoor;
    }

    void StartOpenDoor() {
        animator.SetBool("isOpen_Obj_1", true);
    }
}
