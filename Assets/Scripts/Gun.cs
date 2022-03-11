using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject projectilePrefab;
    [SerializeField] float gunTimer = 0f;
    [SerializeField] float rateOfFire = .25f;
    [SerializeField] bool canShoot = true;

    public void Update()
    {
        gunTimer += Time.deltaTime;
    }
    public void TryShoot()
    {
        if (gunTimer >= rateOfFire && canShoot)
        {
            canShoot = false;
            Instantiate(projectilePrefab, transform.position, transform.rotation);
            gunTimer = 0f;
        }
        else
        {
            canShoot = true;
        }
    }
}
