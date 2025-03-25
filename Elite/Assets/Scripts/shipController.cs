using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shipController : MonoBehaviour
{
    [SerializeField] private float _force = 1000f;
    [SerializeField] private float _rotationSpeed = 10f;
    [SerializeField] private float _maxSpeed = 100f;

    private Rigidbody _rb;

    private float _verticalInput;
    private float _horizontalInput;
    private float _rollInput;
    private float _pitchInput;

    private bool _cursorVisible = false;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        Cursor.visible = _cursorVisible;
        Cursor.lockState = CursorLockMode.Locked;
    }

    
    void Update()
    {
        _verticalInput = Input.GetAxis("Vertical");
        _horizontalInput = Input.GetAxis("Horizontal");
        _rollInput += Input.GetAxis("Mouse X");
        _pitchInput += Input.GetAxis("Mouse Y");

        if (_cursorVisible )
        {
            Cursor.visible = _cursorVisible;
            Cursor.lockState= CursorLockMode.Locked;
        }
        else
        {
            Cursor.visible = _cursorVisible;
            Cursor.lockState = CursorLockMode.Locked;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _cursorVisible = !_cursorVisible;
        }
    }

    private void FixedUpdate()
    {
        _rb.AddTorque(transform.up * _horizontalInput * _rotationSpeed * 25 * Time.deltaTime);
        _rb.AddTorque(transform.forward * -_rollInput * _rotationSpeed * Time.deltaTime);
        _rb.AddTorque(transform.right * -_pitchInput * _rotationSpeed * Time.deltaTime);

        if(_verticalInput > 0)
        {
            _rb.AddForce(transform.forward * _force * _verticalInput);
        }
        if (_verticalInput < 0)
        {
            _rb.AddForce(transform.forward * _force * 0.3f * _verticalInput);
        }
    }
}
