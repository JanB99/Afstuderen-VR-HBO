using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroceryListOverlay : MonoBehaviour
{

    public Camera cameraVR;
    [HideInInspector]
    public Canvas canvas;
    public RectTransform rectTransform;

    void Start()
    {
        canvas = GetComponent<Canvas>();
        AssignmentManager.instance.onAssignmentComplete += ViewShoppingCanvas;
        canvas.gameObject.SetActive(false);
    }

    public void ViewShoppingCanvas(AssignmentManager.Assignment assignment) {

        if (assignment == AssignmentManager.Assignment.task2) {
            canvas.gameObject.SetActive(true);
            Vector3 point = cameraVR.ViewportToWorldPoint(new Vector3(.5f, .5f, 2f));
            rectTransform.transform.position = point;
            rectTransform.transform.rotation = Quaternion.Euler(0, cameraVR.transform.rotation.eulerAngles.y, 0);
        }

    }
}
