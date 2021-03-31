using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public static AudioManager instance;

    public enum Type
    {
        maleVoiceline,
        femaleVoiceline,
        environment,
    }

    [Serializable]
    public class Sound {

        public string name;
        public AudioClip clip;
        [Range(0f, 1f)]
        public float volume = 0.5f;
        [Range(0f, 3f)]
        public float pitch = 1;
        [HideInInspector]
        public AudioSource source;
        public bool loop;
        public Type type;
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

    public void IntervalVoicelines(float interval) {
        InvokeRepeating("PlayRandomVoiceline", interval, interval);
    }

    void PlayRandomVoiceline() {
        //Type t = MultipleScleroseController.instance.gender == MultipleScleroseController.Gender.female ? Type.femaleVoiceline : Type.maleVoiceline;
        Type t = Type.femaleVoiceline;
        switch (MultipleScleroseController.instance.gender)
        {
            case MultipleScleroseController.Gender.female:
                t = Type.femaleVoiceline;
                break;
            case MultipleScleroseController.Gender.male:
                t = Type.maleVoiceline;
                break;
        }

        //Type t = MultipleScleroseController.instance.gender switch
        //{
        //    MultipleScleroseController.Gender.female => Type.femaleVoiceline,
        //    MultipleScleroseController.Gender.male => Type.maleVoiceline,
        //    _ => throw new NotImplementedException(),
        //};

        List<Sound> voiceLines = (from sound in sounds where sound.type == t select sound).ToList();
        int index = UnityEngine.Random.Range(0, voiceLines.Count);

        voiceLines[index].source.volume = .5f;
        voiceLines[index].source.Play();
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
}
