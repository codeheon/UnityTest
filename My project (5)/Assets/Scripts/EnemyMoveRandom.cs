using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMoveRandom : MonoBehaviour
{
    public Vector2 minPos;//자동차가 이동 가능한 좌표의 최소값
    public Vector2 maxPos;//자동차가 이동 가능한 좌표의 최대값
    public Vector2 speedVar;//자동차의 최고속도, 최고속도 범위를 정해주는 변수
    public Vector2 newPosTimeVar;//다음 목적지까지의 운행시간
    public Vector2 newSpeedTimeVar;//다음 목적지까지의 운행시간

    float posTimer;//운행시간
    float speedTimer;//속도시간
    float newPosTime;//새로운 운행시간
    float newSpeedTime;//새로운 속도시간

    NavMeshAgent nav;

    void Start()
    {
        nav = GetComponent<NavMeshAgent>();//NavMeshAgent 컴포넌트 가져오기
        SetRandomPosition();
        SetRandomSpeed();
    }

    // Update is called once per frame
    void Update()
    {
        //운행시간과 속도시간 갱신
        posTimer += Time.deltaTime;
        speedTimer += Time.deltaTime;

        //운행시간이 종료되면, 렌덤 목적지 재설정
        if (posTimer >= newPosTime)
        {
            SetRandomPosition();
        }
        //속도시간 종료되면
        if (speedTimer >= newSpeedTime)
        {
            SetRandomSpeed();
        }
    }

    void SetRandomPosition()//렌덤 목적지 설정 함수
    {
        //다음 목적지 좌표 설정
        float newX = Random.Range(minPos.x, maxPos.x);
        float newZ = Random.Range(minPos.y, maxPos.y);
        nav.destination = new Vector3 (newX, -1f, newZ);
        //목적지까지 운행시간 렌덤설정
        newPosTime = Random.Range(newPosTimeVar.x, newPosTimeVar.y);
        posTimer = 0f;
    }
    void SetRandomSpeed()
    {
        //주어진 범위 내에서 다음 이동속도 렌덤으로 설정
        nav.speed = Random.Range(speedVar.x, speedVar.y);
        
        //속도시간 렌덤으로 설정
        newSpeedTime = Random.Range(newPosTimeVar.x, newPosTimeVar.y);
        speedTimer = 0f;
    }
}
