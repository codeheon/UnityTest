using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; // NavMesh Agent 클래스가 포함된 네임스페이스

public class EnemyMove : MonoBehaviour
{
    // 목표 대상 정보 변수
    Transform target;
    // NavMesh Agent 변수
    NavMeshAgent nav;
    void Start()
    {
        // NavMeshAgent 컴포넌트 받아오기
        nav = GetComponent<NavMeshAgent>();
        // Player 게임오브젝트를 찾아서 target으로 지정하기
        target = GameObject.Find("Player").transform;
    }

    void Update()
    {
        // 내비게이션의 목적지를 target의 현재 위치로 계속 갱신해주기.
        GetComponent<Animator>().SetBool("bMove", true);
        nav.SetDestination(target.position);
    }
}
