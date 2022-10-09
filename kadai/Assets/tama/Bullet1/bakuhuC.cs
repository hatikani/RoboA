using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bakuhuC : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.rotation = Quaternion.Euler(0, 90, 0);
        StartCoroutine("Boom");
    }

    // Update is called once per frame
    IEnumerator Boom()
    {
        for (float i = 0; i < 10; i += 5)
        {
            this.transform.localScale = new Vector3(i*3, i*3, i*3);
            yield return new WaitForSeconds(1f);
        }
        Destroy(this.gameObject, 2f);
    }
}
