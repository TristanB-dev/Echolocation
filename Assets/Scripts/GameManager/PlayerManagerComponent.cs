using System;
using UnityEngine;

public class PlayerManagerComponent : MonoBehaviour
{
    [SerializeField] private PlayerMovementComponent playerMovementComponent;
    [SerializeField] private PlayerCollisionComponent playerCollisionComponent;
    
    private PlayerInput _playerInput;

    private void Awake()
    {
        _playerInput = new PlayerInput();
    }

    private void OnEnable()
    {
        _playerInput.Movement.WASD.Enable();
        
        _playerInput.Movement.WASD.performed += i => playerMovementComponent.SetPlayerDirection(i.ReadValue<Vector2>());
        _playerInput.Movement.WASD.canceled += i => playerMovementComponent.SetPlayerDirection(Vector2.zero);
    }
    
    private void OnDisable()
    {
        _playerInput.Movement.WASD.Disable();
        
        _playerInput.Movement.WASD.performed -= i => playerMovementComponent.SetPlayerDirection(i.ReadValue<Vector2>());
        _playerInput.Movement.WASD.canceled -= i => playerMovementComponent.SetPlayerDirection(Vector2.zero);
    }

    private void Update()
    {
        playerMovementComponent.MovePlayer(playerCollisionComponent.GetWallNormal());
    }
}
