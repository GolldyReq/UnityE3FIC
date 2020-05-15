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

    private bool gtp;

    private void Awake()
    {
        m_Rigidbody = GetComponentInChildren<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        m_OnGround = true;
        m_NextJump = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        m_Rigidbody.transform.localScale = new Vector3(1f, 1f, 1f);

        if (Input.GetButton("Fire1"))
            m_Rigidbody.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        if (Input.GetButton("Fire2"))
            m_Rigidbody.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        if (Input.GetKey("joystick button 4"))
            m_Rigidbody.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        if (Input.GetKey("joystick button 5"))
            m_Rigidbody.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
    }

    private void FixedUpdate()
    {


        float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");


        //Vecteur de translation avec les inputs
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        movement = Vector3.ClampMagnitude(movement, 1);

        //Peut etre mis en commentaire pour changer le style
        var actualDirection = camera.TransformDirection(movement);



        m_Rigidbody.AddForce(actualDirection * m_Speed * Time.fixedDeltaTime, ForceMode.VelocityChange);


        bool Is_Jumped = Input.GetButton("Jump");
        if (Is_Jumped && m_OnGround && Time.time > m_NextJump)
        {
            Debug.Log("Saut");
            m_Rigidbody.AddForce(Vector3.up *m_Jump* Time.fixedDeltaTime, ForceMode.Impulse);
            //m_Rigidbody.AddForce(Vector3.up *m_Jump* Time.fixedDeltaTime, ForceMode.VelocityChange);
            m_OnGround = false;
            gtp = false;
            m_NextJump = Time.time + m_JumpCooldown;

        }
        
     }
    
    
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
    



}
