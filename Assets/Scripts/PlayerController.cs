using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float xBound = 10f;
    public float zBound = 10f;
    Gun gun;
    
    void Start()
    {
        gun = GetComponentInChildren<Gun>();
    }

    void Update()
    {
        Move();
        Constrain();
        if (Input.GetButtonDown("Fire1"))
            gun.TryShoot();
    }

    void Move()
    {
        var h = Input.GetAxisRaw("Horizontal");
        var v = Input.GetAxisRaw("Vertical");
        Vector3 move = new Vector3(h, 0f, v) * Time.deltaTime;
        transform.Translate(move * speed);
    }

    void Constrain()
    {
        if (transform.position.x > xBound)
            transform.position = new Vector3(xBound, transform.position.y, transform.position.z);
        if (transform.position.x < -xBound)
            transform.position = new Vector3(-xBound, transform.position.y, transform.position.z);
        if (transform.position.z > zBound)
            transform.position = new Vector3(transform.position.x, transform.position.y, zBound);
        if (transform.position.z < -zBound)
            transform.position = new Vector3(transform.position.x, transform.position.y, -zBound);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(Vector3.zero, new Vector3(xBound * 2f, 0f, zBound * 2f));
    }
}
