using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private float _unlockSpeed = 2;
    [SerializeField] private float _unlockTime = 3;
    [SerializeField] private bool _isUnlocked = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_isUnlocked)
        {
            _unlockTime-= Time.deltaTime;
            transform.Translate(Vector3.down * Time.deltaTime * _unlockSpeed);
            if(_unlockTime <= 0)
            {
                gameObject.SetActive(false);
            }
        }
    }


    public void UnlockDoor()
    {
        _isUnlocked = true;
    }
}
