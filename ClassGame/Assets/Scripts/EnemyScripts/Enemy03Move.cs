using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy03Move : MonoBehaviour
{
    public float moveSpeed;
    private Rigidbody rigidbody;
    private Transform transform;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        transform = GetComponent<Transform>();
    }

    void FixedUpdate()
    {
        Vector2 Vel = rigidbody.velocity;
        Vel.x = -moveSpeed;
        rigidbody.velocity = Vel;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
