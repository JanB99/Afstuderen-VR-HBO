using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Data", menuName = "NewSymptomPreset/OpticNeuritisPreset", order = 2)]
public class OpticNeuritisPreset : ScriptableObject
{
    public bool voidVision;
    public float blurAmount;
    public float scale;
    public List<Texture2D> fieldDefects;
}
