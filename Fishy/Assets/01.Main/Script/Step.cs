using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Step : MonoBehaviour
{
    public float speed=1;
    public bool isobstacle;//밟아도 영구적인지 밟으면 가라 앉는 지.
    public GameObject destroctor;

    private bool iscoroutine;
    // Start is called before the first frame update
    void Start()
    {
        //목표지점 오브젝트 Find
        destroctor = transform.parent.Find("Destroctor").gameObject;     
    }

    // Update is called once per frame
    void Update()
    {
       // 목표 지점으로 향하여 간다.
       transform.position = Vector3.MoveTowards(transform.position, destroctor.transform.position, 0.1f);
    }

    private void OnTriggerEnter(Collider other)//충돌하는 순간
    {
        //목표지점에 도착하면 소멸.
        if(other.tag != "destroctor") return;
        Destroy(gameObject);
    }

    //발판에 있을때 자동으로 이동.
    IEnumerator isOnStep(Collision collision)
    {
       iscoroutine = true;
       //팽귄이 빙하에 붙어있을때. 즉 isJumping==false
       while(!collision.gameObject.GetComponent<Player>().isJumping)
       {
         collision.transform.position = Vector3.MoveTowards(collision.transform.position,destroctor.transform.position, 0.1f);
         yield return null;
       }

       yield return null;
    }

    private void OnCollisionEnter(Collision collision)//충돌하는 순간
    {
        if(!collision.collider.CompareTag("Player")) return;
        Debug.Log("빙하 팰귄 충돌");
        collision.gameObject.GetComponent<Player>().isJumping = false;
        StartCoroutine(isOnStep(collision));       
    }

    private void OnCollisionExit(Collision collision)//충돌 벗어나면
    {
        if(iscoroutine==false) return;
        StopCoroutine("isOnStep");
    }
}
