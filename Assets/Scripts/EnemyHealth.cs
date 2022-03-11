using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour, IDamagable
{
    [SerializeField] int hp = 4;

    void Update()
    {
        if (hp <= 0)
            Destroy(gameObject);
    }
    
    public void TakeDamage(int damage)
    {
        hp -= damage;
    }

    private void OnDestroy()
    {
        SpawnManager.Instance.EnemyDestroyed();
    }
}
