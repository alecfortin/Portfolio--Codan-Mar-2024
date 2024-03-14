using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    [SerializeField] 
    [Tooltip("Set the bullets's time to live.")]
    float ttl = 5f;

    private void Awake() 
    {
        //start the ttl timer on instantiation
        Destroy(gameObject, ttl);    
    }

    //when the bullet collides with another game object, destroy both
    private void OnCollisionEnter2D(Collision2D collision) 
    {
        Destroy(collision.gameObject);
        Destroy(gameObject);    
    }
}
