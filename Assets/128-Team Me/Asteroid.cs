using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Rigidbody2D))]
public class Asteroid : MonoBehaviour
{
    private Rigidbody2D _rb;
    
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        transform.Rotate(new Vector3(0, 0, Random.Range(0, 360)));
    }

    private void Update()
    {
        _rb.AddForce(Vector2.left);
    }
}
