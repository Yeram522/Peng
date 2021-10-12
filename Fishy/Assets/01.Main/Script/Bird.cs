using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    private GameObject destroctor;
    // Start is called before the first frame update
    void Start()
    {
        destroctor = transform.parent.Find("Destroctor").gameObject;  
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position,new Vector3(destroctor.transform.position.x,destroctor.transform.position.y,destroctor.transform.position.z), 0.1f);
    }

    private void OnTriggerEnter(Collider other)//�浹�ϴ� ����
    {
        
        if(other.tag == "Player")
        { 
            other.GetComponent<Player>().hp -=1;
            return;
        }
        //��ǥ������ �����ϸ� �Ҹ�.
        Debug.Log("���� ����!");
        Destroy(gameObject);
    }
}
