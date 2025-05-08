using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class VideoNext : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    private void Awake()
    {
        videoPlayer = GetComponent<VideoPlayer>();
    }
    private void Update()
    {
        if (videoPlayer.frame == (long)(videoPlayer.frameCount - 1))
        {
            print(" ”∆µ≤•∑≈ÕÍ±œ");
            SceneManager.LoadScene(2);
        }
    }
}
