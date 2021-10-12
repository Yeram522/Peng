using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject stepPrefab_1;//����
    public GameObject stepPrefab_2;//����
    public GameObject stepPrefab_3;//����
    public GameObject enemy;//��
    private float interval;
    private GameObject spawned;
    private GameObject spawnedEnemy;
    //private Vector3 spawnBirdPos;
    private bool delaytrigger=false; 

    void Start()
    {
        
        //spawnBirdPos = new Vector3(transform.position.x,transform.position.y,transform.position.z);
        StartCoroutine(sponStep());      
        StartCoroutine(sponEnemy());
    }

    //�������� ����.
    private void OnTriggerEnter(Collider other)//�� ���� �浹�ϸ� �ڷ�ƾ�� �����.
    {
        if(other.tag != "Finish") return;
        GameManager.instance.StopCoroutine("dynamicSpawnLevel");
    }

    //������ �����Ѵ�.
    IEnumerator sponStep()
    {
        while(true)
        {
         interval = Random.Range(2.3f,2.8f);
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

    //������� ���� �����Ѵ�.
    IEnumerator sponEnemy()
    {         
        while(true)
        {
         float randtime = Random.Range(20.0f , 30.0f);
         if(delaytrigger == false) 
         {
            delaytrigger=true;
            yield return new WaitForSeconds(5.0f);
            continue;
         }
         GameObject spawnedEnemy = Instantiate(enemy , transform.position , enemy.transform.rotation);
         Vector3 originScale = spawnedEnemy.transform.localScale;
         spawnedEnemy.transform.SetParent(transform.parent);
         spawnedEnemy.transform.localScale = originScale;
         yield return new WaitForSeconds(randtime);
        }
        
    }
}
