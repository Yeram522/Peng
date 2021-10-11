using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject StartPoint;
    public GameObject EndPoint;

    public GameObject Player;
    
    public GameObject SpawnerPrefab;

    private Transform SpawnPosition; //Sapwner들이 동적으로 생성될 position

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    IEnumerator dynamicSpawnLevel()
    {         
        while(true)
        {
         
         yield return new WaitForSeconds(5.0f);
        }
        
    }
}
