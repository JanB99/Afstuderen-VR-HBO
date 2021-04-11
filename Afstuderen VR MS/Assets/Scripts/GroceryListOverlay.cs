using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class GroceryListOverlay : MonoBehaviour
{
    public static GroceryListOverlay instance;

    public Camera cameraVR;
    [HideInInspector]
    public Canvas canvas;
    [HideInInspector]
    public RectTransform rectTransform;

    public void OnPress(Hand hand) {
        AssignmentManager.instance.Assignment2Complete();
        canvas.gameObject.SetActive(false);
    }

    void Start()
    {
        instance = this;
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponent<Canvas>();
        AssignmentManager.instance.OnAssignmentComplete += ViewShoppingCanvas;
        canvas.gameObject.SetActive(false);
    }

    public void ViewShoppingCanvas(AssignmentManager.Assignment assignment) {

        if (assignment == AssignmentManager.Assignment.task2) {
            canvas.gameObject.SetActive(true);
            Vector3 point = cameraVR.ViewportToWorldPoint(new Vector3(.5f, .5f, 1f));
            rectTransform.transform.position = new Vector3(point.x, 12.3f, point.z);
            rectTransform.transform.rotation = Quaternion.Euler(0, cameraVR.transform.rotation.eulerAngles.y, 0);
        }

    }
}
