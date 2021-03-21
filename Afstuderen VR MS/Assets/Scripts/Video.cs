using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Video : MonoBehaviour
{

    private VideoPlayer video;

    void Start()
    {
        AreaManager.instance.onInsideChange += StartVideo;
        video = GetComponent<VideoPlayer>();
    }

    private void StartVideo(bool isInside) {
        if (isInside)
        {
            video.Stop();
        }
        else {
            video.Play();
        }
        
    }
}
