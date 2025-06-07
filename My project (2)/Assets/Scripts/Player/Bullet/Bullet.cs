using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public float damage = 10f;
    public float lifeTime = 2f;

    [SerializeField] private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;

        rb.linearVelocity = Vector3.up * speed;

        Destroy(gameObject, lifeTime);
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<IDamage>(out IDamage target))
        {
            target.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}