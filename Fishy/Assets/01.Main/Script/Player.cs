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
        PlayerRigidbody = GetComponent<Rigidbody>();
    }

    void KeyCheck()
    {
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
             PlayerRigidbody.AddForce(Vector3.up * jumpPower,ForceMode.Impulse); 
             isJumping = true;             
           }           
        }
    }

    // Update is called once per frame
    void Update()
    {
      //player move
      KeyCheck();

    }

}
