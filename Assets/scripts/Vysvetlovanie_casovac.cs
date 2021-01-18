using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vysvetlovanie_casovac : MonoBehaviour
{
    public static float timeLeft = 5f; //cas v sekundach
    public static bool timerIsRunning = false, cas_uplynul = false;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (timerIsRunning)
        {
            if (timeLeft > 0)
            {
                timeLeft -= Time.deltaTime;
            }
            else
            {
                //Debug.Log("Odpocet uplynul!");
                timeLeft = 0;
                timerIsRunning = false;
                cas_uplynul = true;
            }
        }
    }
}
