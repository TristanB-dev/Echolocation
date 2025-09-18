using System;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovementComponent : MonoBehaviour
{
    [SerializeField] private Vector2 movement;

    private PlayerInput _playerInput;
    private Rigidbody2D _rb;

    private void Awake()
    {
        _playerInput = new PlayerInput();
        _rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        _playerInput.Movement.WASD.Enable();
        
        _playerInput.Movement.WASD.performed += i => movement = i.ReadValue<Vector2>();
        _playerInput.Movement.WASD.canceled += i => movement = Vector2.zero;
    }
    
    private void OnDisable()
    {
        _playerInput.Movement.WASD.performed -= i => movement = i.ReadValue<Vector2>();
        _playerInput.Movement.WASD.canceled -= i => movement = Vector2.zero;
        
        _playerInput.Movement.WASD.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        if(movement == Vector2.zero) return;
        
        _rb.transform.Translate(movement * Time.deltaTime);
    }
}
