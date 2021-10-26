using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBehaviour : MonoBehaviour
{

    [SerializeField] private Transform _head;
    [SerializeField] private Transform _tip;
    [SerializeField] private float _shootingCooldown = 3f;
    [SerializeField] private float _laserPower = 100f;
    [SerializeField] private float _offset = 1f;

    private bool _isPlayerInRange = false;
    private GameObject _player;
    private float _timeLeftToShoot =0;
    private LineRenderer _Laser;


    // Start is called before the first frame update
    void Start()
    {
        _Laser = GetComponent<LineRenderer>();
        _Laser.sharedMaterial.color = Color.green;
        _Laser.enabled = false;
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (_isPlayerInRange)
        {
            _head.transform.LookAt(_player.transform);
            _Laser.SetPosition(0, _tip.transform.position);
            _Laser.SetPosition(1, _player.transform.position);
            _timeLeftToShoot -= Time.deltaTime;
            if(_timeLeftToShoot <= _shootingCooldown / 2)
            {
                _Laser.sharedMaterial.color = Color.red;
            }
            if(_timeLeftToShoot <= 0)
            {
                Vector3 DirectionToPush = _player.transform.position - _tip.transform.position;
                _player.GetComponent<Rigidbody>().AddForce(DirectionToPush * _laserPower, ForceMode.Impulse);
                _timeLeftToShoot = _shootingCooldown;
                _Laser.sharedMaterial.color = Color.green;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _isPlayerInRange = true;
            _Laser.enabled = true;
            _timeLeftToShoot = _shootingCooldown;

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _isPlayerInRange = false;
            _Laser.enabled = false;
            _timeLeftToShoot = _shootingCooldown;
            _Laser.sharedMaterial.color = Color.green;
        }
    }
}
