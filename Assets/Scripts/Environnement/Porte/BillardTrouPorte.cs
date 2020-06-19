using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillardTrouPorte : MonoBehaviour
{

    [SerializeField] Trou[] m_TrouARemplir;
    [Tooltip("Si true les trous doivent être rempli dans le bon ordre")]
    [SerializeField] bool m_InOrder;
   
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //Booléen temporaire pour savoir si tout les trous sont remplis
        bool IsOpen=true;
        foreach(Trou trou in m_TrouARemplir)
        {
            if (!trou.IsRempli())
                IsOpen = false;
        }
        if (IsOpen)
            Ouverture();
    }
    
    private void Ouverture()
    {
        Destroy(gameObject);
    }
}
