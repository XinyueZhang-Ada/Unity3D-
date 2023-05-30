using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //定义一个旋转的速度
    public float turnspeed = 20f;//浮点数

    //定义游戏人物上的组件
    Animator m_Animator;
    Rigidbody m_Rigidbody;

    //游戏人物移动的矢量
    Vector3 m_Movement;
    //游戏人物旋转的角度
    Quaternion m_Quaternion = Quaternion.identity;

    // Start is called before the first frame update 只在第一帧执行一次
    void Start()
    {
        //获取游戏人物上的刚体、动画控制机组件
        m_Animator = GetComponent<Animator>();
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame 在每一帧都执行
    //void Update()
    //{
    //    Time.deltaTime//获取每一帧的大小，不同计算机帧的大小不一样
    //}

    private void FixedUpdate()//以固定帧率执行
    {
        //获取水平、竖直（z轴）方向是否有键值输入（是否按下了上下左右键）
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        //设置游戏人物移动的方向
        m_Movement.Set(horizontal, 0f, vertical);
        m_Movement.Normalize();//归一化

        //定义游戏人物是否移动的bool值
        bool hasHorizontalInput = !Mathf.Approximately(horizontal, 0f);//当有输入的horizontal不等于0
        bool hasVerticalInput = !Mathf.Approximately(vertical, 0f);
        //控制人物动画的转换
        bool iswalking = hasHorizontalInput || hasVerticalInput;
        m_Animator.SetBool("isWalking", iswalking);//引号内与Unity内Animator的名称一致

        //旋转的过渡，通过三元数转四元数的方式获取游戏人物当前应有的角度
        Vector3 desirForward = Vector3.RotateTowards(transform.forward, m_Movement, turnspeed * Time.deltaTime, 0f);
        m_Quaternion = Quaternion.LookRotation(desirForward);

    }

    //游戏人物的旋转和移动
    private void OnAnimatorMove()
    {
        //当前位置+目标移动位置
        m_Rigidbody.MovePosition(m_Rigidbody.position + m_Movement * m_Animator.deltaPosition.magnitude);
        m_Rigidbody.MoveRotation(m_Quaternion);
    }
}
