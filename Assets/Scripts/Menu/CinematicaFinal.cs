using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class CinematicaFinal : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    private bool isPaused = false;

    void Start()
    {
        if (videoPlayer == null)
        {
            videoPlayer = GetComponent<VideoPlayer>();
        }

        videoPlayer.loopPointReached += VideoEnded;
    }

       void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (isPaused)
            {
                videoPlayer.Play();
                isPaused = false;
            }
            else
            {
                videoPlayer.Pause();
                isPaused = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            SkipCinematic();
        }
    }

    void VideoEnded(UnityEngine.Video.VideoPlayer vp)
    {
        SceneManager.LoadScene("Tittle Screen");
    }

    void SkipCinematic()
    {
       SceneManager.LoadScene("Tittle Screen");
    }
}