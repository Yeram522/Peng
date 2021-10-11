using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Step : MonoBehaviour
{
    public float speed=1;
    public bool isobstacle;//��Ƶ� ���������� ������ ���� �ɴ� ��.
    public GameObject destroctor;

    private bool iscoroutine;
    // Start is called before the first frame update
    void Start()
    {
        //��ǥ���� ������Ʈ Find
        destroctor = transform.parent.Find("Destroctor").gameObject;     
    }

    // Update is called once per frame
    void Update()
    {
       // ��ǥ �������� ���Ͽ� ����.
       transform.position = Vector3.MoveTowards(transform.position, destroctor.transform.position, 0.1f);
    }

    private void OnTriggerEnter(Collider other)//�浹�ϴ� ����
    {
        //��ǥ������ �����ϸ� �Ҹ�.
        if(other.tag != "destroctor") return;
        Destroy(gameObject);
    }

    //���ǿ� ������ �ڵ����� �̵�.
    IEnumerator isOnStep(Collision collision)
    {
       iscoroutine = true;
       //�ر��� ���Ͽ� �پ�������. �� isJumping==false
       while(!collision.gameObject.GetComponent<Player>().isJumping)
       {
         collision.transform.position = Vector3.MoveTowards(collision.transform.position,destroctor.transform.position, 0.1f);
         yield return null;
       }

       yield return null;
    }

    private void OnCollisionEnter(Collision collision)//�浹�ϴ� ����
    {
        if(!collision.collider.CompareTag("Player")) return;
        Debug.Log("���� �ӱ� �浹");
        collision.gameObject.GetComponent<Player>().isJumping = false;
        StartCoroutine(isOnStep(collision));       
    }

    private void OnCollisionExit(Collision collision)//�浹 �����
    {
        if(iscoroutine==false) return;
        StopCoroutine("isOnStep");
    }
}
