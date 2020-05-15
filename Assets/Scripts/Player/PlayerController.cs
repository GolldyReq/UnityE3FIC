using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Tooltip("La vitesse en m.s-1")]
    [SerializeField] float m_Speed;



    Rigidbody m_Rigidbody;

    [SerializeField] Transform camera;


    [Header("Puissance du saut")]
    [SerializeField] float m_Jump;

    private bool m_OnGround;
    [SerializeField] float m_JumpCooldown;
    private float m_NextJump;

    private string m_Size;


    private void Awake()
    {
        m_Rigidbody = GetComponentInChildren<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        m_OnGround = true;
        m_NextJump = Time.time;
        m_Size = "Normal";
    }

    // Update is called once per frame
    void Update()
    {
        //Changement de taille avec L1/R1
        m_Rigidbody.transform.localScale = new Vector3(1f, 1f, 1f);
        if (Input.GetKey("joystick button 4"))
        {
            m_Rigidbody.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            m_Size = "Small";
        }
        if (Input.GetKey("joystick button 5"))
            m_Rigidbody.transform.localScale = new Vector3(2f, 2f, 2f);
    }

    private void FixedUpdate()
    {

        //Recuperation valeur Joystick
        float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");


        //Vecteur de translation avec les inputs
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        movement = Vector3.ClampMagnitude(movement, 1);
        //Peut etre mis en commentaire pour changer le style
        var actualDirection = camera.TransformDirection(movement);

        m_Rigidbody.AddForce(actualDirection * m_Speed * Time.fixedDeltaTime, ForceMode.VelocityChange);

        //Faire sauter le joueur
        bool Is_Jumped = Input.GetButton("Fire1");
        if (Is_Jumped && m_OnGround && Time.time > m_NextJump)
        {
            Debug.Log("Saut");
            m_Rigidbody.AddForce(Vector3.up *m_Jump* Time.fixedDeltaTime, ForceMode.Impulse);
            //m_Rigidbody.AddForce(Vector3.up *m_Jump* Time.fixedDeltaTime, ForceMode.VelocityChange);
            m_OnGround = false;
            m_NextJump = Time.time + m_JumpCooldown;
        }
        
     }
    
    //Gestion des collisions
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Plateforme") || collision.gameObject.CompareTag("Decor"))
            m_OnGround = true;
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Plateforme") || collision.gameObject.CompareTag("Decor"))
            m_OnGround = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Plateforme") || collision.gameObject.CompareTag("Decor"))
            m_OnGround = false;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Killable"))
        {
            Debug.Log(other.name);
            Debug.Log("Mort du perso");
            Destroy(gameObject);
            Destroy(GameObject.Find("camera"));
        }
    }


}
