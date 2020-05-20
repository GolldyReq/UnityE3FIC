using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleCoroutine : MonoBehaviour
{

     // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    
    public static IEnumerator RescaleAnimation(Player player)
    {
        player.m_PlayerSize.CoroutineSizeFinish = false ;
        Vector3 TargetScale = new Vector3(1f,1f,1f);
        if (player.m_PlayerSize.Size == PlayerSize.PLAYERSIZE.Small)
            TargetScale = new Vector3(.5f, .5f, .5f);

        if (player.m_PlayerSize.Size == PlayerSize.PLAYERSIZE.Normal)
            TargetScale = new Vector3(1f, 1f, 1f);

        if (player.m_PlayerSize.Size == PlayerSize.PLAYERSIZE.Big)
            TargetScale = new Vector3(2f, 2f, 2f);
        float duree = 0.5f; 
        
        Vector3 scaleStart = player.gameObject.transform.localScale;
        float elapsedTime = 0;
        while (elapsedTime < duree)
        {
            float k = elapsedTime / duree;
            player.gameObject.transform.localScale = Vector3.Lerp(scaleStart, TargetScale, k);
            elapsedTime += Time.deltaTime;
            yield return null; // Attendre la prochaine frame 
        }
        player.gameObject.transform.localScale = TargetScale;
        player.m_PlayerSize.CoroutineSizeFinish = true;
    }

    //Version Debug

    public static IEnumerator RescaleAnimation(PlayerDebug player)
    {
        player.m_PlayerSize.CoroutineSizeFinish = false;
        Vector3 TargetScale = new Vector3(1f, 1f, 1f);
        if (player.m_PlayerSize.Size == PlayerSize.PLAYERSIZE.Small)
            TargetScale = new Vector3(.5f, .5f, .5f);

        if (player.m_PlayerSize.Size == PlayerSize.PLAYERSIZE.Normal)
            TargetScale = new Vector3(1f, 1f, 1f);

        if (player.m_PlayerSize.Size == PlayerSize.PLAYERSIZE.Big)
            TargetScale = new Vector3(2f, 2f, 2f);
        float duree = 0.5f;

        Vector3 scaleStart = player.gameObject.transform.localScale;
        float elapsedTime = 0;
        while (elapsedTime < duree)
        {
            float k = elapsedTime / duree;
            player.gameObject.transform.localScale = Vector3.Lerp(scaleStart, TargetScale, k);
            elapsedTime += Time.deltaTime;
            yield return null; // Attendre la prochaine frame 
        }
        player.gameObject.transform.localScale = TargetScale;
        player.m_PlayerSize.CoroutineSizeFinish = true;
    }

}
