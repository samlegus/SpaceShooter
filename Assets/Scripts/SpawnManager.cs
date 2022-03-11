using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject prefabToSpawn;
    [SerializeField] float spawnRate;
    [SerializeField] int enemyCount = 0;

    void Awake()
    {
        enemyCount = 0;
        DontDestroyOnLoad(this.gameObject);
        instance = this;
    }

    private void Start()
    {
        Spawn(prefabToSpawn); 
    }

    void Update()
    {
        
    }

    GameObject Spawn(GameObject obj)
    {
        foreach(Transform t in obj.transform)
        {
            if (t.CompareTag("Enemy"))
                enemyCount++;
        }
        return Instantiate(obj, obj.transform.position, obj.transform.rotation);
    }

    public void EnemyDestroyed()
    {
        enemyCount--;
    }

    //Singleton stuff
    static SpawnManager instance;
    public static SpawnManager Instance
    {
        get
        {
            if(instance == null)
            {
                instance = new GameObject().AddComponent<SpawnManager>();
            }
            return instance;
        }
    }
}
