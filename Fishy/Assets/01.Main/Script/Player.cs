using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //About Player Move
    public float speed = 5f;
    public float jumpPower = 10f;
    public int hp; //ü�� 3��

    //Import Component
    private Rigidbody PlayerRigidbody;
    //���� ���� ����
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
         //���� ����Ű �Է��� ������ ��� z���� �� �ֱ�
         PlayerRigidbody.AddForce(0f, 0f, speed);
      }

      if (Input.GetKey(KeyCode.DownArrow)||Input.GetKey(KeyCode.S))
      {      
         //�Ʒ��� ����Ű �Է��� ������ ��� -z���� �� �ֱ�
         PlayerRigidbody.AddForce(0f, 0f, -speed);
      }

      if (Input.GetKey(KeyCode.RightArrow)||Input.GetKey(KeyCode.A))
      {
         //������ ����Ű �Է��� ������ ��� x���� �� �ֱ�
         PlayerRigidbody.AddForce(speed,0f, 0f);
      }

      if (Input.GetKey(KeyCode.LeftArrow)|| Input.GetKey(KeyCode.D))
      {
         //���� ����Ű �Է��� ������ ��� -x���� �� �ֱ�
         PlayerRigidbody.AddForce(-speed, 0f, 0f);
      }

      if (Input.GetKey(KeyCode.Space))
      {
         //space �Է��� ������ ��� +y���� �� �ֱ�
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

    private void OnCollisionEnter(Collision collision)//�浹�ϴ� ����
    {
      if(!collision.collider.CompareTag("glacier")) return;
      isJumping = true  ;
    }

    private void OnCollisionExit(Collision collision)//�浹�ϴ� ����
    {
      if(!collision.collider.CompareTag("glacier")) return;
      isJumping = false  ;
    }
}
