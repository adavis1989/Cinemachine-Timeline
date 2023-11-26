using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ShipControls : MonoBehaviour
{
    [SerializeField] private float _rotSpeed;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _currentSpeed;
    [SerializeField] private float _pitchSpeed;
    [SerializeField] private float _yawSpeed;
    [SerializeField] private float _maxYawSpeed;
    [SerializeField] private float _minYawSpeed;
    private float _vertical;
    private float _horizontal;
    [SerializeField] private float _maxRotate;
    [SerializeField] private GameObject _shipModel;

    // Start is called before the first frame update
    void Start()
    {
        _currentSpeed = 1;
    }

    // Update is called once per frame
    void Update()
    {
        ShipMovement();
    }

    private void ShipMovement()
    {
        _vertical = Input.GetAxis("Vertical");
        _horizontal = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.T))
        {
            _currentSpeed++;
            if (_currentSpeed > 10)
            {
                _currentSpeed = 10;
            }
        }//increase speed

        if (Input.GetKeyDown(KeyCode.G))
        {
            _currentSpeed--;
            if (_currentSpeed < 1)
            {
                _currentSpeed = 1;
            }
        }//decrease speed

        if (Input.GetKey(KeyCode.C))
        {
            _yawSpeed++;
            if (_yawSpeed > _maxYawSpeed)
            {
                _yawSpeed = _maxYawSpeed;
            }


        }
        if (Input.GetKey(KeyCode.Z))
        {
            _yawSpeed--;
            if (_yawSpeed < _minYawSpeed)
            {
                _yawSpeed = _minYawSpeed;
            }
        }
        if (Input.GetKeyUp(KeyCode.C))
        {
            _yawSpeed = 0;
        }
        if (Input.GetKeyUp(KeyCode.Z))
        {
            _yawSpeed = 0;
        }

        Vector3 rotateH = new Vector3(0, _horizontal, 0);
        transform.Rotate(rotateH * _rotSpeed * Time.deltaTime);

        Vector3 rotateV = new Vector3(_vertical, 0, 0);
        transform.Rotate(rotateV * _pitchSpeed * Time.deltaTime);

        Vector3 rotateZ = new Vector3(0, 1, 0);
        transform.Rotate(rotateZ * _yawSpeed * Time.deltaTime);
        

        transform.Rotate(new Vector3(0, 0, -_horizontal * 0.2f), Space.Self);

        transform.position += transform.forward * _currentSpeed * Time.deltaTime;

        //Vector3 pitchUp = new Vector3(0, _vertical, 0);
        //transform.up = (pitchUp * _pitchSpeed * Time.deltaTime);
    }
}
