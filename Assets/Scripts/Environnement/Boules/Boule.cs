using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boule : MonoBehaviour , IBoule
{
    public void Teleport(Transform Position)
    {
        gameObject.transform.position = Position.position;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
