using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour
{
    //GameOveró��
    private void OnTriggerEnter(Collider other)//�� ���� �浹�ϸ� �ڷ�ƾ�� �����.
    {
        if(other.tag != "Player") return;
        GameManager.instance.GameOver();
        
        
    }
}
