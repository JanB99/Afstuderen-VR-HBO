using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HandUIController : MonoBehaviour
{

    private TextMeshProUGUI textMesh;
    private List<string> taskDescriptions;

    void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
        taskDescriptions = new List<string>();
        taskDescriptions.Add(
            @"Opdracht 1: 
Leg de gemarkeerde verpakking in het blauw vak in de keuken.");

        taskDescriptions.Add(
            @"Opdracht 2: 
Lees de boodschappenlijst en onthoud de producten, druk vervolgens op de blauwe knop.");

        taskDescriptions.Add(
            @"Opdracht 3: 
Pak de sleutel en loop naar de deur om deze te openen.");

        taskDescriptions.Add(
            @"Opdracht 4: 
Loop naar de winkel.");

        taskDescriptions.Add(
            @"Opdracht 5: 
Kies de producten die op de boodschappenlijst stonden en leg deze op het beurtbalkje bij de kassa.");

        AssignmentManager.instance.OnAssignmentComplete += SwitchText;
        if (textMesh != null) textMesh.SetText(taskDescriptions[0]);
    }

    public void SwitchText(AssignmentManager.Assignment assignment)
    {
        textMesh.SetText(taskDescriptions[(int)assignment]);
    }
}
