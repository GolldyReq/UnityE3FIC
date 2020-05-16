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

        /*
        if(!OnChange && !Input.GetButton("Small") && !Input.GetButton("Big"))
            //StartCoroutine(RescaleAnimation(gameObject.transform, new Vector3(1f, 1f, 1f), 1.5f));

        if (Input.GetButton("Small") && !OnChange)
        {
                Debug.Log("Retrecissment");
            StartCoroutine(RescaleAnimation(gameObject.transform, new Vector3(.5f, .5f, .5f), 1.5f));
        }

        if (Input.GetButton("Big") && !OnChange)
        {
            StartCoroutine(RescaleAnimation(gameObject.transform, new Vector3(2f,2f,2f), 1.5f));
        }
        */
    }

    public static IEnumerator RescaleAnimation(PlayerController player)
    {
        Debug.Log("Debut Coroutine - " + player.getSize());
        player.setCoroutineSizeFinish (false);
        Vector3 TargetScale = new Vector3(1f,1f,1f);
        if (player.getSize() == "Small")
            TargetScale = new Vector3(.5f, .5f, .5f);

        if (player.getSize() == "Normal")
            TargetScale = new Vector3(1f, 1f, 1f);

        if (player.getSize() == "Big")
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
        player.setCoroutineSizeFinish(true);
        Debug.Log("Fin Coroutine");


    }
}
