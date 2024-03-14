using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Set the enemy's movement speed.")]
    float moveSpeed = 15f;

    [SerializeField]
    [Tooltip("Set the enemy's time to live.")]
    float ttl = 5f;
    
    private void Awake()
    {
        Destroy(gameObject, ttl);
    }

    void Update()
    {
        transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
    }
}
