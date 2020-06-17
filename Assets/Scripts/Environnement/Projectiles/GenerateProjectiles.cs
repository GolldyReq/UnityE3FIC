using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateProjectiles : MonoBehaviour
{
    [SerializeField] Transform generator;
    [SerializeField] GameObject projectile;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GenerateProjectileCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator GenerateProjectileCoroutine()
    {
        while (true)
        {
            GameObject newProjectile = Instantiate(projectile, generator.position, Quaternion.identity);
            newProjectile.GetComponentInChildren<Rigidbody>().AddForce(-Vector3.up * 10, ForceMode.VelocityChange);
            //Destroy(newProjectile, 5f);
            //yield return null;
            yield return new WaitForSeconds(2f);
        }
    }
}
