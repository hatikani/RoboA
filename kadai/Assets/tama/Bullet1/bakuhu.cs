using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bakuhu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Boom");
    }

    // Update is called once per frame
    IEnumerator Boom()
    {
        for (float i = 0; i < 5; i += 2f)
        {
            this.transform.localScale = new Vector3(i, i, i);
            yield return new WaitForSeconds(0.4f);
        }
        Destroy(this.gameObject, 2f);
    }
}
