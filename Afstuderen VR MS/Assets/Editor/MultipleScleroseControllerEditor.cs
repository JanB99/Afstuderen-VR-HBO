using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[CustomEditor(typeof(MultipleScleroseController))]
public class MultipleScleroseControllerEditor : Editor
{

    public override void OnInspectorGUI()
    {
        MultipleScleroseController controller = (MultipleScleroseController)target;

        MultipleScleroseController.Gradation setAll = (MultipleScleroseController.Gradation)EditorGUILayout.EnumPopup("Set all symptoms", controller.setAll);
        if (setAll != controller.setAll) {
            controller.setAll = setAll;
            controller.SetAllGradations();
        }
        EditorGUILayout.Separator();

        controller.anxietyAndDepression = (MultipleScleroseController.Gradation)EditorGUILayout.EnumPopup("Anxiety and Depression", controller.anxietyAndDepression);
        controller.opticNeuritis = (MultipleScleroseController.Gradation)EditorGUILayout.EnumPopup("Optic Neuritis", controller.opticNeuritis);
        controller.fatique = (MultipleScleroseController.Gradation)EditorGUILayout.EnumPopup("Fatique", controller.fatique);
        controller.coordination = (MultipleScleroseController.Gradation)EditorGUILayout.EnumPopup("Coordination", controller.coordination);
        controller.bladdercontrol = (MultipleScleroseController.Gradation)EditorGUILayout.EnumPopup("Bladdercontrol", controller.bladdercontrol);

        EditorGUILayout.Separator();

        controller.gender = (MultipleScleroseController.Gender)EditorGUILayout.EnumPopup("Gender voicelines", controller.gender);
    }
}
