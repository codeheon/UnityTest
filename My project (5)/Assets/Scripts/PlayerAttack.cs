using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    float delay = 0f; // 공격 딜레이
    LineRenderer line; // 총알
    public Transform ShootPoint; // 총알 발사대
    public int playerAttack = 50;
    void Start()
    {
        line = GetComponent<LineRenderer>(); // LineRenderer 컴포넌트 가져오기
    }
    void Update()
    {
        // 공격 딜레이 시간 누적
        delay += Time.deltaTime;
        // 딜레이가 0.2초 이상 지나고, 공격버튼을 눌렀다면
        if (delay >= 0.2f && Input.GetAxis("Fire1") != 0)
        {
            delay = 0f; // 공격 딜레이 초기화
            Shoot(); // 발사 함수 실행
        }
        else if(delay >= 0.2f || Input.GetAxis("Fire1") == 0)
        {
            GetComponent<Animator>().SetBool("bShoot", false);
        }
        // 0.05초가 지나면 line 삭제
        if(delay >= 0.05f)
        {
            line.enabled = false;
        }
    }
    void Shoot() // 총알 발사 함수
    {
        GetComponent<Animator>().SetBool("bShoot", true);
        // Ray는 유니티에서 빛을 담당하는 자료형
        // new Ray(빛 발사 위치, 발사 방향)
        Ray ray = new Ray(ShootPoint.position, ShootPoint.forward);
        // RaycastHit: Ray가 부딪힌 대상을 관리하는 자료형
        RaycastHit hit;
        // Raycast(빛, 부딪힌 대상, 이동거리, 부딪힌 대상의 layer)
        if(Physics.Raycast(ray, out hit, 100, LayerMask.GetMask("Shootable")))
        {
            // 부딪힌 대상에게 EnemyHealth 스크립트가 있는지 확인하는 변수
            EnemyHealth eh = hit.collider.GetComponent<EnemyHealth>();
            // eh가 존재한다면
            if (eh != null) 
            {
                // EnemyHealth 스크립트에서 Damage 함수 호출
                eh.Damage(playerAttack); 
            }
            // 총알 발사되는 궤적(LineRenderer)표시
            line.enabled = true;
            line.SetPosition(0, ShootPoint.position);
            line.SetPosition(1, hit.point);
        }
        else // 부딪힌 대상이 없다면, 100 만큼 진행
        {
            line.enabled = true;
            line.SetPosition(0, ShootPoint.position);
            line.SetPosition(1, ShootPoint.position + ray.direction * 100);
        }
    }
}
