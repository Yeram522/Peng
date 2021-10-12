using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Step : MonoBehaviour
{
    public float speed=1;
    public GameObject Destroctor;
    public GameObject player;
    private GameObject Spawner;

    private bool iscoroutine;
    // Start is called before the first frame update
    void Start()
    {
        //목표지점 오브젝트 Find
        Spawner = transform.parent.Find("Constructor").gameObject;
        player = GameManager.instance.Player;  
        Destroctor = transform.parent.Find("Destroctor").gameObject;   
    }

    // Update is called once per frame
    void Update()
    {
       // 목표 지점으로 향하여 간다.
       transform.position = Vector3.MoveTowards(transform.position, Destroctor.transform.position, 0.1f);
    }

    private void OnTriggerEnter(Collider other)//충돌하는 순간
    {
        //목표지점에 도착하면 소멸.
        if(other.tag != "destroctor") return;
        Destroy(gameObject);
    }

    //발판에 있을때 자동으로 이동.
    // IEnumerator isOnStep(Collision collision)
    // {
    //    iscoroutine = true;
    //    //팽귄이 빙하에 붙어있을때. 즉 isJumping==false
    //    //if(collision.gameObject.GetComponent<Player>()==null) yield return null;
    //    while(!player.GetComponent<Player>().isJumping)
    //    {
    //      collision.transform.position = Vector3.MoveTowards(collision.transform.position, Destroctor.transform.position,  0.1f);
    //      yield return null;
    //    }

    //    yield return null;
    // }

    private void OnCollisionEnter(Collision collision)//충돌하는 순간
    {
        if(collision.transform.CompareTag("Player"))
        {
            collision.transform.SetParent(transform);
            Debug.Log("빙하 팰귄 충돌");
        }     
    }

    

    private void OnCollisionExit(Collision collision)//충돌 벗어나면
    {
        if(collision.transform.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
        }
    }
}
