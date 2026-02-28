using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int Hp = 100;//플레이어 초기체력
    Vector3 posRespawn;//부할 위치
    void Start()
    {
        posRespawn = transform.position;//시작 위치를 부할 위치로
    }
    public void ResPawn()
    {
        Hp = 100;//체력 초기화
        transform.position = posRespawn;//위치를 부할 위치로
        GetComponent<Animator>().SetTrigger("Respawn");//애니매이터 부활 트리거
        //플레이어에게 붙은 다른 스크립트 활성화
        GetComponent<playermove>().enabled = true;
        GetComponent<PlayerAttack>().enabled = true;
    }
    public void Damage(int d)//d의 데미지를 입히는 함수. 외부에서 적용
    {
        if (Hp <= 0)//플레이어 사망.
            return;//함수 중지
        Hp -= d;
        if (Hp <= 0)
        {
            //애니매이터
            GetComponent<Animator>().SetTrigger("Death");
            GetComponent<playermove>().enabled = false;
            GetComponent<PlayerAttack>().enabled = false;
            //값에 해당하는 초가 흐르면 함수호출
            Invoke("ResPawn", 3);
        }

    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
