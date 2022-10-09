using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControll : MonoBehaviour
{
    [SerializeField] Transform robo;
    [SerializeField] Transform pivot = null;
    [Range(-0.999f, -0.5f)] public float maxYangle = -0.5f;
    [Range(0.5f, 0.999f)] public float minYangle = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        if (pivot == null)
        {
            pivot = transform.parent;
        }
    }

    // Update is called once per frame
    void Update()
    {
        float RotationX = Input.GetAxis("Mouse X");
        float RotationY = Input.GetAxis("Mouse Y");
        pivot.transform.Rotate(0, RotationX, 0);

        float nowAngle = pivot.transform.localPosition.x;
        if (-RotationY != 0)
        {
            if (0 < RotationY)
            {
                if (minYangle <= nowAngle)
                {
                    pivot.transform.Rotate(RotationY, 0, 0);
                }
            }
        }
        else
        {
            if(nowAngle <= maxYangle)
            {
                pivot.transform.Rotate(RotationY, 0, 0);
            }
        }
        pivot.eulerAngles = new Vector3(pivot.eulerAngles.x, pivot.eulerAngles.y, 0f);
    }
   
}
