using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class uvod_casovac : MonoBehaviour
{
    public static bool timerIsRunning, cas_uplynul;
    public CanvasGroup uvodcanvas, menucanvas;
    public static float timeLeft;
    // Start is called before the first frame update
    void Start()
    {
        timeLeft = 2f; //cas v sekundach
        timerIsRunning = true;
        cas_uplynul = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerIsRunning)
        {
            if (timeLeft > 0)
            {
                timeLeft -= Time.deltaTime;
                //DisplayTime(timeLeft);
            }
            else
            {
                Debug.Log("Cas hry uplynul!");
                timeLeft = 0;
                //DisplayTime(timeLeft);
                //text.text = "00:00";
                timerIsRunning = false;
                cas_uplynul = true;
                uvodcanvas.gameObject.SetActive(false);
                menucanvas.gameObject.SetActive(true);
            }
        }
        /*else
        {
            DisplayTime(timeLeft - 1);//ak nepresli tutorialom, tak cas neni spusteny, ale musi byt urceny
        }*/
    }
}
