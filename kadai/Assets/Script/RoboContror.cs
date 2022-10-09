using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RoboContror : MonoBehaviour
{
    [SerializeField] Transform _bone06l;
    [SerializeField] Transform _bone06r;
    [SerializeField] Transform _gan;
    [SerializeField] Animator _roboanim = default;
    [SerializeField] float _speed = 1;
    [SerializeField] float _gspeed = -1;
    [SerializeField] GameObject _camerapos;
    [SerializeField] GameObject Camera;
    bool _ground;
    public Rigidbody _rb;
    public float Dis = 2.75f;
    public Vector3 _velocity;
    public Transform _camerPos;
    public Transform _robopos;
    public int _rotate = 1;
    public float _zoomrotate = 0.5f;

    void Start()
    {
        _camerapos = GameObject.FindGameObjectWithTag("Camerpos");
        Camera = GameObject.Find("Camera");
        _rb = GetComponent<Rigidbody>();
        _roboanim = GetComponent<Animator>();
    }
    void Update()
    {
        float  Movex = Input.GetAxis("Horizontal") * _speed;
        float Movez = Input.GetAxis("Vertical") * _speed;
        _rb.AddForce(transform.right * Movex);
        _rb.AddForce(transform.forward * Movez);

        float RotationX = Input.GetAxis("Mouse X");
        float RotationY = Input.GetAxis("Mouse Y");
       
        if (!Input.GetMouseButton(1))
        {
            _camerPos.transform.Rotate(-RotationY * _rotate, 0,0);
            _robopos.transform.Rotate(0,RotationX * _rotate,0);
            _roboanim.SetBool("NotKamae", true);
            _roboanim.SetBool("Kamae", false);
        }

        if (Input.GetMouseButton(1))
        {
            RotaBone();
            _roboanim.SetBool("NotKamae", false);
            _roboanim.SetBool("Kamae",true);
            _camerPos.transform.Rotate(-RotationY * _rotate, 0, 0);
            _robopos.transform.Rotate(0, RotationX * _rotate, 0);
        }
        if (Input.GetKey(KeyCode.W))
        {
            if ( Input.GetKey(KeyCode.LeftShift))
            {
                _roboanim.SetBool("Dash", true);
                _roboanim.SetBool("NoDash", false);
            }
           else if (!Input.GetKey(KeyCode.LeftShift))
            {
                _roboanim.SetBool("Dash", false);
                _roboanim.SetBool("NoDash", true);
                _roboanim.SetBool("Walk", true);
                _roboanim.SetBool("NoWalk", false);
            }
        }
        if (!Input.GetKey(KeyCode.W))
        {
            _roboanim.SetBool("Walk", false);
            _roboanim.SetBool("NoWalk", true);
        } 
     

        
    }
    public void Reload()
    {
        _roboanim.SetBool("Reload",true);
    }
    void RotaBone()
    {
       _bone06r.rotation = Quaternion.Euler(180 + _camerPos.eulerAngles.x, _robopos.eulerAngles.y , -98 );
       _bone06l.rotation = Quaternion.Euler(180 + _camerPos.eulerAngles.x, _robopos.eulerAngles.y , 98 );
    }
    private void FixedUpdate()
    {
        RaycastHit hit;
        Debug.DrawRay(transform.position, Vector3.down * Dis, Color.red);

        //if (Physics.Raycast(transform.position, Vector3.down, out hit))
        //{
        //    _ground = true;
        //}

    }
   



}
