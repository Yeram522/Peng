using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //About Player Move
    private BoxCollider boxcollider;
    public float speed = 5f;
    public float jumpPower = 10f;
    public int hp; //ü�� 3��

    public AudioClip jumpSound;
    private AudioSource audio;

    //Import Component
    private Rigidbody PlayerRigidbody;
    private Animator animator;
    //���� ���� ����
    public bool isJumping;

    void Start()
    {
        hp = 3;
        PlayerRigidbody = GetComponent<Rigidbody>();
        animator = transform.Find("Player").transform.GetComponent<Animator>();

        this.audio = this.gameObject.AddComponent<AudioSource>();
        this.audio.clip = this.jumpSound;
        this.audio.loop = false;

        boxcollider = GetComponent<BoxCollider>();//�ر��� ���帱������ �ݶ��̴� ��� ���ߵǼ� ������!
    }

    public void KeyCheck()
    {
       //player move
      if (Input.GetKey(KeyCode.W))
      {
         transform.Find("Player").transform.rotation = Quaternion.Euler(0,90,0);//player�� �ٶ󺸰� �ִ� ���� ��ȯ
         //���� ����Ű �Է��� ������ ��� z���� �� �ֱ�
         PlayerRigidbody.AddForce(0f, 0f, speed);  
         Debug.Log("KeyDown");     
      }

      if (Input.GetKey(KeyCode.S))
      {
         transform.Find("Player").transform.rotation = Quaternion.Euler(0,-90,0);//player�� �ٶ󺸰� �ִ� ���� ��ȯ
         //�Ʒ��� ����Ű �Է��� ������ ��� -z���� �� �ֱ�
         PlayerRigidbody.AddForce(0f, 0f, -speed);      
         Debug.Log("KeyDown");    
      }

      if (Input.GetKey(KeyCode.A))
      {
         transform.Find("Player").transform.rotation = Quaternion.Euler(0,0,0);//player�� �ٶ󺸰� �ִ� ���� ��ȯ
         //������ ����Ű �Է��� ������ ��� x���� �� �ֱ�
         PlayerRigidbody.AddForce(speed,0f, 0f);    
         Debug.Log("KeyDown"); 
      }

      if (Input.GetKey(KeyCode.D))
      {
         transform.Find("Player").transform.rotation = Quaternion.Euler(0,180,0);//player�� �ٶ󺸰� �ִ� ���� ��ȯ
         //���� ����Ű �Է��� ������ ��� -x���� �� �ֱ�
         PlayerRigidbody.AddForce(-speed, 0f, 0f);   
         Debug.Log("KeyDown");     
      }

      if (Input.GetMouseButton(0))
      {
         //space �Է��� ������ ��� +y���� �� �ֱ�
         if(!isJumping)
         {
            this.audio.Play();
            //PlayerRigidbody.AddForce(Vector3.up * jumpPower,ForceMode.Impulse);
            PlayerRigidbody.velocity = new Vector3(0, jumpPower,0); 
            isJumping = true;             
         }           
      }

      if(Input.GetMouseButtonDown(1))
      {
         animator.SetBool("isAvoid",true);
         boxcollider.enabled = false;
      }

      if(Input.GetMouseButtonUp(1))
      {
         animator.SetBool("isAvoid",false);
         boxcollider.enabled = true;
      }
    }

    // Update is called once per frame
    void Update()
    {
      float xInput = Input.GetAxis("Horizontal");
      float zInput = Input.GetAxis("Vertical");

      float xSpeed = xInput * speed;
      float zSpeed = zInput * speed;

      if(GameManager.instance.currentState == GameState.gameOver || GameManager.instance.isWaiting == true) return;

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
