using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float length, startPos;
    [SerializeField] float parallaxEffect;


    void Start()
    {
        startPos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
        InvokeRepeating("MoveBackgrounds", 0f, Time.fixedDeltaTime);
    }

    private void MoveBackgrounds()
    {
        // Scroll the backgrounds
        transform.Translate(-parallaxEffect * Time.fixedDeltaTime, 0.0f, 0.0f);
        
        // Bounce the backgrounds back
        if (transform.position.x <= -length)
        {
            transform.position = new Vector3(startPos, 0f, 0f);
        }
    }
}
