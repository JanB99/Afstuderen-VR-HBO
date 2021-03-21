using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{

    public static AudioManager instance;

    [System.Serializable]
    public class Sound {

        public string name;
        public AudioClip clip;
        [Range(0f, 1f)]
        public float volume;
        [Range(0f, 3f)]
        public float pitch;
        [HideInInspector]
        public AudioSource source;
        public bool loop;
    }

    
    public List<Sound> sounds;

    public void Play(string name) {
        foreach (Sound s in sounds) {
            if (s.name == name) {
                s.source.Play();
            }
        }
    }

    public void SetVolume(string name, float volume)
    {
        foreach (Sound s in sounds)
        {
            if (s.name == name)
            {
                s.source.volume = volume;
            }
        }
    }

    public AudioSource GetAudioSource(string name)
    {
        foreach (Sound s in sounds)
        {
            if (s.name == name)
            {
                return s.source;
            }
        }
        return null;
    }

    void Awake()
    {
        instance = this;

        foreach (Sound s in sounds) {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }


    void Start()
    {
        SetVolume("Rain", .2f);
        Play("Rain");
    }
}
