using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Speed = 5f;

    public float jumpForce = 10;

    public float gravity = 9.8f;

    Vector3 _move;

    CharacterController _controller;

    private float _fallVelocity = 0;

    void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        _move = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            _move += transform.forward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            _move -= transform.forward;
        }
        if (Input.GetKey(KeyCode.A))
        {
            _move -= transform.right;
        }
        if (Input.GetKey(KeyCode.D))
        {
            _move += transform.right;
        }




        // OTHER


        if (Input.GetKey(KeyCode.Space) && _controller.isGrounded)
        {
            _fallVelocity = -jumpForce;
        }

    }
    private void FixedUpdate()
    {
        _controller.Move(_move * Speed * Time.deltaTime);
        _fallVelocity += gravity * Time.fixedDeltaTime;
        _controller.Move(Vector3.down * _fallVelocity * Time.fixedDeltaTime);
        if (_controller.isGrounded)
        {
            _fallVelocity = 0;
        }
    }
}