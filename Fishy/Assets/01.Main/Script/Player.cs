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
        //������� �������� �Է°��� �����Ͽ� ����
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        //���� �̵� �ӵ��� �Է°��� �̵� �ӷ��� ����� ����
        float xSpeed = xInput * speed;
        float zSpeed = zInput * speed;

        //Vector3 �ӵ��� (zSpeed,0,zSpeed)�� ����
        Vector3 newVelocity = new Vector3(xSpeed, 0f, zSpeed);

        //������ٵ��� �ӵ��� newVelocity �Ҵ�
        PlayerRigidbody.velocity = newVelocity;

        if (Input.GetKey(KeyCode.UpArrow)||Input.GetKey(KeyCode.W))
        {
           //���� ����Ű �Է��� ������ ��� z���� �� �ֱ�
           PlayerRigidbody.AddForce(0f, 0f, speed);
           if(anim.GetBool("isInWater")==true) return;
           anim.SetBool("isMoving",true) ;
        }

        if (Input.GetKey(KeyCode.DownArrow)||Input.GetKey(KeyCode.S))
        {      
           //�Ʒ��� ����Ű �Է��� ������ ��� -z���� �� �ֱ�
           PlayerRigidbody.AddForce(0f, 0f, -speed);
           if(anim.GetBool("isInWater")==true) return;
           anim.SetBool("isMoving",true) ;
        }

        if (Input.GetKey(KeyCode.RightArrow)||Input.GetKey(KeyCode.A))
        {
           //������ ����Ű �Է��� ������ ��� x���� �� �ֱ�
           PlayerRigidbody.AddForce(speed,0f, 0f);
           if(anim.GetBool("isInWater")==true) return;
           anim.SetBool("isMoving",true) ;
        }

        if (Input.GetKey(KeyCode.LeftArrow)|Input.GetKey(KeyCode.D))
        {
           //���� ����Ű �Է��� ������ ��� -x���� �� �ֱ�
           PlayerRigidbody.AddForce(-speed, 0f, 0f);
           if(anim.GetBool("isInWater")==true) return;
           anim.SetBool("isMoving",true) ;
        }

        if (Input.GetKey(KeyCode.Space))
        {
           //space �Է��� ������ ��� +y���� �� �ֱ�
           PlayerRigidbody.AddForce(Vector3.up * jumpPower,ForceMode.Impulse);
           anim.SetTrigger("isJump") ;
           anim.SetBool("isInWater",false) ;
        }

    }

   //  private void OnTriggerEnter(Collider other)//�浹�ϴ� ����
   //      {
   //          if(other.tag != "glacier") return;
   //          GetComponent<Animator>().SetBool("isInWater",true);
   //      }
}
