using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Step : MonoBehaviour
{
    public float speed=1;
    public GameObject Destroctor;
    private GameObject Spawner;

    private bool iscoroutine;
    // Start is called before the first frame update
    void Start()
    {
        //��ǥ���� ������Ʈ Find
        Spawner = transform.parent.Find("Constructor").gameObject;
        Destroctor = transform.parent.Find("Destroctor").gameObject;   
    }

    // Update is called once per frame
    void Update()
    {
       // ��ǥ �������� ���Ͽ� ����.
       transform.position = Vector3.MoveTowards(transform.position, Destroctor.transform.position, 0.1f);
    }

    private void OnTriggerEnter(Collider other)//�浹�ϴ� ����
    {   
        //��ǥ������ �����ϸ� �Ҹ�.
        // if(other.transform.CompareTag("Player"))
        // {
        //     other.transform.SetParent(transform);
        //     Debug.Log("���� �ӱ� �浹");
        // }

        if(other.tag != "destroctor") return;
        Destroy(gameObject);
         
    }

    private void OnTriggerExit(Collider other)//�浹 �����
    {
        if(other.transform.CompareTag("Player"))
        {
            other.transform.SetParent(null);
        }
    }

    private void OnCollisionEnter(Collision collision)//�浹�ϴ� ����
    {
        if(collision.transform.CompareTag("Player"))
        {
            collision.transform.SetParent(this.transform);
            Debug.Log("���� �ӱ� �浹");
        }     
    } 

    private void OnCollisionExit(Collision collision)//�浹 �����
    {
        if(collision.transform.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
        }
    }
}
