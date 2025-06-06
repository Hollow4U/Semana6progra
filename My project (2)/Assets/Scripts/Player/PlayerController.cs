using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] public float moveSpeed = 5f;
    [SerializeField] private Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate() 
    {
        Move();
    }

    private void Move()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        Vector3 velocity = new Vector3(inputX * moveSpeed, rb.linearVelocity.y, 0f);
        rb.linearVelocity = velocity;
    }
}