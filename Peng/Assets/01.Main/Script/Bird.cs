using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public AudioClip birdSound;
    private AudioSource audio;
    private GameObject destroctor;
    // Start is called before the first frame update
    void Start()
    {
        destroctor = transform.parent.Find("Destroctor").gameObject;  

        this.audio = this.gameObject.AddComponent<AudioSource>();
        this.audio.clip = this.birdSound;
        this.audio.loop = false;
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
            other.gameObject.GetComponent<Player>().hp -=1;
            this.audio.Play();
            Debug.Log("���浹");
            
            return;
        }
        if(other.tag == "destroctor")
        {
          //��ǥ������ �����ϸ� �Ҹ�.
          Debug.Log("���� ����!");
          Destroy(gameObject);
        }
        
    }
}
