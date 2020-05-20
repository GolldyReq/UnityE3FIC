using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrintMessageTrigger : MonoBehaviour
{

    [SerializeField] string Message;

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
        if (other.gameObject.CompareTag("Player"))
        {
            HUDManager.PrintHelpText(Message);
            Debug.Log(Message);
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            HUDManager.EraseHelpText();
        }
    }
}
