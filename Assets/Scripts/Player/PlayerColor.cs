using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColor : IColorable
{
    public string m_Lcolor;
    public string m_Rcolor;

    private MeshRenderer m_MeshRendererPlayer;
    private Material[] m_ListMaterialPlayer;

    //Initialisation
    public PlayerColor(Player player)
    {
        m_MeshRendererPlayer = player.GetComponentInChildren<MeshRenderer>();
        if (m_MeshRendererPlayer)
        {
            m_ListMaterialPlayer = m_MeshRendererPlayer.materials;
        }
        m_Lcolor = "Lwhite";
        m_ListMaterialPlayer[0] = (Material)Resources.Load("Materials/Paint/" + m_Lcolor, typeof(Material));
        m_Rcolor = "Rwhite";
        m_ListMaterialPlayer[1] = (Material)Resources.Load("Materials/Paint/" + m_Rcolor, typeof(Material));
        m_MeshRendererPlayer.materials = m_ListMaterialPlayer;
    }
    public PlayerColor(Player player , string color) : this(player)
    {
        m_Lcolor = "L" + color;
        m_ListMaterialPlayer[0] = (Material)Resources.Load("Materials/Paint/" + m_Lcolor , typeof(Material));
        m_Rcolor = "R" + color;
        m_ListMaterialPlayer[1] = (Material)Resources.Load("Materials/Paint/" + m_Rcolor, typeof(Material));
        m_MeshRendererPlayer.materials = m_ListMaterialPlayer;
    }
    public PlayerColor(Player player , string lcolor , string rcolor) : this(player)
    {
        m_Lcolor = "L" + lcolor;
        m_ListMaterialPlayer[0] = (Material)Resources.Load("Materials/Paint/" + m_Lcolor, typeof(Material));
        m_Rcolor = "R" + rcolor;
        m_ListMaterialPlayer[1] = (Material)Resources.Load("Materials/Paint/" + m_Rcolor, typeof(Material));
        m_MeshRendererPlayer.materials = m_ListMaterialPlayer;
    }

    //Pour le debug
    public PlayerColor(PlayerDebug player)
    {
        m_MeshRendererPlayer = player.GetComponentInChildren<MeshRenderer>();
        if (m_MeshRendererPlayer)
        {
            m_ListMaterialPlayer = m_MeshRendererPlayer.materials;
        }
        m_Lcolor = "Lwhite";
        m_ListMaterialPlayer[0] = (Material)Resources.Load("Materials/Paint/" + m_Lcolor, typeof(Material));
        m_Rcolor = "Rwhite";
        m_ListMaterialPlayer[1] = (Material)Resources.Load("Materials/Paint/" + m_Rcolor, typeof(Material));
        m_MeshRendererPlayer.materials = m_ListMaterialPlayer;
    }

    //Colorier le joueur lorsqu'il touche un bloc de peinture
    public void Paint(MeshRenderer newMaterial)
    {
        if (m_MeshRendererPlayer)
        {
            string[] name = newMaterial.material.name.Split(' ');
            //changement premiere couleur
            if (newMaterial.material.name[0] == 'L')
                { m_ListMaterialPlayer[0] = newMaterial.material; m_Lcolor = name[0]; }
            //Changement seconde couleur
            if (newMaterial.material.name[0] == 'R')
                { m_ListMaterialPlayer[1] = newMaterial.material; m_Rcolor = name[0]; }
            //Changement des 2 couleurs 
            if (newMaterial.material.name[0] == 'F')
            {
                m_ListMaterialPlayer[0] = newMaterial.material;
                m_Lcolor = "L" + name[0].Substring(1) ;
                m_ListMaterialPlayer[1] = newMaterial.material;
                m_Rcolor = "R" + name[0].Substring(1);
            }
            m_MeshRendererPlayer.materials = m_ListMaterialPlayer;
        }
    }

    //Fusion des coulours si la combinaison est possible
    public void FusionColor()
    {
        if (m_MeshRendererPlayer)
        {
            if (haveColor("blue") && haveColor("red"))
                ChangeColorfusion("violet");
            if (haveColor("blue") && haveColor("green"))
                ChangeColorfusion("sky");
            if (haveColor("green") && haveColor("red"))
                ChangeColorfusion("yellow");
            if (haveColor("yellow") && haveColor("red"))
                ChangeColorfusion("orange");
            if (haveColor("yellow") && haveColor("sky"))
                ChangeColorfusion("green");
            if (haveColor("yellow") && haveColor("violet"))
                ChangeColorfusion("red");
            if (haveColor("sky") && haveColor("violet"))
                ChangeColorfusion("blue");
            m_MeshRendererPlayer.materials = m_ListMaterialPlayer;
        }
    }

    //Retourne vrai si le joueur est composé de la couleur demandé
    public bool haveColor(string color)
    {
        if (m_Lcolor.Contains(color) || m_Rcolor.Contains(color))
            return true;
        return false;
    }

    private void ChangeColorfusion(string fusionResult)
    {
        m_ListMaterialPlayer[0] = (Material)Resources.Load("Materials/Paint/L" + fusionResult, typeof(Material));
        m_Lcolor = "L" + fusionResult;
        m_ListMaterialPlayer[1] = (Material)Resources.Load("Materials/Paint/R" + fusionResult, typeof(Material));
        m_Rcolor = "R" + fusionResult;
    }
}
