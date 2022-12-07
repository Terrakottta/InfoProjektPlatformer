using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private float _movementSpeed = 1f;
    [SerializeField] private float _jumpForce = 1f;
    private Rigidbody2D _rigidbody;
    private InputManager _inputManager;
    private bool _isGrounded = false;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    
    void Start()
    {
        _inputManager = InputManager.instance;
        
    }

    void Update()
    {
        getMovementInput();
        checkGrounded();
    }

    private void checkGrounded()
    {
        RaycastHit hit;
        if (Physics2D.Raycast(transform.position, Vector2.down, 1f))
        {
            _isGrounded = true;
        }
        else
        {
            _isGrounded = false;
        }
    }


    private void getMovementInput()
    {
        if (Input.GetKey(InputManager.instance.WalkRight))
        {
            transform.position = Vector2.MoveTowards(transform.position, (Vector2)transform.position + Vector2.right, _movementSpeed * Time.deltaTime);
        }
        if (Input.GetKey(InputManager.instance.WalkLeft))
        {
            transform.position = Vector2.MoveTowards(transform.position, (Vector2)transform.position + Vector2.left, _movementSpeed * Time.deltaTime);
        }
        if (Input.GetKeyDown(InputManager.instance.Jump) && _isGrounded)
        {
            _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        }
    }
}
