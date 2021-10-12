using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //About Player Move
    public float speed = 5f;
    public float jumpPower = 10f;
    public int hp; //체력 3개

    //Import Component
    private Rigidbody PlayerRigidbody;
    //무한 점프 방지
    public bool isJumping;

    void Start()
    {
        hp = 3;
        PlayerRigidbody = GetComponent<Rigidbody>();
    }

    public void KeyCheck()
    {
       if(GameManager.instance.gameOver) return;

       //player move
      if (Input.GetKey(KeyCode.UpArrow)||Input.GetKey(KeyCode.W))
      {
         //위쪽 방향키 입력이 감지된 경우 z방향 힘 주기
         PlayerRigidbody.AddForce(0f, 0f, speed);
      }

      if (Input.GetKey(KeyCode.DownArrow)||Input.GetKey(KeyCode.S))
      {      
         //아래쪽 방향키 입력이 감지된 경우 -z방향 힘 주기
         PlayerRigidbody.AddForce(0f, 0f, -speed);
      }

      if (Input.GetKey(KeyCode.RightArrow)||Input.GetKey(KeyCode.A))
      {
         //오른쪽 방향키 입력이 감지된 경우 x방향 힘 주기
         PlayerRigidbody.AddForce(speed,0f, 0f);
      }

      if (Input.GetKey(KeyCode.LeftArrow)|| Input.GetKey(KeyCode.D))
      {
         //왼쪽 방향키 입력이 감지된 경우 -x방향 힘 주기
         PlayerRigidbody.AddForce(-speed, 0f, 0f);
      }

      if (Input.GetKey(KeyCode.Space))
      {
         //space 입력이 감지된 경우 +y방향 힘 주기
         if(!isJumping)
         {
            //PlayerRigidbody.AddForce(Vector3.up * jumpPower,ForceMode.Impulse);
            PlayerRigidbody.velocity = new Vector3(0, jumpPower,0); 
            isJumping = true;             
         }           
      }
    }

    // Update is called once per frame
    void Update()
    {
      float xInput = Input.GetAxis("Horizontal");
      float zInput = Input.GetAxis("Vertical");

      float xSpeed = xInput * speed;
      float zSpeed = zInput * speed;


      Vector3 newVelocity = new Vector3(xSpeed, 0f, zSpeed);
        
      PlayerRigidbody.velocity = newVelocity;

      KeyCheck();
    }

    private void OnCollisionEnter(Collision collision)//충돌하는 순간
    {
      if(!collision.collider.CompareTag("glacier")) return;
      isJumping = true  ;
    }

    private void OnCollisionExit(Collision collision)//충돌하는 순간
    {
      if(!collision.collider.CompareTag("glacier")) return;
      isJumping = false  ;
    }
}
