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
        while (true)
        {
            Timer = Math.Round(Timer + Time.deltaTime,2);
            HUDManager.PrintChrono(Timer);
            //yield return null;
            yield return new WaitForSeconds(0.02f);
        }
    }
}