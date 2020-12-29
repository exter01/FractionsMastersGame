using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class Hra_loading_param : MonoBehaviour
{
    public VideoPlayer loading_video;
    public static bool zobraz_uvod;
    public CanvasGroup canvasuvod, canvasloading;

    // Start is called before the first frame update
    void Start()
    {
        loading_video.url = System.IO.Path.Combine(Application.streamingAssetsPath, "beh_spat.mp4");
        loading_video.loopPointReached += EndReached;
        if(zobraz_uvod == false)
        {
            ClickRozumiem();
            /*canvasuvod.gameObject.SetActive(false);
            canvasloading.gameObject.SetActive(true);
            loading_video.Play();*/
        }
    }

    public void ClickRozumiem()
    {
        canvasuvod.gameObject.SetActive(false);
        canvasloading.gameObject.SetActive(true);
        loading_video.Play();
        zobraz_uvod = false;
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
