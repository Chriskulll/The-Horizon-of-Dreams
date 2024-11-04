/*Create By JesonHumber_f4*/
/*2023.3.10*/
/*Unity3D Digtal Twin Project*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(�������))]�������ǣ�
//Ϊ��ǰ���ظýű�����Ϸ���������Ҫ�����(�����ڱ�������)
//�ò�������Ҫ�������������ռ�
[RequireComponent(typeof(CharacterController))]

//���벥�Ŷ��������
[RequireComponent(typeof(Animator))]
public class HandControlCharacter : MonoBehaviour
{
    CharacterController controller;
    Animator animator;

    //�����ƶ��ٶȣ������е��ڣ�
    public float MoveSpeed;

    //��ȡ����ˮƽ����ʹ�ֱ����ֵ�ã�GetAxis()������
    public float horizontal;
    public float vertical;

    //���ڸı䶯��״̬�ı���
    public int move_var;

    //Ŀ�곯��
    public Vector3 target_dir = Vector3.zero;  //��ʼ��Ϊ(0,0,0)�������е���

    // Start is called before the first frame update
    void Start()
    {
        //��ȡ����ɫ������������������Ҫ����������ײ�Ȳ������ͱ�������������
        controller = GetComponent<CharacterController>();

        //��ȡ�����������������
        animator = GetComponent<Animator>();

        //��ʼ�������ƶ��ٶ�
        MoveSpeed = 0;

        //��ʼ������״̬����Ϊ0�����ﾲֹ�������ţ�
        move_var = 0;

        //У׼����ɫ���������Ľ��������(������ײ���)
        controller.center = new Vector3(0, 1, 0);
        controller.radius = 0.5f;
        controller.height = 2;
    }

    // Update is called once per frame
    void Update()
    {
        HandControl_Move();
    }

    public void HandControl_Move()
    {
        //GetAxis("Horizontal");��Ӧ���Ǽ����ϵ�A��D����ˮƽ����
        horizontal = Input.GetAxis("Horizontal");
        //GetAxis("Vertical");��Ӧ���Ǽ����ϵ�W��S������ֱ����    
        vertical = Input.GetAxis("Vertical");

        //ע��������ġ�ˮƽ��ֱ������ӳ��ļ�λʵ���Ͽ��Ը��ģ�
        //����ֻ������Ĭ�Ϲ���,���ǵ����ֵ��Ϊ1
        if (horizontal != 0 || vertical != 0) //����(Ĭ�ϣ�WASD)����ʱ�ͽ����ж�
        {
            //ǰ��
            if (Input.GetKey(KeyCode.W))
            {
                move_var = 1;
                MoveSpeed = 1.5f;
                transform.rotation = Quaternion.LookRotation(target_dir);
                //Quaternion.LookRotation()��
                //����һ������ֵʹ���峯����������
                //ʹ���峯����һ������ֻ��Ҫ������������Position֮���Vector3��ֵ����


                //�����ж�
                if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W))
                {
                    move_var = 2;
                    MoveSpeed = 3.5f;
                }

            }

            //�����
            else if (Input.GetKey(KeyCode.S))
            {
                move_var = 1;
                MoveSpeed = 1.5f;
                transform.rotation = Quaternion.LookRotation(target_dir);

                //�����ж�
                if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.S))
                {
                    move_var = 2;
                    MoveSpeed = 3.5f;
                }
            }

            //������
            else if (Input.GetKey(KeyCode.A))
            {
                move_var = 1;
                MoveSpeed = 1.5f;
                transform.rotation = Quaternion.LookRotation(target_dir);

                //�����ж�
                if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.A))
                {
                    move_var = 2;
                    MoveSpeed = 3.5f;
                }
                //transform.Translate(Vector3.forward * Time.deltaTime);
            }

            //������
            else if (Input.GetKey(KeyCode.D))
            {
                move_var = 1;
                MoveSpeed = 1.5f;
                transform.rotation = Quaternion.LookRotation(target_dir);

                //�����ж�
                if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.D))
                {
                    move_var = 2;
                    MoveSpeed = 3.5f;
                }
            }


            //��������
            //���"BasicMotion"�����֣�������ǵ�Parameter���ֲ�����һ��
            //���Ǿ͵øģ�
            animator.SetInteger("BasicMotion", move_var);
            //��ά���귽������ֵ����
            //��������ֵ�������������
            target_dir = new Vector3(horizontal, 0, vertical);
            //�����ƶ�����
            controller.Move(target_dir * MoveSpeed * Time.deltaTime);

            //controller.Move()��������ʵ��������ƶ��������ڸ����ķ������ƶ���Ϸ����
            //����������Ҫ�������˶�����ֵ���������ٶȣ���֡ˢ��ʱ�䣨Time.deltaTime��
            //ע��controller.Move()�ǲ�ʹ�á��������ģ�����Ѿ����£��ٻ���ʱ�޷����£�
            //    �����Ҫʹ�������ͱ����Լ��ֶ�д����ģ���������Ĵ��롣

            #region
            //Ҳ����ʹ�ø÷�������controller.Move();
            //this.transform.Translate(dir * MoveSpeed * Time.deltaTime);
            #endregion
        }

        else
        {
            //Ĭ��Ϊ��ֹ����
            move_var = 0;

            //����״̬����
            //���"BasicMotion"�����֣�������ǵ�Parameter���ֲ�����һ��
            //���Ǿ͵øģ�
            animator.SetInteger("BasicMotion", 0);
            MoveSpeed = 0;
        }
    }
}