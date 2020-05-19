using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSize 
{

    public enum PLAYERSIZE { Small , Normal , Big }
    private PLAYERSIZE m_Size;
    public PLAYERSIZE Size { get; set; }

    //private float m_SizeChangeCoolDown;
    //private float m_NextSizeChange;
    private bool m_CoroutineSizeFinish;
    public bool CoroutineSizeFinish { get { return m_CoroutineSizeFinish; } set { m_CoroutineSizeFinish = value ; } }



    public PlayerSize()
    {
        //m_SizeChangeCoolDown = 0.5f;
        //m_NextSizeChange = Time.time;
        m_CoroutineSizeFinish = true;
        m_Size = PLAYERSIZE.Normal;
    }

    //Changement de taille avec L1/R1 si cela est possible
    public void ChangeSize(PlayerController player)
    {
        //Debug.Log(m_CoroutineSizeFinish);
        //if (Time.time > m_NextSizeChange && m_CoroutineSizeFinish)
        if (m_CoroutineSizeFinish)
        {
            if (PlayerCollision.CanPlayerChangeSize(player) && Size != PLAYERSIZE.Normal)//&& (!Input.GetButton("Small") && !Input.GetButton("Big")))
            {
                //m_Rigidbody.transform.localScale = new Vector3(1f, 1f, 1f);
                Size = PLAYERSIZE.Normal;
                player.StartCoroutine(ScaleCoroutine.RescaleAnimation(player));
                Debug.Log("Normal");
            }

            if (Input.GetButton("Small") && m_Size == PLAYERSIZE.Normal)
            {
                //m_Rigidbody.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                Size = PLAYERSIZE.Small;
                Debug.Log("Small");
                player.StartCoroutine(ScaleCoroutine.RescaleAnimation(player));
            }

            if (Input.GetButton("Big") && PlayerCollision.CanPlayerChangeSize(player) && m_Size == PLAYERSIZE.Normal)
            {
                //m_Rigidbody.transform.localScale = new Vector3(2f, 2f, 2f);
                Size = PLAYERSIZE.Big;
                Debug.Log("Small");
                player.StartCoroutine(ScaleCoroutine.RescaleAnimation(player));
            }
        }
    }
}
