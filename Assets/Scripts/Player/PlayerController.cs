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



    private void Awake()
    {
        m_Rigidbody = GetComponentInChildren<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        m_OnGround = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {

        float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");


        //Vecteur de translation avec les inputs
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);


        //Déplacement sans prendre en compte la caméra
        //m_Rigidbody.AddForce(movement * m_Speed * Time.fixedDeltaTime, ForceMode.VelocityChange);
        //m_Rigidbody.AddForce(-movement/2 * m_Speed * Time.fixedDeltaTime, ForceMode.VelocityChange);
        


        
        //Pour que la balle se déplace selon la position de la caméra
        //Vector3 controlDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        var actualDirection = camera.TransformDirection(movement);
        m_Rigidbody.AddForce(actualDirection * m_Speed * Time.fixedDeltaTime, ForceMode.VelocityChange);


        bool Is_Jumped = Input.GetButton("Fire1");
        if (Is_Jumped && m_OnGround)
        {
            Debug.Log("Saut");
            //Vector3 dirJump = new Vector3(0, actualDirection.y, 0);
            //Debug.Log("Vect : " + dirJump.ToString());
            m_Rigidbody.AddForce(Vector3.up *m_Jump* Time.fixedDeltaTime, ForceMode.Impulse);
            m_OnGround = false;
            
        }
        //if (transform.position.y == 0.5)
          //  m_OnGround = true;
        


    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Plateforme") || collision.gameObject.CompareTag("Decor"))
            m_OnGround = true;
    }



}
