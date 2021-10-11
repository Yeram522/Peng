using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject stepPrefab_1;//발판
    public GameObject stepPrefab_2;//발판
    public GameObject stepPrefab_3;//발판
    public GameObject enemy;//새
    private float interval;
    private GameObject spawned;
    private GameObject spawnedEnemy;
    private Vector3 spawnBirdPos;
    private bool delaytrigger=false; 
    public GameManager Manager;

    void Start()
    {
        Manager = transform.parent.Find("GameManager").GetComponent<GameManager>();   
        interval = Random.Range(2.5f, 4.0f);
        spawnBirdPos = new Vector3(transform.position.x,transform.position.y+0.2f,transform.position.z);
        StartCoroutine(sponStep());      
        StartCoroutine(sponEnemy());
    }

    //발판을 스폰한다.
    IEnumerator sponStep()
    {
        while(true)
        {
         int rand = Random.Range(1, 4);
         switch(rand)
         {
            case 1:
            spawned = Instantiate(stepPrefab_1, transform.position, stepPrefab_1.transform.rotation);
            break;
            case 2:
            spawned = Instantiate(stepPrefab_2, transform.position, stepPrefab_2.transform.rotation);
            break;
            case 3:
            spawned = Instantiate(stepPrefab_3, transform.position, stepPrefab_3.transform.rotation);
            break;
         }
         Vector3 originScale = spawned.transform.localScale;
         spawned.transform.SetParent(transform.parent);
         spawned.transform.localScale = originScale;
         yield return new WaitForSeconds(interval);
        }
    }

    //날라오는 적을 스폰한다.
    IEnumerator sponEnemy()
    {         
        while(true)
        {
         float randtime = Random.Range(5.0f , 10.0f);
         if(delaytrigger == false) 
         {
            delaytrigger=true;
            yield return new WaitForSeconds(4.0f);
            continue;
         }
         GameObject spawnedEnemy = Instantiate(enemy , spawnBirdPos , enemy.transform.rotation);
         Vector3 originScale = spawnedEnemy.transform.localScale;
         spawnedEnemy.transform.SetParent(transform.parent);
         spawnedEnemy.transform.localScale = originScale;
         yield return new WaitForSeconds(randtime);
        }
        
    }
}
