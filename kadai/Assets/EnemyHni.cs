using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHni : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -40)
        {
            transform.position = new Vector3(-40, transform.position.y, transform.position.z);
        }
        if (transform.position.x > 40)
        {
            transform.position = new Vector3(40, transform.position.y, transform.position.z);
        }       
        if (transform.position.z > 40)
        {
            transform.position = new Vector3( transform.position.x, transform.position.y, 40);
        }
        if (transform.position.z < -40)
        {
            transform.position = new Vector3( transform.position.x, transform.position.y, -40);
        }
        if(transform.position.y <-1)
        {
            transform.position = new Vector3(transform.position.x, 0.25f, transform.position.z);
        }
    }
}
