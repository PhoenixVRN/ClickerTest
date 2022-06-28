using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    [SerializeField] private FixedJoystick _joystickLeft;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _sensetiv;
    private float _vertical;
    private float _horizontal;
  

    void Update()
    {
        GetMobileInputLeft();
    }

    private void GetMobileInputLeft()
    {
        _vertical = _joystickLeft.Vertical;
        _horizontal = _joystickLeft.Horizontal;
        
        if (Input.GetKey(KeyCode.W) || _vertical > 0.2f)
            transform.position += transform.forward * _moveSpeed * Time.deltaTime;
        
        if (Input.GetKey(KeyCode.S) || _vertical < -0.2f)
            transform.position += -transform.forward * _moveSpeed * Time.deltaTime;
        
        if (Input.GetKey(KeyCode.D) || _horizontal > 0.2f)
            transform.position += transform.right * _moveSpeed * Time.deltaTime;
        
        if (Input.GetKey(KeyCode.A) || _horizontal < -0.2f)
            transform.position += -transform.right * _moveSpeed * Time.deltaTime;
    }
    
  
}
