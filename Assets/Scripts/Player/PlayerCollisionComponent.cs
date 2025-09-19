using System;
using UnityEngine;
[RequireComponent(typeof(Collider2D))]
public class PlayerCollisionComponent : MonoBehaviour
{
    private Collider2D _collider;
    private Vector2 _wallNormal;
    
    private void Awake()
    {
        _collider = GetComponent<Collider2D>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        // On collision with wall, prevent movement towards wall
        
        if (other.gameObject.layer == LayerMask.NameToLayer("Wall"))
               _wallNormal = other.contacts[0].normal;
    }
    
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Wall"))
            _wallNormal = Vector2.zero;
    }
    
    public Vector2 GetWallNormal()
        => _wallNormal;
}
