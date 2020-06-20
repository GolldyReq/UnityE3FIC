using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buzzer : MonoBehaviour
{

    [SerializeField] GameObject m_Ecran ;

    private bool On ; 
    private bool OnTouch ; 

    // Start is called before the first frame update
    void Start()
    {
        On = false ;
        OnTouch = false ;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("OnCollisionEnter");

        if (other.gameObject.CompareTag("Player"))  
        {
            Debug.Log("OnCollisionEnter with Player");

            MeshRenderer m_MrBuzzer = GetComponent<MeshRenderer>();              // Meshrenderer buzzer
            Material material ;                                                         // Pour le nouveau material
            MeshRenderer m_MrEcran = m_Ecran.GetComponent<MeshRenderer>();

            if (On == false && OnTouch == false )
            {
            Debug.Log(" On ");    
            material = (Material)Resources.Load("Materials/Buzzer/BuzzerOn", typeof(Material));
            m_MrBuzzer.material = material;
            On = true ;
            m_MrEcran.material = (Material)Resources.Load("Materials/Screen/Screen_dice", typeof(Material));

            }

            else if ( On == true && OnTouch == false)
            {
            Debug.Log(" Off ");  
            material = (Material)Resources.Load("Materials/Buzzer/BuzzerOff", typeof(Material));
            m_MrBuzzer.material = material;
            On = false ;
            m_MrEcran.material = (Material)Resources.Load("Materials/Screen/Screen", typeof(Material));
            }
            
            OnTouch = true ;

        }


    }

    private void OnCollisionExit(Collision other)
    {
        OnTouch = false ;
    }

}

