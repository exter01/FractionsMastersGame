using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Cas_zostava : MonoBehaviour
{
    private TextMeshProUGUI text;
    public static float timeLeft = 30f; //cas v sekundach
    public static bool timerIsRunning = false;

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        text.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void Start()
    {
        //timerIsRunning = true;
        //DisplayTime(0);
        text = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timerIsRunning)
        {
            if (timeLeft > 0)
            {
                timeLeft -= Time.deltaTime;
                DisplayTime(timeLeft);
            }
            else
            {
                Debug.Log("Cas hry uplynul!");
                timeLeft = 0;
                //DisplayTime(timeLeft);
                text.text = "00:00";
                timerIsRunning = false;
                Hra_param.show_save_diskette = true;
            }
        }
        else
        {
            DisplayTime(timeLeft-1);//ak nepresli tutorialom, tak cas neni spsuteny, ale musi byt urceny
        }
    }
}
