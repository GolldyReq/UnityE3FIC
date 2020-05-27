using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformTool : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static IEnumerator PlatformWaiting(float time)
    {
        yield return new WaitForSeconds(time);
    }

    
    public static IEnumerator MovePlatform( MovingPlatform platform , float time)
    {
        Debug.Log("PlayMOVE");
        platform.coroutinePlaying = true;
        float elapsedTime = 0;
        float duree;
        Vector3 Target;
        if (platform.m_Direction==1)
        {
            Target = platform.m_GoalPos;
            
        }
        else
        {
            Target = platform.m_GoalNeg;
        }
        //duree = Math.Abs((platform.transform.position - Target).magnitude / platform.m_Speed);
        //Debug.Log(duree.ToString());
        while (platform.transform.position != Target)
        {
            float k = elapsedTime * platform.m_Speed / 1000;
            platform.gameObject.transform.position = Vector3.Lerp(platform.transform.position, Target, k);
            elapsedTime += Time.deltaTime;
            if ((platform.transform.position - Target).magnitude < 0.01f)
                platform.transform.position = Target;
            yield return null; // Attendre la prochaine frame 
        }
        Debug.Log("Fin Translation");
        yield return new WaitForSeconds(time);
        platform.coroutinePlaying = false;
        platform.m_Direction = platform.m_Direction * (-1);
    }
    
}
