using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState
{
    inGame,
    gameOver,
    gameClear,
}

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameState currentState = GameState.inGame;
    public bool isWaiting;

    public GameObject StartPoint;
    public GameObject EndPoint;
    public GameObject Player;
    public GameObject UI;
    
    public GameObject SpawnerPrefab;//���߿� Asset���� ��������.

    private GameObject spawned;//Instanciate ������ ���� ������Ʈ

    //Aaudio
    private AudioSource audio;
    public AudioClip buttonClickSound;

    private AudioSource clearaudio;
    public AudioClip clearNoticeSound;

    public bool gameOver;


    void Awake()
    {
        instance = this;//GameManager �̱���

        Time.timeScale = 1;

        //������ ���� ������Ʈ ã��.
        StartPoint = transform.Find("StartPoint").gameObject;
        EndPoint  = transform.Find("EndPoint").gameObject;
        Player = transform.Find("Penguin").gameObject;
        isWaiting = true;


        StartCoroutine("StartGame");
    }

    void Start()
    {
        //��ư Ŭ�� �����.
        this.audio = this.gameObject.AddComponent<AudioSource>();
        this.audio.clip = this.buttonClickSound;
        this.audio.loop = false;

        //Ŭ���� �� �����
        this.clearaudio = this.gameObject.AddComponent<AudioSource>();
        this.clearaudio.clip = this.clearNoticeSound;
        this.clearaudio.loop = false;
    }

    void Update()
    {
        //�÷��̾� ü�� ������Ʈ
        
        if(!gameOver) return;
        //gameOver�� true�̸�
        StopCoroutine("StartGame");
    }

    IEnumerator StartGame()
    {
        currentState = GameState.inGame;

        StartCoroutine("dynamicSpawnLevel");

        //���� ���� ����
        yield return null;  
    }

    public void GameClear()
    {
        Debug.Log("����Ŭ����");
        UI.transform.Find("GameClear").gameObject.SetActive(true);
        this.clearaudio.Play();
        currentState = GameState.gameClear;
        Time.timeScale = 0;
    }

    public void GameOver()
    {
        if(currentState == GameState.gameClear) return;
        currentState = GameState.gameOver;
        StopCoroutine("StartGame");
        //UIó��
        Debug.Log("���ӿ���");
        Time.timeScale = 0;
        UI.transform.Find("GameOver").gameObject.SetActive(true);
    }

    public void StopSpawnLevel()
    {
        StopCoroutine("dynamicSpawnLevel");
        
    }

    //�������� ������ ����.
    IEnumerator dynamicSpawnLevel()
    {
        int count = 0;         
        while(true)
        {
            Vector3 pos = new Vector3(SpawnerPrefab.transform.position.x,SpawnerPrefab.transform.position.y,SpawnerPrefab.transform.position.z+2.0f*count);//�� �Ҹ��� z���� ���� ���� �Ǹ鼭 ���� �����Ѵ�.
            int rand = Random.Range(0, 2);
            if(rand==0)
            {
                spawned = Instantiate(SpawnerPrefab , pos , Quaternion.Euler(new Vector3(0,180.0f,0))).gameObject;
                spawned.transform.Find("Constructor").GetComponent<Spawner>().isReverse = true;
            }
            else if(rand==1)
            {
                spawned = Instantiate(SpawnerPrefab , pos , Quaternion.Euler(0,0,0)).gameObject;
                spawned.transform.Find("Constructor").GetComponent<Spawner>().isReverse = false;
            }
            //scale ����
            Vector3 originScale = spawned.transform.localScale;
            spawned.transform.SetParent(transform);
            spawned.transform.localScale = originScale;

            count ++;
                   
            yield return new WaitForSeconds(1.0f);
        }    
    }

    //-----------��ư Ŭ�� �̺�Ʈ
    public void retrygame()
    {
        SceneManager.LoadScene("main");
        this.audio.Play();
    }

    public void gotomain()
    {
        SceneManager.LoadScene("Tutorial");
        this.audio.Play();
    }
  
}
