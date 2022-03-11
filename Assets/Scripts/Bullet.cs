using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public int damage = 1;

    private void Start()
    {
        Destroy(gameObject, 10f);
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<IDamagable>(out IDamagable hit))
            hit.TakeDamage(damage);
        Destroy(gameObject);
    }
}
