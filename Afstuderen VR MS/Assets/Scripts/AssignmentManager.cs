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

    public event Action<Assignment> OnAssignmentComplete;
    private Assignment currentAssignment = Assignment.task1;

    void Awake()
    {
        instance = this;
    }

    public void Assignment1Complete() {
        if (currentAssignment == Assignment.task1) {
            currentAssignment = Assignment.task2;
            OnAssignmentComplete(currentAssignment);
        } 
    }

    public void Assignment2Complete()
    {
        if (currentAssignment == Assignment.task2) {
            currentAssignment = Assignment.task3;
            OnAssignmentComplete(currentAssignment);
        }   
    }

    public void Assignment3Complete()
    {
        if (currentAssignment == Assignment.task3)
        {
            currentAssignment = Assignment.task4;
            OnAssignmentComplete(currentAssignment);
        }
    }

    public void Assignment4Complete()
    {
        if (currentAssignment == Assignment.task4)
        {
            currentAssignment = Assignment.task5;
            OnAssignmentComplete(currentAssignment);
        }
    }

    public void Assignment5Complete()
    {
        if (currentAssignment == Assignment.task5)
        {
            //currentAssignment = Assignment.task3;
            //OnAssignmentComplete(currentAssignment);
        }
    }
}
