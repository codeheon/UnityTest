using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermove : MonoBehaviour
{
    public float speed = 5f; // 이동속도
    public float jumpPower = 2f; // 점프력
    float groundRad = 0.2f; // 바닥을 반지름 0.2의 원으로 판단
    bool isGround; // 바닥에 닿았는지 여부 체크
    public Transform ground; // 바닥 오브젝트를 저장하는 변수  
    Rigidbody rb; // 리지드바디 컴포넌트 변수
    public LayerMask groundLayer; // 유니티에서 바닥을 판단하는 레이어

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // 땅을 판단하기(땅에서 원형을 그리고 해당 원으로 체크)
        isGround = Physics.CheckSphere(ground.position, groundRad, groundLayer);
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        float j = Input.GetAxis("Jump");
        if(h != 0 || v != 0) // 방향키를 입력하였으면
        {
            Vector3 dir = new Vector3(h,0, v);
            transform.rotation= Quaternion.LookRotation(dir);
            transform.position += dir * speed * Time.deltaTime;
            // GetComponent<컴포넌트 이름>():<> 안의 컴포넌트 내용을 가져오기
            // -> 스크립트로 제어 가능해짐
            // Animator 컴포넌트에서 bMove 패러미터를 true로 변경.
            GetComponent<Animator>().SetBool("bMove", true);
        }
        else // 방향키를 누르지 않는 상태라면
        {
            GetComponent<Animator>().SetBool("bMove", false);
        }
        if(j != 0 && isGround) // 점프 버튼을 누르고, 바닥에 닿은 상태이면
        {
            GetComponent<Animator>().SetBool("bJump", true);
            // 점프력만큼의 힘을 위로 가해서 점프
            rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
        }
        else
        {
            GetComponent<Animator>().SetBool("bJump", false);
        }
    }
}
