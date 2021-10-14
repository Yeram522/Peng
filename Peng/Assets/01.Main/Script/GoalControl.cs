using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalControl : MonoBehaviour
{
    //GameClear Check
    private void OnTriggerEnter(Collider other)//�� ���� �浹�ϸ� �ڷ�ƾ�� �����.
    {
        if(other.tag != "Player") return;
        
        switch(other.tag)
        {
            case "Player":
            GameManager.instance.GameClear();
            break;
            case "Respawn":
            GameManager.instance.StopSpawnLevel();
            break;
        }
    }
}
