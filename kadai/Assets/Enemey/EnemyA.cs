using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyA : MonoBehaviour
{
    [SerializeField] GameObject _player;
    [SerializeField] EnemyGan _enemyGan;
    bool _attack;
    float time;
    private void Awake()
    {
        _enemyGan = GameObject.FindObjectOfType<EnemyGan>();
    }
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 _playerpos = _player.transform.position;
        Vector3 Enemypos = transform.position;
        float _dis = Vector3.Distance(_playerpos, Enemypos);
        // Debug.Log(_dis);
        if (_dis < 30)
        {
            _attack = true;
            _enemyGan.DisRay(_dis);
        }
        if (_dis > 30)
        {
            _attack = false;
        }
        if (_attack)
        {
            time += Time.deltaTime;
            if (time < 0.1) return;
            time = 0;
            {
                _enemyGan.Atcak();
            }
        }
        if (!_attack)
        {
            _enemyGan.NoAtcak();
        }
    }
}
