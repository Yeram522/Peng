using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSceneManager : MonoBehaviour
{
    public GameObject InfoTab;

    private AudioSource audio;
    public AudioClip buttonClickSound;
    // Start is called before the first frame update
    void Start()
    {
        this.audio = this.gameObject.AddComponent<AudioSource>();
        this.audio.clip = this.buttonClickSound;
        this.audio.loop = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        this.audio.Play();
        SceneManager.LoadScene("Main");
    }

    public void ShowHowTo()
    {
        InfoTab.SetActive(true);
        this.audio.Play();
    }

    public void CloseTab()
    {
        InfoTab.SetActive(false);
        this.audio.Play();
    }
}
