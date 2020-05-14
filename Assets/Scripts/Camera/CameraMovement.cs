using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    Transform targetCamera;
    Vector3 to;
    Transform targetCharacter;

    // Start is called before the first frame update
    void Start()
    {
        targetCamera = GameObject.Find("Target").transform;
        targetCharacter = GameObject.Find("Sphere").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position,targetCamera.position, 1);
        to = targetCharacter.transform.position - transform.position;
        transform.rotation = Quaternion.Slerp(transform.rotation,Quaternion.LookRotation(to),1);
    }
}
