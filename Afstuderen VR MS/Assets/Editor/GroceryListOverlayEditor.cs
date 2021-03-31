using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[CustomEditor(typeof(GroceryListOverlay))]
public class GroceryListOverlayEditor : Editor
{

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        GroceryListOverlay test = (GroceryListOverlay)target;
        if (GUILayout.Button("test")) {
            test.ViewShoppingCanvas(AssignmentManager.Assignment.task2);


        }
    }
}
