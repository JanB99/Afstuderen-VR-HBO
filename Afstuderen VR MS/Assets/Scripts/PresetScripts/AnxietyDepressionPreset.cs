using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Data", menuName = "NewSymptomPreset/AnxietyDepressionPreset", order = 1)]
public class AnxietyDepressionPreset : ScriptableObject
{
    public float numRainParticles;
    public float numMistParticles;
    public bool wheelchair;
    public bool bottles;
    public bool pamphlet;
    public bool billboard;
    public float interval;
    public bool hasCemetary;
    public Material skybox;
}
