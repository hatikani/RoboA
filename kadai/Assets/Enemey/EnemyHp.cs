using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHp : MonoBehaviour
{
   [SerializeField] private int _enemyHp =50;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(_enemyHp == 0 ||_enemyHp <0)
        {
        }
    }
    void Rend()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (_enemyHp != 0)
        {
            if (other.gameObject.tag == ("Bullet"))
            {
                _enemyHp -= 10;
                Debug.Log(_enemyHp);
            }
        }
    }
}
