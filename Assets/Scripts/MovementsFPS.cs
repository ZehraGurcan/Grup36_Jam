using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class MovementsFPS : MonoBehaviour
{
    public CharacterController _controller;
    private Vector3 _velocity;
    private bool _isGrounded;
    [SerializeField] private GameObject _ground;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _speed;
    [SerializeField] private float _walkspeed;
    [SerializeField] private float _runspeed;
    [SerializeField] private float _distance;
    [SerializeField] private float _gravity;
    [SerializeField] private float _sensitivity;
    [SerializeField] private LayerMask _mask;
    private float _limit;
    private Camera _cam;
    public float _minlimit;
    public float _maxlimit;
    public float playerHealth;
    public bool isAlive = true;
    
    void Start()
    {
        
        _cam = Camera.main;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        _speed = _walkspeed;
        
    }

    
    void Update()
    {

        playerHealth = Mathf.Clamp(playerHealth, 0.0f, 100.0f);
        //Karakter Hayatta mý?
        if(playerHealth <= 0)
        {
            isAlive = false;
        }

        //Karakter Hayattaysa Ya Da Hayatta Deðilse Yapýlacaklar
         if(isAlive == false)
        {
            //ölme animasyonu ve oyun biter
        }
        else
        {
            Move();
        }

        


    }

    public void Move()
    {
        //Karakter Yere Deðiyor mu?
        _isGrounded = Physics.CheckSphere(_ground.transform.position, _distance, (int)_mask);
        if (_isGrounded && _velocity.y < 0)
        {
            _velocity.y = -2;
        }

        //Hareket ve Yön
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        float look_x = Input.GetAxisRaw("Mouse X");
        float look_y = Input.GetAxisRaw("Mouse Y");
        _limit += look_y;
        _limit = Mathf.Clamp(value: _limit, _minlimit, _maxlimit);
        _cam.transform.localEulerAngles = new Vector3(x: -_limit, y: 0, z: 0);
        transform.Rotate(eulers: transform.up * (look_x * _sensitivity * Time.deltaTime));

        Vector3 direction = transform.right * x + transform.forward * y;
        _controller.Move(motion: direction * (_speed * Time.deltaTime));

        //Koþma
        if (Input.GetKey(KeyCode.LeftShift))
        {

            _speed = _runspeed;
        }
        else
        {
            _speed = _walkspeed;
        }

        //Zýplama
        if (Input.GetButtonDown("Jump") && _isGrounded)
        {
            _velocity.y = Mathf.Sqrt(f: _jumpForce * -2f * _gravity);

        }

        _velocity.y += _gravity * Time.deltaTime;
        _controller.Move(motion: _velocity * Time.deltaTime);
    }

    public void damageReceivedCrab()
    {
        playerHealth -= 10;
    }
    public void damageReceivedTHC()
    {
        playerHealth -= 10;
    }
    public void damageReceivedOrk()
    {
        playerHealth -= 10;
    }
    public void damageReceived()
    {
        playerHealth -= 10;
    }
}
