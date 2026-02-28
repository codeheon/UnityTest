using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    GameObject player;//공격 대상 오브젝트
    bool bInrange;//공격 범위
    float timer;//공격 지연
    void Start()
    {
        //플레이어와 에너미가 모두 여러개 존재하면, 게임이 시작할때 공격 대상 지정...
        player = GameObject.Find("Player");
    }
    private void OnTriggerEnter(Collider other)
    {
        //other 오브젝트가 collider의 영역안에 들어왔는지 판단
        if(other.gameObject == player)
            bInrange = true;
    }
    private void OnTriggerExit(Collider other)
    {
        //other 오브젝트가 collider의 영역 밖에 나갔왔는지 판단
        if (other.gameObject != player)
            bInrange = false;
    }
    // collision 충돌 vs trigger 충돌
    // collision 물리적인 충돌 필요한 경우, 통과 불가한 충돌
    // trigger 유령처럼 통과하면서 감지, 영역 감지
    void Update()
    {
        timer += Time.deltaTime;//공격 딜레이 누적
        if (timer >= 0.5f&&bInrange)
        {
            timer = 0;//공격 딜레이 초기화
            player.GetComponent<PlayerHealth>().Damage(10);
        }
    }
}
