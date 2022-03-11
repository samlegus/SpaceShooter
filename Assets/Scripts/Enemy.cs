using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Gun gun;
    [SerializeField] float speed = 2f;
    [SerializeField] float sightDistance = 10f;
    [SerializeField] bool playerDetected = false;
    [SerializeField] LayerMask mask;
    RaycastHit hit;

    void Start()
    {
        gun = GetComponentInChildren<Gun>();
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
    }

    void Update()
    {
        playerDetected = Physics.Raycast(transform.position, transform.forward, out hit, sightDistance, mask);
        if(playerDetected)
            gun.TryShoot();
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position, transform.forward * sightDistance);
        if (playerDetected)
            Gizmos.DrawWireSphere(hit.point, .25f);
    }
}
