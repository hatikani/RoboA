using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGan : MonoBehaviour
{
  
    [SerializeField] GameObject _bullet;
    [SerializeField] GameObject _raysight;
    [SerializeField] GameObject _player;
    [SerializeField] GameObject _ganpos;
    [SerializeField] GameObject _stand;
    [SerializeField] GameObject _barrel;
    [SerializeField] float _speed = 1500;
   private  bool _atcak;
    Rigidbody _rb;
    private void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Playercore");
       


    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
       
        Vector3 lookDirectionS = (_player.transform.position - _stand.transform.position).normalized;
        Vector3 lookDirectionG = (_player.transform.position - _ganpos.transform.position).normalized;
        Vector3 lookDirectionR = (_player.transform.position - _raysight.transform.position).normalized;
        float Srotxz = Mathf.Atan2(lookDirectionG.x,lookDirectionG.z) * Mathf.Rad2Deg;
        float Grotyz = Mathf.Atan2(lookDirectionS.y, lookDirectionS.z) * Mathf.Rad2Deg;
        float Rrotyz = Mathf.Atan2(lookDirectionR.y, lookDirectionR.z) * Mathf.Rad2Deg;
       if(Grotyz>0)
        {
            Grotyz = -(Grotyz * 1);
        }
        _stand.transform.rotation = Quaternion.Euler(-90,0, Srotxz-90);
        _raysight.transform.rotation = Quaternion.Euler(-Rrotyz,Srotxz+180, 0);
        _ganpos.transform.rotation = Quaternion.Euler(-Grotyz , _stand.transform.eulerAngles.y-90 , _ganpos.transform.rotation.x+90);

        if(_atcak)
        {
            _barrel.transform.Rotate(0, 0, 4);
        }
    }
    public void DisRay(float _dis)
    {
        Debug.DrawRay(_raysight.transform.position,
           _raysight.transform.forward * _dis, Color.red);

    }
    public void Atcak()
    {
        _atcak = true;
        _rb = Instantiate(_bullet, transform.position,
            Quaternion.Euler(transform.parent.eulerAngles.x, transform.parent.eulerAngles.y, 0))
            .GetComponent<Rigidbody>();
        _rb.AddForce(transform.forward * _speed);
    }
    public void NoAtcak()
    {
        _atcak = false;
    }
   
}
