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

    public bool isReverse;

    void Start()
    {
        StartCoroutine(sponStep());      
        StartCoroutine(sponEnemy());
    }

    //동적생성 제어.
    private void OnTriggerEnter(Collider other)//맵 끝과 충돌하면 코루틴을 멈춘다.
    {
        if(other.tag != "Finish") return;
        GameManager.instance.StopCoroutine("dynamicSpawnLevel");
    }

    //발판을 스폰한다.
    IEnumerator sponStep()
    {
        while(true)
        {
         interval = Random.Range(1.5f,2.0f);
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
         float randtime = Random.Range(20.0f , 30.0f);
         int spawndeside = Random.Range(0 , 2);
         if(spawndeside == 1) 
         {
            if(isReverse) spawnedEnemy = Instantiate(enemy , transform.position , Quaternion.Euler(new Vector3(0,90.0f,0)));
            else spawnedEnemy = Instantiate(enemy , transform.position , Quaternion.Euler(new Vector3(0,-90.0f,0)));

            Vector3 originScale = spawnedEnemy.transform.localScale;
            spawnedEnemy.transform.SetParent(transform.parent);
            spawnedEnemy.transform.localScale = originScale;
         }
         
         yield return new WaitForSeconds(randtime);
        }
        
    }
}
