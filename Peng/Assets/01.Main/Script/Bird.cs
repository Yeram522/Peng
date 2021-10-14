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

    private void OnTriggerEnter(Collider other)//충돌하는 순간
    {
        
        if(other.tag == "Player")
        { 
            other.gameObject.GetComponent<Player>().hp -=1;
            this.audio.Play();
            Debug.Log("새충돌");
            
            return;
        }
        if(other.tag == "destroctor")
        {
          //목표지점에 도착하면 소멸.
          Debug.Log("새가 도착!");
          Destroy(gameObject);
        }
        
    }
}
