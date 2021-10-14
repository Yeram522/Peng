using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpCount : MonoBehaviour
{
    public GameObject Player;
    public GameObject[] fishes = new GameObject[3];
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i<3;i++)
        {
            fishes[i] = transform.GetChild(i).gameObject;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.instance.currentState == GameState.gameOver) return;
        
        for(int i = 0; i<3;i++)
        {
            if( i < Player.GetComponent<Player>().hp)
            {
                fishes[i].SetActive(true);
                continue;
            }
            fishes[i].SetActive(false);
        }
        
    }
}
