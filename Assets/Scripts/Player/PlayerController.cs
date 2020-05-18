using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour,IColorable
{

    Rigidbody m_Rigidbody;

    [Tooltip("La vitesse en m.s-1")]
    [SerializeField] float m_Speed;

    [SerializeField] Transform camera;

    [Header("Puissance du saut")]
    [SerializeField] float m_Jump;

    private bool m_OnGround;
    [SerializeField] float m_JumpCooldown;
    private float m_NextJump;

    private float m_SizeChangeCoolDown;
    private float m_NextSizeChange;
    private bool m_CoroutineSizeFinish;


    private string m_Size;
    private string m_Color;
    private int m_Mass;


    private Vector3 m_InitialPos;
    private Vector3 m_InitialCameraPos;

    private int m_Life;
    
    private void Awake()
    {
        m_Rigidbody = GetComponentInChildren<Rigidbody>();
        m_Life = 3;
    }

    // Start is called before the first frame update
    void Start()
    {
        m_OnGround = true;
        m_NextJump = Time.time;

        m_SizeChangeCoolDown = 0.5f;
        m_NextSizeChange = Time.time;
        m_CoroutineSizeFinish = true;

        m_Size = "Normal";
        m_Color = "White";
        m_Mass = 0;

        m_InitialPos = transform.position;
        m_InitialCameraPos = camera.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void FixedUpdate()
    {
        if (!GameManager.Instance.IsPlaying) return;
        
        //Mouvement
        //Recuperation valeur Joystick
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        //Vecteur de translation avec les inputs
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        movement = Vector3.ClampMagnitude(movement, 1);
        //Peut etre mis en commentaire pour changer le style
        var actualDirection = camera.TransformDirection(movement);
        m_Rigidbody.AddForce(actualDirection * m_Speed * Time.fixedDeltaTime, ForceMode.VelocityChange);


        //Changement de taille
        //Savoir s'il est possible de changer de taille
        RaycastHit hit;
        float taille_agrandissement = 1.2f;
        bool IsPossibleToGrowUp = true;
        if (m_Size == "Small")
            taille_agrandissement = 1.2f;

        //On verifie que le grandissement ne provoque pas de collision       
        //Verifier si le centre de la sphére va toucher 
        //if (Physics.Raycast(transform.position, Vector3.up, out hit, taille_agrandissement))
        if (m_Size != "Big")
        {
            //Verification collision au dessus
            if (Physics.SphereCast(transform.position, 0.1f, Vector3.up, out hit, taille_agrandissement))
            {
                Debug.DrawRay(transform.position, Vector3.up * hit.distance, Color.red);
                IsPossibleToGrowUp = false;
                //m_NextSizeChange = Time.time + m_SizeChangeCoolDown;
            }
            //Avant/arriere
            if (Physics.SphereCast(transform.position, 0.1f, Vector3.forward, out hit, taille_agrandissement)
                && Physics.SphereCast(transform.position, 0.1f, -Vector3.forward, out hit, taille_agrandissement))
            {
                IsPossibleToGrowUp = false;
                //m_NextSizeChange = Time.time + m_SizeChangeCoolDown;
            }
            //Gauche/droite
            if (Physics.SphereCast(transform.position, 0.1f, Vector3.right, out hit, taille_agrandissement)
                && Physics.SphereCast(transform.position, 0.1f, -Vector3.right, out hit, taille_agrandissement))
            {
                IsPossibleToGrowUp = false;
                //m_NextSizeChange = Time.time + m_SizeChangeCoolDown;
            }
        }

        //Changement de taille avec L1/R1 si cela est possible
        if (Time.time > m_NextSizeChange && m_CoroutineSizeFinish)
        {
            if (IsPossibleToGrowUp && m_Size != "Normal")
            {
                //m_Rigidbody.transform.localScale = new Vector3(1f, 1f, 1f);
                m_Size = "Normal";
                StartCoroutine(ScaleCoroutine.RescaleAnimation(this));
            }

            if (Input.GetButton("Small") && m_Size == "Normal")
            {
                //m_Rigidbody.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                m_Size = "Small";
                StartCoroutine(ScaleCoroutine.RescaleAnimation(this));
            }

            if (Input.GetButton("Big") && IsPossibleToGrowUp && m_Size == "Normal")
            {
                //m_Rigidbody.transform.localScale = new Vector3(2f, 2f, 2f);
                m_Size = "Big";
                StartCoroutine(ScaleCoroutine.RescaleAnimation(this));
            }
        }


        //Saut
        //Faire sauter le joueur
        bool Is_Jumped = Input.GetButton("Saut");
        if (Is_Jumped && m_OnGround && Time.time > m_NextJump)
        {
            Debug.Log("Saut");
            m_Rigidbody.AddForce(Vector3.up * m_Jump * Time.fixedDeltaTime, ForceMode.Impulse);
            //m_Rigidbody.AddForce(Vector3.up *m_Jump* Time.fixedDeltaTime, ForceMode.VelocityChange);
            m_OnGround = false;
            m_NextJump = Time.time + m_JumpCooldown;
        }

        //fusion couleur
        if (Input.GetButton("Fusion"))
        {
            FusionColor();
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


    //Entrée dans un trigger
    private void OnTriggerEnter(Collider other)
    {

        //Trigger tuant le player
        if (other.gameObject.CompareTag("Killable"))
        {
            Debug.Log(other.name);
            Debug.Log("Mort du perso");
            /*
            Destroy(gameObject);
            Destroy(GameObject.Find("camera"));
            */
            if (m_Life > 1)
            {
                m_Life--;
                m_Rigidbody.velocity = Vector3.zero;
                m_Rigidbody.isKinematic = true;
                m_Rigidbody.isKinematic = false;
                transform.position = m_InitialPos;
                camera.position = m_InitialCameraPos;
            }
            else
            {
                MenuManager.Instance.GameOver();
            }
        }

        if (other.gameObject.CompareTag("Paint"))
        {
            Paint(other.GetComponent<MeshRenderer>());
        }
    }

    

    public void Paint(MeshRenderer newMaterial)
    {
        MeshRenderer mr = GetComponentInChildren<MeshRenderer>();
        if (mr)
        {
            Material[] ListMaterial = mr.materials;
            
            //changement premiere couleur
            if (newMaterial.material.name[0]=='L')
                ListMaterial[0] = newMaterial.material;
            //Changement seconde couleur
            if (newMaterial.material.name[0]=='R')
                ListMaterial[1] = newMaterial.material;
            //Changement 2 couleurs 
            if (newMaterial.material.name[0] == 'F' )
            {
                ListMaterial[0] = newMaterial.material;
                ListMaterial[1] = newMaterial.material;
            }
            mr.materials = ListMaterial;
        }
    }

    public void FusionColor()
    {
        MeshRenderer mr = GetComponentInChildren<MeshRenderer>();
        if(mr)
        {
            Material[] ListMaterial = mr.materials;
            bool green=false, red=false, blue = false;

            if (ListMaterial[0].name.Contains("Lblue") || ListMaterial[1].name.Contains("Rblue"))
                blue = true ;
            if (ListMaterial[0].name.Contains("Lgreen") || ListMaterial[1].name.Contains("Rgreen"))
                green= true ;
            if (ListMaterial[0].name.Contains("Lred") || ListMaterial[1].name.Contains("Rred"))
                red = true ;

            //Debug.Log(color);

            Debug.Log(ListMaterial[0].name + " + " + ListMaterial[1].name);
            if (blue && red)
            {
                ListMaterial[0] = (Material) Resources.Load("Materials/Paint/Lviolet", typeof(Material));
                ListMaterial[1] = (Material) Resources.Load("Materials/Paint/Rviolet", typeof(Material));
            }
            if (blue && green)
            {
                ListMaterial[0] = (Material)Resources.Load("Materials/Paint/Lciel", typeof(Material));
                ListMaterial[1] = (Material)Resources.Load("Materials/Paint/Rciel", typeof(Material));
            }
            if (green && red)
            {
                ListMaterial[0] = (Material)Resources.Load("Materials/Paint/Ljaune", typeof(Material));
                ListMaterial[1] = (Material)Resources.Load("Materials/Paint/Rjaune", typeof(Material));
            }

            mr.materials = ListMaterial;
        }
    }

    public string getSize() { return m_Size; }
    public void setCoroutineSizeFinish(bool etat) { this.m_CoroutineSizeFinish = etat; }
}
