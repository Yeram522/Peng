using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject stepPrefab_1;//발판
    public GameObject stepPrefab_2;//발판
    public GameObject stepPrefab_3;//발판
    private float interval;
    private GameObject spawned;

    // Start is called before the first frame update
    void Start()
    {
        interval = Random.Range(1.5f, 4.0f);
        StartCoroutine(sponStep());
    }

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
}
