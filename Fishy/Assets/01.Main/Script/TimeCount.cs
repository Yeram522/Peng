using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeCount : MonoBehaviour
{
    public float LimitTime;
    public Text text_Timer;

    public AudioClip countSound;
    private AudioSource audio;

    void Start()
    {
        this.audio = this.gameObject.AddComponent<AudioSource>();
        this.audio.clip = this.countSound;
        this.audio.loop = false;
        this.audio.Play();
    }

    // Update is called once per frame
    void Update()
    {
        LimitTime -= Time.deltaTime;
        text_Timer.text = "" + Mathf.Round(LimitTime);      
        //카운트가 0초가 되면 retur 한다.
        if(LimitTime<=0)
        {
            GameManager.instance.isWaiting = false;
            Destroy(gameObject);
            return;
        }
    }
}
