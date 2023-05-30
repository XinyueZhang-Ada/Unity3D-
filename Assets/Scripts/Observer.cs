using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer : MonoBehaviour
{
    //游戏角色
    public Transform Player;
    //GameEnding
    public GameEnding gameEnding;

    //游戏玩家是否进入到扫描棒的视线范围
    bool IsInRange = false;


    // Start is called before the first frame update
    //void Start()
    //{

    //}

    private void OnTriggerEnter(Collider other)
    {
        //扫描棒扫描到游戏玩家
        if (other.gameObject == Player.gameObject)
        {
            IsInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //扫描棒扫描到游戏玩家离开了
        if (other.gameObject == Player.gameObject)
        {
            IsInRange = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (IsInRange == true)
        {
            //射线检测
            Vector3 dir = Player.position - transform.position + Vector3.up;
            Ray ray = new Ray(transform.position, dir);
            RaycastHit raycastHit;

            if(Physics.Raycast(ray,out raycastHit))
            {
                if (raycastHit.collider.transform == Player)
                {
                    //游戏失败，玩家被抓住，调用GameEnding方法
                    gameEnding.Caught();
                }
            }
        }
    }
}
