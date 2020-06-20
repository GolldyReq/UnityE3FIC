using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApparitionBillard : MonoBehaviour
{

    [SerializeField] Trou[] m_TrouARemplir;
    //Object a detruire a la résolution de l'enigme
    [SerializeField] GameObject[] m_Destruct;
    private bool IsDejaOuvert;

    // Start is called before the first frame update
    void Start()
    {
        IsDejaOuvert = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Booléen temporaire pour savoir si tout les trous sont remplis
        bool IsOpen = true;
        foreach (Trou trou in m_TrouARemplir)
        {
            if (!trou.IsRempli())
                IsOpen = false;
        }
        if (IsOpen && !IsDejaOuvert)
            Ouverture();
    }

    private void Ouverture()
    {
        gameObject.transform.Find("Teleporteur").gameObject.SetActive(true);
        StartCoroutine(HUDManager.PrintMessageForSecondes("Un téléporteur est apparu ! ", 3f));
        for (int i = 0; i < m_Destruct.Length; i++)
            Destroy(m_Destruct[i]);
        IsDejaOuvert = true;

    }
}
