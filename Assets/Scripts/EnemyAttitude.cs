using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttitude : MonoBehaviour
{
    [SerializeField] private float _speed = 1;
    private Rigidbody _physics;
    private bool _isPlayerInRange = false;
    private GameObject _player;
    // Start is called before the first frame update
    void Start()
    {
        _physics = GetComponent<Rigidbody>();
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _isPlayerInRange = true; 
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _isPlayerInRange = false;
        }
    }
    private void FixedUpdate()
    {
        if (_isPlayerInRange)
        {   
            Vector3 targetDirection = _player.transform.position - transform.position;
            _physics.AddForce(targetDirection * _speed * Time.fixedDeltaTime, ForceMode.VelocityChange);
           Vector3 Velocity =  _physics.velocity;
            Velocity.y = 0;
            _physics.velocity = Velocity;
        }
    }   
}
