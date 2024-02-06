using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce;
    public float gravity = 9.8f;
    public float speed;

    private Vector3 _moveVector;
    private float _fallVelocity = 0f;
    private CharacterController character;

    void Start()
    {
        _moveVector = Vector3.forward;
        character = GetComponent<CharacterController>();
    }

    void FixedUpdate()
    {

        _fallVelocity += gravity * Time.fixedDeltaTime;
        character.Move(Vector3.down * _fallVelocity * Time.fixedDeltaTime);
        character.Move(_moveVector * Time.fixedDeltaTime * speed);
    }

    private void Update()
    {
        // MOVEMENT
        _moveVector = Vector3.zero;

        if (Input.GetKey(KeyCode.W)) 
        {
            _moveVector += transform.forward;
        }
        if (Input.GetKey(KeyCode.A))
        {
            _moveVector -= transform.right;
        }
        if (Input.GetKey(KeyCode.S))
        {
            _moveVector -= transform.forward;
        }
        if (Input.GetKey(KeyCode.D))
        {
            _moveVector += transform.right;
        }

        // JUMP
        if (Input.GetKeyDown(KeyCode.Space) && character.isGrounded)
        {
           _fallVelocity = -jumpForce;
        }

        // OTHER
        if (character.isGrounded)
        {
            _fallVelocity = 0;
        }
    }
}
