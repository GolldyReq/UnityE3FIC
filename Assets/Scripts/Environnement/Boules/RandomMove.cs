using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(AddImpulseToBall(transform.gameObject.GetComponent<Rigidbody>()));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator AddImpulseToBall(Rigidbody rb)
    {
        while (true)
        {
            int x = Random.Range(1, 10);
            int z = Random.Range(1, 10);
            int sensX, sensZ;
            if (x % 2 == 0)
                sensX = 1;
            else
                sensX = -1;
            if (z % 2 == 0)
                sensZ = 1;
            else
                sensZ = -1;
            if(rb.position.y<10.5)
                rb.AddForce(new Vector3(sensX * x, 0, sensZ * z),ForceMode.Impulse);
            yield return new WaitForSeconds(5f);
        }
    }
}
