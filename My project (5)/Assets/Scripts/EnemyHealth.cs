using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; // 적이 죽으면 NavMeshAgent 비활성화하기 위함

public class EnemyHealth : MonoBehaviour
{
    public int health = 100; // 에너미 체력. 기본값은 100.
    public void Damage(int d)
    {   // d값에 해당하는 만큼 에너미의 체력을 감소시키는 함수.
        // 플레이어가 대미지를 주는 것이니까 공용(public)으로 관리.
        // d(플레이어 공격력)만큼 체력을 감소
        health -= d;
        // 체력이 0 이하가 되면 에너미 사망처리
        if(health <= 0)
        {
            // 에너미의 애니매이터에서 eDeath 트리거 활성화
            GetComponent<Animator>().SetTrigger("eDeath");
            // 에너미 EnemyMove 스크립트 비활성화(AI 스크립트 중지)
            GetComponent<EnemyMove>().enabled = false;
            // 에너미의 NavMeshAgent 기능 비활성화(AI 작동 중지)
            GetComponent<NavMeshAgent>().enabled = false;
            // 에너미의 layer를 변경해서 더 이상 피격 판정 발생하지 않게 하기
            gameObject.layer = 0;
            // 에너미를 2초 뒤에 삭제. 죽음 애니매이션이 끝나는 시간
            Destroy(gameObject, 2);
            // GameManager라는 이름의 오브젝트를 찾고
            // 그 오브젝트에 붙은 Spawn 스크립트에서 cnt 감소.
            GameObject.Find("GameManager").GetComponent<Spawn>().cnt--;
        }
    }
}
