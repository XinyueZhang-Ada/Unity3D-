using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow1 : MonoBehaviour
{
    //跟随的游戏人物
    private Transform Player;
    //相机与人物之间的距离
    Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("JohnLemon").transform;
        offset = transform.position - Player.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = offset + Player.position;
    }
}
