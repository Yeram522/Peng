using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour
{
    //GameOver처리
    private void OnTriggerEnter(Collider other)//맵 끝과 충돌하면 코루틴을 멈춘다.
    {
        if(other.tag != "Player") return;
        GameManager.instance.GameOver();
        
        
    }
}
