using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssignmentManager : MonoBehaviour
{
    public enum Assignment{ 
        task1, 
        task2,
        task3,
        task4,
        task5,
    }

    public static AssignmentManager instance;

    public Action<Assignment> onAssignmentComplete;
    public Assignment currentAssignment = Assignment.task1;

    void Awake()
    {
        instance = this;
        ObjectPlacementPlane.instance.OnObjectPlaced += Assignment1;
    }

    //private void Update()
    //{
    //    switch (currentAssignment) {
    //        case Assignment.task1:
    //            Assignment1();
    //            break;
    //        case Assignment.task2:
    //            Assignment2();
    //            break;
    //        case Assignment.task3:
    //            Assignment3();
    //            break;
    //        case Assignment.task4:
    //            Assignment4();
    //            break;
    //        case Assignment.task5:
    //            Assignment5();
    //            break;

    //    }
    //}

    private void Assignment1() {
        currentAssignment = Assignment.task2;
        onAssignmentComplete(currentAssignment);
    }

    private void Assignment2()
    {

    }

    private void Assignment3()
    {

    }

    private void Assignment4()
    {

    }

    private void Assignment5()
    {

    }
}
