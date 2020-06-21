using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrintMessageTrigger : MonoBehaviour
{

    [SerializeField] string Message;
    [SerializeField] public Image PcButton;
    [SerializeField] Image XboxButton;
    [SerializeField] Image PsButton;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnTriggerEnter(Collider other)
    {
        Debug.Log("On trigger");
        if (other.gameObject.CompareTag("Player"))
        {
            //Affichage message
            HUDManager.PrintHelpText(Message);
            //Affichage des touches
            if(PcButton!=null && XboxButton!= null && PsButton!=null)
            {
                HUDManager.PrintButtonTouch(PcButton, XboxButton, PsButton);
                
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //Destruction Message
            HUDManager.EraseHelpText();
            //Destruction des touches
            if (PcButton != null && XboxButton != null && PsButton != null)
            {
                HUDManager.EraseButtonTouch(PcButton, XboxButton, PsButton);

            }
        }
    }
}
