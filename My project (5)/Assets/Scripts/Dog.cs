using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Dog : MonoBehaviour
{
    Transform player;//추적대상
    NavMeshAgent nav;//플레이어 추적 내비게이션
    Vector3 posReturn;//플레이어 놓치면 복귀할 위치
    public float maxDistance = 6;
    public float minDistance = 2;

    void Start()
    {
        player = GameObject.Find("Player").transform;//플레이어 위치 기록
        nav = GetComponent<NavMeshAgent>(); // nav 활성화
        posReturn = transform.position; // Dog 의 처음 위치를 복구할 위치로 기록
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3.Distance(a, b) : a 오브젝트와 b 오브젝트 사이의 거리를 계산해주는 함수
        //Dog의 현재 위치와 플레이어의 현재 위치 사이의 거리를 저장
        float distance = Vector3.Distance(transform.position, player.position);
        if (distance > maxDistance) //프레이어와 강아지 거리 충분희 멀다면?
        {
            //nav 목적지를 보고 위치로 설정
            nav.SetDestination(posReturn);
            if (Vector3.Distance(transform.position, posReturn) > 1)
            {
                GetComponent<Animator>().SetBool("bMove", true);
            }
            else 
            {
                GetComponent<Animator>().SetBool("bMove", false);
            }
        }
        else if(distance > minDistance)//플레이어와 강아지가 min과 max 사이에 있으면
        {
            nav.SetDestination(player.position);
            GetComponent<Animator>().SetBool("bMove", true);
        }
        else//플레이어와 강아지 너무 가까운 경우
        {
            nav.SetDestination(transform.position);//내비게이션 목적지 현재 위치로
            //대기 Ani
            GetComponent<Animator>().SetBool("bMove", false);
        }
    }
}
