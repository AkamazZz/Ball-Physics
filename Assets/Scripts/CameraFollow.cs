using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform _cameraTarget;
    private Vector3 _cameraVelocity = Vector3.zero;
    [SerializeField] private Vector3 _offset;
    [SerializeField] private float _smoothTime = 0.3f;
    // Start is called before the first frame update    
    void Start()
    {
        // _cameraTarget = gameObject.GetComponent<Player>(); How i think this should be done
        _cameraTarget = GameObject.FindGameObjectWithTag("Player").transform;
        _offset = transform.position - _cameraTarget.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void LateUpdate()
    {
        Vector3 targetPosition = _cameraTarget.position + _offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref _cameraVelocity, _smoothTime);
        transform.LookAt(_cameraTarget);
    }
}
