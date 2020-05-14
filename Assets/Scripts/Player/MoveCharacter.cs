using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCharacter : MonoBehaviour
{

    public float speed = 10f;
    public float speedRotation = 100f;
    public float gravity = 10f;
    public float jumpSpeed = 7f;

    CharacterController controller;
    Vector3 moveDirection;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController> ();
    }

    // Update is called once per frame
    void Update()
    {
        if(controller.isGrounded)
        {
            moveDirection = new Vector3(0, 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;

            if(Input.GetButtonDown("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }
        }

        moveDirection.y -= gravity * Time.deltaTime;
        transform.Rotate(Vector3.up * Input.GetAxis("Horizontal") * Time.deltaTime * speedRotation);
        controller.Move(moveDirection * Time.deltaTime);
    }
}
