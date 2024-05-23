using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TPSControllerJac : MonoBehaviour
{
    private CharacterController _controller;
    private Transform _camera;
    private float _horizontal;
    private float _vertical;
    [SerializeField] private float _playerSpeed = 5;
    [SerializeField] private float _jumpHeight = 1;

    [SerializeField] private GameObject HeadPosition;
    [SerializeField] private bool _crouch = false;
    [SerializeField] private bool _canStand;

    private float _gravity = -9.81f;
    private Vector3 _playerGravity;

    private float turnSmoothVelocity;
    [SerializeField] float turnSmoothTime = 0.1f;

    [SerializeField] private Transform _sensorPosition;
    [SerializeField] private float _sensorRadius = 0.2f;
    [SerializeField] private LayerMask _groundLayer;
    private bool _isGrounded;
    private Animator _animator;

    // Escalada
    public float velocidadEscalada = 5f;
    public float distanciaMaxima = 2f;
    public Transform puntoInicioEscalada;

    private bool escalando = false;
    private Vector3 puntoFinalEscalada;

    // Disparo
    /*[SerializeField] Transform gunPosition;
    [SerializeField] int ammo;
    public GameObject bullet;*/

    void Awake()
    {
        _controller = GetComponent<CharacterController>();
        _camera = Camera.main.transform;
        _animator = GetComponentInChildren<Animator>();
        LoadGame();
    }

    void Update()
    {
        _horizontal = Input.GetAxisRaw("Horizontal");
        _vertical = Input.GetAxisRaw("Vertical");
        Movement();
        Jump();
        Crouch();
    }

    void Movement()
    {
        Vector3 direction = new Vector3(_horizontal, 0, _vertical);
        _animator.SetFloat("VelX", 0);
        _animator.SetFloat("VelZ", direction.magnitude);

        if (direction != Vector3.zero)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + _camera.eulerAngles.y;
            float smoothAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0, smoothAngle, 0);
            Vector3 moveDirection = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;
            _controller.Move(moveDirection.normalized * _playerSpeed * Time.deltaTime);
        }
    }

    void Crouch()
    {
        if (Physics.Raycast(HeadPosition.transform.position, Vector3.up, 0.5f))
        {
            _canStand = false;
            Debug.DrawRay(HeadPosition.transform.position, Vector3.up, Color.red);
        }
        else
        {
            _canStand = true;
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            if (_crouch == true && _canStand == true)
            {
                _crouch = false;
                _animator.SetBool("IsCrouching", false);
                _jumpHeight = 1;
                _controller.height = 2f;
                _playerSpeed = 5;
                _controller.center = new Vector3(0f, 0f, 0f);
            }
            else
            {
                _crouch = true;
                _animator.SetBool("IsCrouching", true);
                _jumpHeight = 0;
                _controller.height = 1.5f;
                _playerSpeed = 2;
                _controller.center = new Vector3(0f, -0.2f, 0f);
            }
        }
    }

    void Jump()
    {
        _isGrounded = Physics.CheckSphere(_sensorPosition.position, _sensorRadius, _groundLayer);
        _animator.SetBool("IsJumping", !_isGrounded);

        if (_isGrounded && _playerGravity.y < 0)
        {
            _playerGravity.y = -2;
        }

        if (_isGrounded && Input.GetButtonDown("Jump"))
        {
            _playerGravity.y = Mathf.Sqrt(_jumpHeight * -2 * _gravity);
        }

        _playerGravity.y += _gravity * Time.deltaTime;
        _controller.Move(_playerGravity * Time.deltaTime);
    }

    public void LoadGame()
    {
        PlayerData data = SaveSystem.LoadGame();
        if (data != null)
        {
            Vector3 position = new Vector3(data.playerPositionX, data.playerPositionY, data.playerPositionZ);
            transform.position = position;

            if (SceneManager.GetActiveScene().buildIndex != data.currentScene)
            {
                SceneManager.LoadScene(data.currentScene);
            }
        }
    }
}