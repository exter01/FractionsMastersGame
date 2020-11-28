using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class Hra_loading_param : MonoBehaviour
{
    public VideoPlayer loading_video;

    // Start is called before the first frame update
    void Start()
    {
        loading_video.loopPointReached += EndReached;
        loading_video.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void EndReached(UnityEngine.Video.VideoPlayer vp)
    {
        SceneManager.LoadScene("Hra");
    }
}
