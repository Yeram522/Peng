using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //About Player Move
    public float speed = 5f;
    public float jumpPower = 10f;

    private Animator anim;

    //Import Component
    private Rigidbody PlayerRigidbody;

    void Start()
    {
        PlayerRigidbody = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //수평축과 수직축의 입력값을 감지하여 저장
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        //실제 이동 속도를 입력값과 이동 속력을 사용해 결정
        float xSpeed = xInput * speed;
        float zSpeed = zInput * speed;

        //Vector3 속도를 (zSpeed,0,zSpeed)로 생성
        Vector3 newVelocity = new Vector3(xSpeed, 0f, zSpeed);

        //리지드바디의 속도에 newVelocity 할당
        PlayerRigidbody.velocity = newVelocity;

        if (Input.GetKey(KeyCode.UpArrow)||Input.GetKey(KeyCode.W))
        {
           //위쪽 방향키 입력이 감지된 경우 z방향 힘 주기
           PlayerRigidbody.AddForce(0f, 0f, speed);
           if(anim.GetBool("isInWater")==true) return;
           anim.SetBool("isMoving",true) ;
        }

        if (Input.GetKey(KeyCode.DownArrow)||Input.GetKey(KeyCode.S))
        {      
           //아래쪽 방향키 입력이 감지된 경우 -z방향 힘 주기
           PlayerRigidbody.AddForce(0f, 0f, -speed);
           if(anim.GetBool("isInWater")==true) return;
           anim.SetBool("isMoving",true) ;
        }

        if (Input.GetKey(KeyCode.RightArrow)||Input.GetKey(KeyCode.A))
        {
           //오른쪽 방향키 입력이 감지된 경우 x방향 힘 주기
           PlayerRigidbody.AddForce(speed,0f, 0f);
           if(anim.GetBool("isInWater")==true) return;
           anim.SetBool("isMoving",true) ;
        }

        if (Input.GetKey(KeyCode.LeftArrow)|Input.GetKey(KeyCode.D))
        {
           //왼쪽 방향키 입력이 감지된 경우 -x방향 힘 주기
           PlayerRigidbody.AddForce(-speed, 0f, 0f);
           if(anim.GetBool("isInWater")==true) return;
           anim.SetBool("isMoving",true) ;
        }

        if (Input.GetKey(KeyCode.Space))
        {
           //space 입력이 감지된 경우 +y방향 힘 주기
           PlayerRigidbody.AddForce(Vector3.up * jumpPower,ForceMode.Impulse);
           anim.SetTrigger("isJump") ;
           anim.SetBool("isInWater",false) ;
        }

    }

   //  private void OnTriggerEnter(Collider other)//충돌하는 순간
   //      {
   //          if(other.tag != "glacier") return;
   //          GetComponent<Animator>().SetBool("isInWater",true);
   //      }
}
