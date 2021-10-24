using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody _playerRigid;
    private float _horizontalInput;
    private float _verticalInput;
    private bool _isJumpPressed;
    private bool _isGrounded;
    [SerializeField] private float _jumpForce = 1;
    [SerializeField] private float _speed = 1;
    // Start is called before the first frame update
    void Start()
    {
        _playerRigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
        _horizontalInput = Input.GetAxis("Horizontal");
        _verticalInput = Input.GetAxis("Vertical");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _isJumpPressed = true;
        }
    }

    private void FixedUpdate()
    {
        Vector3 playerMovement = new Vector3(_horizontalInput, 0, _verticalInput);
    
        _playerRigid.AddForce(playerMovement*_speed, ForceMode.Acceleration);
        Ray ray = new Ray(transform.position, Vector3.down);

        if (Physics.Raycast(ray,transform.localScale.x / 2f + 0.01f))
        {
            _isGrounded = true;
        }
        else
        {
            _isGrounded = false;
        }
        if (_isJumpPressed && _isGrounded)
        {
         
                _playerRigid.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
                _isJumpPressed = false;
            
        }
    }

  /*  private void OnCollisionEnter(Collision collision)
    {
        _isGrounded = true;
    }
    private void OnCollisionExit(Collision collision)
    {
        _isGrounded = false;
    }*/
}
