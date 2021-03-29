using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystemController : MonoBehaviour
{
    public static ParticleSystemController instance;
    public ParticleSystem rain;
    public ParticleSystem mist1;
    public ParticleSystem mist2;


    void Awake()
    {
        instance = this;
    }

    public void SetRainEmissionRate(float rate)
    {
        ParticleSystem.EmissionModule emission = rain.emission;
        emission.rateOverTime = rate;
    }

    public void SetMistEmissionRate(float rate)
    {
        ParticleSystem.EmissionModule emission1 = mist1.emission;
        emission1.rateOverTime = rate;

        ParticleSystem.EmissionModule emission2 = mist2.emission;
        emission2.rateOverTime = rate;
    }

}
