﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSize 
{

    public enum PLAYERSIZE { Small , Normal , Big }
    private PLAYERSIZE m_Size;
    public PLAYERSIZE Size { get; set; }

    private bool m_CoroutineSizeFinish;
    public bool CoroutineSizeFinish { get { return m_CoroutineSizeFinish; } set { m_CoroutineSizeFinish = value ; } }

    public PlayerSize()
    {
        m_CoroutineSizeFinish = true;
        m_Size = PLAYERSIZE.Normal;
    }

    //Changement de taille avec L1/R1 si cela est possible
    public void ChangeSize(Player player)
    {
        //if (Time.time > m_NextSizeChange && m_CoroutineSizeFinish)
        if (m_CoroutineSizeFinish)
        {
            if (PlayerCollision.CanPlayerChangeSize(player) && Size != PLAYERSIZE.Normal)//&& (!Input.GetButton("Small") && !Input.GetButton("Big")))
            {
                Size = PLAYERSIZE.Normal;
                player.StartCoroutine(ScaleCoroutine.RescaleAnimation(player));
            }

            if (Input.GetButton("Small") && m_Size == PLAYERSIZE.Normal)
            {
                Size = PLAYERSIZE.Small;
                player.StartCoroutine(ScaleCoroutine.RescaleAnimation(player));
            }

            if (Input.GetButton("Big") && PlayerCollision.CanPlayerChangeSize(player) && m_Size == PLAYERSIZE.Normal)
            {
                Size = PLAYERSIZE.Big;
                player.StartCoroutine(ScaleCoroutine.RescaleAnimation(player));
            }
        }
    }

    //Version Debug
    public void ChangeSize(PlayerDebug player)
    {
        if (m_CoroutineSizeFinish)
        {
            if (PlayerCollision.CanPlayerChangeSize(player) && Size != PLAYERSIZE.Normal)
            {
                Size = PLAYERSIZE.Normal;
                player.StartCoroutine(ScaleCoroutine.RescaleAnimation(player));
            }

            if (Input.GetButton("Small") && m_Size == PLAYERSIZE.Normal)
            {
                Size = PLAYERSIZE.Small;
                player.StartCoroutine(ScaleCoroutine.RescaleAnimation(player));
            }

            if (Input.GetButton("Big") && PlayerCollision.CanPlayerChangeSize(player) && m_Size == PLAYERSIZE.Normal)
            {
                Size = PLAYERSIZE.Big;
                player.StartCoroutine(ScaleCoroutine.RescaleAnimation(player));
            }
        }
    }
}
