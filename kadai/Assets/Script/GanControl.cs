using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GanControl : MonoBehaviour
{
    [SerializeField] GameObject _bullet;

    [SerializeField] RoboContror RoboContror;

    [SerializeField] ParticleSystem _muzzleflash;

    private AudioSource _audioSource;
    [SerializeField] AudioClip _audioreload;
    [SerializeField] AudioClip _audioshoot;

    [SerializeField] int _magazine = 18;
    [SerializeField] int _bullets = 100;
    [SerializeField] float _bulletspeed = 2000;
    [SerializeField] float _raydis = 100;
    float _time;
    float _reloadtime;

    bool Reload;
    bool Firstshoot;
    bool Bullethet;

    Rigidbody _rb;

    [SerializeField] Text _magazinetext;
    [SerializeField] Text _bulletstext;
    [SerializeField] Text _reloadtext;


    private void Awake()
    {
        _magazinetext = GameObject.Find("Magazine").GetComponent<Text>();
        _bulletstext = GameObject.Find("Bullets").GetComponent<Text>();
        _reloadtext = GameObject.Find("Reload").GetComponent<Text>();
        RoboContror = GameObject.FindObjectOfType<RoboContror>();
       
    }
    void Start()
    {
        _reloadtext.enabled = false;
        _time = 0;
        _reloadtime = 0;
        _audioSource = gameObject.AddComponent<AudioSource>();
    }
  
    private void Shoot()
    {

        _muzzleflash.transform.position = transform.position;
        _muzzleflash.transform.rotation = transform.rotation;
        _muzzleflash.Play();

        _rb = Instantiate(_bullet, transform.position,
            Quaternion.Euler(transform.parent.eulerAngles.x, transform.parent.eulerAngles.y, 0))
            .GetComponent<Rigidbody>();
        _rb.AddForce(transform.forward * _bulletspeed);

        _magazine -= 1;
        _audioSource.PlayOneShot(_audioshoot);


    }
    // Update is called once per frame
    void Update()
    {
        

        if (!Reload)
        {
            if (_magazine > 0)
            {
                if (Input.GetMouseButton(0))
                {
                    _time += Time.deltaTime;
                    if (_time > 0.2)

                    {
                        _time = 0;
                        Shoot();
                    }
                }
            }
            if (_magazine < 19)
            {
                if (Input.GetKeyDown(KeyCode.R))
                {
                    if (_bullets > _magazine)
                    {
                        _bullets -= (18 - _magazine);
                        _magazine += (18 - _magazine);
                    }
                    else if (_bullets == 18 || _bullets > 0)
                    {

                        _magazine += _bullets;
                        _bullets -= _bullets;
                        if (_magazine > 18 || _magazine == 19)
                        {
                            int Magazine = _magazine;
                            _magazine -= (Magazine - 18);
                            _bullets = (Magazine - 18);
                        }
                    }
                    if (_magazine == 0)
                    {
                        _reloadtime = -1;
                    }
                    Reload = true;
                    RoboContror.Reload();
                    _audioSource.PlayOneShot(_audioreload);
                }
            }
        }
        if (Reload)
        {
            _reloadtext.enabled = true;
            _reloadtime += Time.deltaTime;
            if (_reloadtime > 2)
            {
                _reloadtime = 0;
                Reload = false;
                _reloadtext.enabled = false;
            }
        }


        _bulletstext.text = "残り弾数:" +_bullets.ToString();
        _magazinetext.text = "マガジン:" +_magazine.ToString();
        Debug.DrawRay(transform.position,
           transform.forward * _raydis, Color.blue);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!Bullethet)
        {
            if (other.gameObject.tag == ("Enemy"))
            {
                Bullethet = true;
                Destroy(_bullet.gameObject);
            }
            else if (other.gameObject.tag == ("Field"))
            {
                Bullethet = true;
                Destroy(_bullet);
            }
        }
    }
}
