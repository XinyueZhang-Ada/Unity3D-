using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WayPointsPatrol : MonoBehaviour
{
    //导航组件
    private NavMeshAgent navMeshAgent;
    //导航点的数组
    public Transform[] waypoints;

    //当前巡逻的目标点的索引
    int m_currentpointIndex;

    // Start is called before the first frame update
    void Start()
    {
        //获取NavMeshAgent组件
        navMeshAgent = GetComponent<NavMeshAgent>();
        //从起点到达第一个巡逻点
        navMeshAgent.SetDestination(waypoints[0].position);
    }

    // Update is called once per frame
    void Update()
    {
        //到达目标点，前往下一个目标点
        if (navMeshAgent.remainingDistance < navMeshAgent.stoppingDistance)
        {
            m_currentpointIndex=(m_currentpointIndex + 1)%waypoints.Length;
            navMeshAgent.SetDestination(waypoints[m_currentpointIndex].position);
        }
    }
}
