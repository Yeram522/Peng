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
    
    public GameObject SpawnerPrefab;//���߿� Asset���� ��������.

   // public GameObject SpawnPosition; //Sapwner���� �������� ������ position

    private GameObject spawned;//Instanciate ������ ���� ������Ʈ

    public bool gameOver;


    void Awake()
    {
        instance = this;//GameManager �̱���

        //������ ���� ������Ʈ ã��.
        StartPoint = transform.Find("StartPoint").gameObject;
        EndPoint  = transform.Find("EndPoint").gameObject;
        Player = transform.Find("Penguin").gameObject;

        //SpawnPosition.transform.position = SpawnerPrefab.transform.position;//���� �����ʸ� ������ ��ġ�� ���� ���� ����.

        StartCoroutine("StartGame");
    }

    void Update()
    {
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
        //Clear UI ������.
    }

    public void GameOver()
    {
        currentState = GameState.gameOver;
        StopCoroutine("StartGame");
        //UIó��
        Debug.Log("���ӿ���");
    }

    public void StopSpawnLevel()
    {
        StopCoroutine("dynamicSpawnLevel");
        
    }

    //�������� ������ ����.
    IEnumerator dynamicSpawnLevel()
    {
        int count = 1;         
        while(true)
        {
            Vector3 pos = new Vector3(SpawnerPrefab.transform.position.x,SpawnerPrefab.transform.position.y,SpawnerPrefab.transform.position.z+2.0f*count);//�� �Ҹ��� z���� ���� ���� �Ǹ鼭 ���� �����Ѵ�.
            int rand = Random.Range(0, 2);
            if(rand==0)
            {
                spawned = Instantiate(SpawnerPrefab , pos , Quaternion.Euler(new Vector3(0,180.0f,0)));
            }
            else if(rand==1)
            {
                spawned = Instantiate(SpawnerPrefab , pos , Quaternion.Euler(0,0,0));
            }
            //scale ����
            Vector3 originScale = spawned.transform.localScale;
            spawned.transform.SetParent(transform);
            spawned.transform.localScale = originScale;

            count ++;
                   
            yield return new WaitForSeconds(3.0f);
        }    

        yield return null;  
    }
  
}
