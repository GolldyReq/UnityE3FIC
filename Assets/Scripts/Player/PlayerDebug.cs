﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//
//
//UNIQUEMENT POUR TESTER / DEBUGGER 
//
//
public class PlayerDebug : MonoBehaviour
{
    Rigidbody m_Rigidbody;

    [Tooltip("La vitesse en m.s-1")]
    [SerializeField] float m_Speed;

    [SerializeField] CameraDebug camera;
    private Vector3 m_InitialPos;
    private Vector3 m_InitialCameraPos;

    [Header("Puissance du saut")]
    [SerializeField] float m_Jump;
    private bool m_OnGround;
    [SerializeField] float m_JumpCooldown;
    private float m_NextJump;

    public PlayerSize m_PlayerSize;
    public PlayerColor m_PlayerColor;
    //public PlayerMass m_PlayerMass;


    private void Awake()
    {
        m_Rigidbody = GetComponentInChildren<Rigidbody>();
        m_PlayerSize = new PlayerSize();
        m_PlayerColor = new PlayerColor(this);
        //m_PlayerColor = new PlayerColor(this,"blue");
        //m_PlayerColor = new PlayerColor(this,"red","yellow");
    }

    // Start is called before the first frame update
    void Start()
    {
        m_OnGround = true;
        m_NextJump = Time.time;
        m_InitialPos = transform.position;
        //m_InitialCameraPos = camera.transform.position;
        camera.setNewSpawnPos(camera.transform);
    }

    private void Update()
    {
        //Changement de taille
        m_PlayerSize.ChangeSize(this);
    }


    private void FixedUpdate()
    {
        //Mouvement
        //Recuperation valeur Joystick
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        //Vecteur de translation avec les inputs
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        movement = Vector3.ClampMagnitude(movement, 1);
        //Peut etre mis en commentaire pour changer le style
        var actualDirection = camera.transform.TransformDirection(movement);
        actualDirection.y = 0;
        //m_Rigidbody.AddForce(actualDirection * m_Speed * Time.fixedDeltaTime, ForceMode.VelocityChange);
        //m_PlayerSize.ChangeSize(this);

        //Si au sol : Mouvement sinon Limiter le "air-control"
        if (m_OnGround)
            m_Rigidbody.AddForce(actualDirection * m_Speed * Time.fixedDeltaTime, ForceMode.VelocityChange);
        else
            m_Rigidbody.AddForce((0.5f * actualDirection  * m_Speed * Time.fixedDeltaTime), ForceMode.VelocityChange);



        //Saut
        bool Is_Jumped = Input.GetButton("Saut");
        if (Is_Jumped && m_OnGround && Time.time > m_NextJump)
        {
            m_Rigidbody.AddForce(Vector3.up * m_Jump * Time.fixedDeltaTime, ForceMode.Impulse);
            //m_Rigidbody.AddForce(Vector3.up *m_Jump* Time.fixedDeltaTime, ForceMode.VelocityChange);
            m_OnGround = false;
            m_NextJump = Time.time + m_JumpCooldown;
        }

        //fusion couleur
        if (Input.GetButton("Fusion"))
            m_PlayerColor.FusionColor();

    }

    //Gestion des collisions
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Plateforme") || collision.gameObject.CompareTag("Decor"))
            m_OnGround = true;
    }
    private void OnCollisionEnter(Collision collision)
    {
        //Detection avec plateforme ou décor
        if (collision.gameObject.CompareTag("Plateforme") || collision.gameObject.CompareTag("Decor"))
            m_OnGround = true;

        //Detection avec un objet qui tue le joueur
        if (collision.gameObject.CompareTag("Killable"))
        {
            m_Rigidbody.velocity = Vector3.zero;
            m_Rigidbody.isKinematic = true;
            m_Rigidbody.isKinematic = false;
            transform.position = m_InitialPos;
            //camera.position = m_InitialCameraPos;
            camera.respawn();
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Plateforme") || collision.gameObject.CompareTag("Decor"))
            m_OnGround = false;
    }

    //Entrée dans un trigger
    private void OnTriggerEnter(Collider other)
    {
        //Trigger tuant le player
        if (other.gameObject.CompareTag("Killable"))
        {
            m_Rigidbody.velocity = Vector3.zero;
            m_Rigidbody.isKinematic = true;
            m_Rigidbody.isKinematic = false;
            transform.position = m_InitialPos;
            //camera.position = m_InitialCameraPos;
            camera.respawn();

        }
        //Trigger bloc de peinture modifiant la couleur du joueur
        if (other.gameObject.CompareTag("Paint"))
            m_PlayerColor.Paint(other.GetComponent<MeshRenderer>());

        //Trigger checkpoint
        if (other.gameObject.CompareTag("CheckPoint"))
        {
            Transform posPlayer = other.gameObject.transform.parent.Find("NewPosPlayer").gameObject.transform;
            Transform posCamera = other.gameObject.transform.parent.Find("NewPosCamera").gameObject.transform;
            //Debug.Log(posPlayer.position.ToString());
            //Debug.Log(posCamera.position.ToString());
            Debug.Log("Checkpoint atteint !");
            setSpawnPosition(posPlayer, posCamera);
        }
    }

    public void setSpawnPosition(Transform newSpawnPosition, Transform newCameraPosition)
    {
        this.m_InitialPos = newSpawnPosition.transform.position;
        camera.setNewSpawnPos(newCameraPosition);
    }
}
