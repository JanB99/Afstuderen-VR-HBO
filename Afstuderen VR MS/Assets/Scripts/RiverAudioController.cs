using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class RiverAudioController : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        AreaManager.instance.OnInsideChange += UpdateAudio;
        audioSource = GetComponent<AudioSource>();
    }

    void UpdateAudio(bool isInside) {
        audioSource.volume = isInside ? .2f : .5f;
    }
 
}
