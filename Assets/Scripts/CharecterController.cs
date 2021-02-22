using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharecterController : MonoBehaviour
{

    private Rigidbody _rigidbody;

    private float inputHorizontal;
    private float inputVertical;

    public float moveSpeed;
    public float rotationSpeed;
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
       
            MoveJoystick(); 
            LookJoystick();
        }

    private void MoveJoystick()
    {
        inputHorizontal = SimpleInput.GetAxis("Horizontal");
        inputVertical = SimpleInput.GetAxis("Vertical");

        Vector3 mov = new Vector3(inputHorizontal * moveSpeed, 0, inputVertical * moveSpeed);
        _rigidbody.MovePosition(transform.position + mov * Time.deltaTime);
    }
    
    private void LookJoystick()
    {
        Vector3 direction = new Vector3(inputHorizontal, 0, inputVertical).normalized;
        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation,  rotationSpeed * Time.deltaTime);
    }
    
    
    
}