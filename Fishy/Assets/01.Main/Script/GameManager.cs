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
    
    public GameObject SpawnerPrefab;//나중에 Asset에서 가져오기.

    private GameObject spawned;//Instanciate 정보를 담을 오브젝트

    //Aaudio
    private AudioSource audio;
    public AudioClip buttonClickSound;

    private AudioSource clearaudio;
    public AudioClip clearNoticeSound;

    public bool gameOver;


    void Awake()
    {
        instance = this;//GameManager 싱글톤

        Time.timeScale = 1;

        //제어할 게임 오브젝트 찾기.
        StartPoint = transform.Find("StartPoint").gameObject;
        EndPoint  = transform.Find("EndPoint").gameObject;
        Player = transform.Find("Penguin").gameObject;
        isWaiting = true;


        StartCoroutine("StartGame");
    }

    void Start()
    {
        //버튼 클릭 오디오.
        this.audio = this.gameObject.AddComponent<AudioSource>();
        this.audio.clip = this.buttonClickSound;
        this.audio.loop = false;

        //클리어 시 오디오
        this.clearaudio = this.gameObject.AddComponent<AudioSource>();
        this.clearaudio.clip = this.clearNoticeSound;
        this.clearaudio.loop = false;
    }

    void Update()
    {
        //플레이어 체력 업데이트
        
        if(!gameOver) return;
        //gameOver이 true이면
        StopCoroutine("StartGame");
    }

    IEnumerator StartGame()
    {
        currentState = GameState.inGame;

        StartCoroutine("dynamicSpawnLevel");

        //동적 레벨 생성
        yield return null;  
    }

    public void GameClear()
    {
        Debug.Log("게임클리어");
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
        //UI처리
        Debug.Log("게임오버");
        Time.timeScale = 0;
        UI.transform.Find("GameOver").gameObject.SetActive(true);
    }

    public void StopSpawnLevel()
    {
        StopCoroutine("dynamicSpawnLevel");
        
    }

    //동적으로 스포너 생성.
    IEnumerator dynamicSpawnLevel()
    {
        int count = 0;         
        while(true)
        {
            Vector3 pos = new Vector3(SpawnerPrefab.transform.position.x,SpawnerPrefab.transform.position.y,SpawnerPrefab.transform.position.z+2.0f*count);//매 텀마다 z값이 점점 축적 되면서 값이 증가한다.
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
            //scale 조절
            Vector3 originScale = spawned.transform.localScale;
            spawned.transform.SetParent(transform);
            spawned.transform.localScale = originScale;

            count ++;
                   
            yield return new WaitForSeconds(1.0f);
        }    
    }

    //-----------버튼 클릭 이벤트
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
