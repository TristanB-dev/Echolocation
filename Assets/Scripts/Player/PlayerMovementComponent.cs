using System;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovementComponent : MonoBehaviour
{
    [SerializeField] private Vector2 movement;
    [SerializeField] public float speed = 5;
    
    private Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    public void MovePlayer(Vector2 wallNormal)
    {
        if(movement == Vector2.zero) return;
        
        // On wall collision, prevent movement towards wall
        if (wallNormal != Vector2.zero)
        {
            var dot = Vector2.Dot(movement, -wallNormal);
            if (dot > 0)
                movement -= dot * -wallNormal;
        }
        
        _rb.transform.Translate(movement * speed * Time.deltaTime);
    }
    
    public void SetPlayerDirection(Vector2 newMovement)
        => movement = newMovement;
    
}
