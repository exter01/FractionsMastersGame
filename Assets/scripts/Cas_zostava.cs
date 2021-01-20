using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Cas_zostava : MonoBehaviour
{
    private TextMeshProUGUI text;
    public static float timeLeft; //cas v sekundach, menime v kazdej hre na custom
    public static bool timerIsRunning, cas_uplynul ;

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        text.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void Start()
    {
        timeLeft = 150f; //cas v sekundach, menime v kazdej hre na custom
        timerIsRunning = false;
        cas_uplynul = false;
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
                //Debug.Log("Cas hry uplynul!");
                timeLeft = 0;
                //DisplayTime(timeLeft);
                text.text = "00:00";
                timerIsRunning = false;
                cas_uplynul = true;
            }
        }
        else
        {
            DisplayTime(timeLeft-1);//ak nepresli tutorialom, tak cas neni spusteny, ale musi byt urceny
        }
    }
}
