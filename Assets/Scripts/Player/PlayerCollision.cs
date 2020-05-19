using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision
{

    public static bool CanPlayerChangeSize(PlayerController player)
    {
        bool IsPossibleToGrowUp = true ;
        RaycastHit hit;
        float taille_agrandissement = 1.2f;


        //On verifie que le grandissement ne provoque pas de collision       
        //Verifier si le centre de la sphére va toucher 
        //if (Physics.Raycast(transform.position, Vector3.up, out hit, taille_agrandissement))
        if (player.m_PlayerSize.Size!=PlayerSize.PLAYERSIZE.Big)
        {
            //Verification collision au dessus
            if (Physics.SphereCast(player.transform.position, 0.1f, Vector3.up, out hit, taille_agrandissement))
            {
                Debug.DrawRay(player.transform.position, Vector3.up * hit.distance, Color.red);
                IsPossibleToGrowUp = false;
                //m_NextSizeChange = Time.time + m_SizeChangeCoolDown;
            }
            //Avant/arriere
            if (Physics.SphereCast(player.transform.position, 0.1f, Vector3.forward, out hit, taille_agrandissement)
                && Physics.SphereCast(player.transform.position, 0.1f, -Vector3.forward, out hit, taille_agrandissement))
            {
                IsPossibleToGrowUp = false;
                //m_NextSizeChange = Time.time + m_SizeChangeCoolDown;
            }
            //Gauche/droite
            if (Physics.SphereCast(player.transform.position, 0.1f, Vector3.right, out hit, taille_agrandissement)
                && Physics.SphereCast(player.transform.position, 0.1f, -Vector3.right, out hit, taille_agrandissement))
            {
                IsPossibleToGrowUp = false;
                //m_NextSizeChange = Time.time + m_SizeChangeCoolDown;
            }

        }

        
        return IsPossibleToGrowUp;
    }
}
