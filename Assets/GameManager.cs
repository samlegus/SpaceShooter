using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //public static GameManager Instance { get; private set; }

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        instance = this;
    }

    void Update()
    {
        
    }

    //Singleton stuff
    static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameObject().AddComponent<GameManager>();
            }
            return instance;
        }
    }
}
