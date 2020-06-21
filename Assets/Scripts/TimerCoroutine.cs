using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerCoroutine : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public static IEnumerator TimerChrono(double Timer)
    {
        Chrono chronometre = new Chrono();
        //while (GameManager.Instance.m_state != GameManager.GAMESTATE.Victory)
        while (true)
        {
            //Timer = Math.Round(Timer + Time.deltaTime,2);
            Timer++;
            chronometre.TotalTime = Timer;
            chronometre.secondes = (int)Timer%60;
            chronometre.minutes = (int)(Timer / 60)%60;
            chronometre.heures = (int)(chronometre.minutes / 60);
            
            HUDManager.PrintChrono(chronometre.secondes, chronometre.minutes,chronometre.heures);
            HUDManager.AddTime(chronometre.TotalTime);
            //yield return null;
            yield return new WaitForSeconds(1f);
        }
    }
}