using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject obj; // 생산할 대상(Enemy)
    public float time; // 생성 대기시간(주기)
    public Transform[] point; // 생성 위치를 저장할 배열

    public int Max; // 생성 오브젝트 최대 개수 제한
    public int cnt; // 현재 오브젝트 개수

    void Start()
    {
        // 유니티에서 특정 함수를 일정 간격으로 반복 호출할 때 사용하는 명령어.
        // InvokeRepeating("함수이름", 처음 호출하는 시간, 주기)
        InvokeRepeating("Create", time, time);
    }

    void Create()
    {
        // 최대 개수 제한을 넘어가려고 하면 함수 중지
        if (cnt >= Max)
            return;
        cnt++; // 아니면 현재 오브젝트 개수 카운트.
        // 생성 위치 랜덤으로 1개 고르기
        int i = Random.Range(0, point.Length);
        Instantiate(obj, point[i]); // 유니티에서 prefab으로 저장한 오브젝트 생성 함수
        // Instantiate(만들 오브젝트, 위치)
    }
}
