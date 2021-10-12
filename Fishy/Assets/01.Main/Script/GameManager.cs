using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    inGame,
    gameOver
}

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameState currentState = GameState.inGame;

    public GameObject StartPoint;
    public GameObject EndPoint;
    public GameObject Player;
    public GameObject UI;
    
    public GameObject SpawnerPrefab;//나중에 Asset에서 가져오기.

   // public GameObject SpawnPosition; //Sapwner들이 동적으로 생성될 position

    private GameObject spawned;//Instanciate 정보를 담을 오브젝트

    public bool gameOver;


    void Awake()
    {
        instance = this;//GameManager 싱글톤

        //제어할 게임 오브젝트 찾기.
        StartPoint = transform.Find("StartPoint").gameObject;
        EndPoint  = transform.Find("EndPoint").gameObject;
        Player = transform.Find("Penguin").gameObject;

        //SpawnPosition.transform.position = SpawnerPrefab.transform.position;//레벨 스포너를 생성할 위치의 기준 점을 저장.

        StartCoroutine("StartGame");
    }

    void Update()
    {
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
        //Clear UI 나오기.
    }

    public void GameOver()
    {
        currentState = GameState.gameOver;
        StopCoroutine("StartGame");
        //UI처리
        Debug.Log("게임오버");
    }

    public void StopSpawnLevel()
    {
        StopCoroutine("dynamicSpawnLevel");
        
    }

    //동적으로 스포너 생성.
    IEnumerator dynamicSpawnLevel()
    {
        int count = 1;         
        while(true)
        {
            Vector3 pos = new Vector3(SpawnerPrefab.transform.position.x,SpawnerPrefab.transform.position.y,SpawnerPrefab.transform.position.z+2.0f*count);//매 텀마다 z값이 점점 축적 되면서 값이 증가한다.
            int rand = Random.Range(0, 2);
            if(rand==0)
            {
                spawned = Instantiate(SpawnerPrefab , pos , Quaternion.Euler(new Vector3(0,180.0f,0)));
            }
            else if(rand==1)
            {
                spawned = Instantiate(SpawnerPrefab , pos , Quaternion.Euler(0,0,0));
            }
            //scale 조절
            Vector3 originScale = spawned.transform.localScale;
            spawned.transform.SetParent(transform);
            spawned.transform.localScale = originScale;

            count ++;
                   
            yield return new WaitForSeconds(3.0f);
        }    

        yield return null;  
    }
  
}
