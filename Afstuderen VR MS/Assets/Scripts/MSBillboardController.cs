using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class MSBillboardController : MonoBehaviour
{

    private VideoPlayer video;

    void Start()
    {
        AreaManager.instance.OnInsideChange += StartVideo;
        video = GetComponent<VideoPlayer>();
    }

    private void StartVideo(bool isInside) {

        if (!isActiveAndEnabled) return;

        if (isInside)
        {
            video.Stop();
        }
        else {
            video.Play();
        }
        
    }
}
