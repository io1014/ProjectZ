using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class WZombieControll : MonoBehaviour
{

    State state = State.Idle;

    float traceDist = 5f; //추적거리
    float attackDist = 0.4f; // 공격거리
    float attackdamage = 5f;
    float Hp = 50f;
    bool isDie = false; //죽은지 체크
    Transform monsterTr;
    public Transform playerTr;
    NavMeshAgent agent;
    Animator anim;
    private GameObject bloodEffect;
    void Start()
    {
        monsterTr = GetComponent<Transform>();
        playerTr = GameObject.FindWithTag("Hero").GetComponent<Transform>();
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();

        bloodEffect = Resources.Load<GameObject>("BloodSprayEffect");
        agent.destination = playerTr.position;
        StartCoroutine(CheckZombieState());
        StartCoroutine(ZombieAction());
    }


    // Update is called once per frame
    void Update()   
    {
        if(state == State.Trace)
        {

            Invoke("LookatRotation", 0.1f);

        }
    }

    //애니메이션 타입
    public enum State
    {
        Idle,
        Trace,
        Attack,
        Die,
    }

    //좀비 상태 체크
    IEnumerator CheckZombieState()
    {
        while (!isDie)
        {
            yield return new WaitForSeconds(0.3f); //3초 간격으로 체크


            float distance = Vector3.Distance(playerTr.position, monsterTr.position); // 거리계산

            if (distance <= attackDist)
            {
                state = State.Attack;
            }
            else if (distance <= traceDist)
            {
                state = State.Trace;
            }
            else
            {
                state = State.Idle;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);

            //anim.SetTrigger("Hit");

            //해당 충돌 발생 지점 체크
            Vector3 pos = collision.GetContact(0).point;

            //해당 충돌 발생지점 반대방향으로 바라보게 설정
            Quaternion rot = Quaternion.LookRotation(-collision.GetContact(0).normal);

            ShowBloodEffect(pos, rot);


        }
    }
    void ShowBloodEffect(Vector3 pos, Quaternion rot)
    {
        GameObject blood = Instantiate<GameObject>(bloodEffect, pos, rot, monsterTr);
        Destroy(blood,0.5F);
    }

    //좀비 애니메이션 움직임
    IEnumerator ZombieAction()
    {
        float _next = 0.3f;
        while(!isDie)
        {
            switch(state) 
            {

                case State.Idle:
                    agent.isStopped = true; //추적여부
                    anim.SetBool("Run", false);
                    _next = 0.3f;
                    break;

                case State.Trace:

                    //LookatRotation();
                    agent.SetDestination(playerTr.position); //추적 대상
                    agent.isStopped = false;
                    anim.SetBool("Run", true);
                    anim.SetBool("Attack", false);
                    _next = 0.3f;
                    break;
                
                case State.Attack:
                    //LookatRotation();
                    anim.SetBool("Attack", true);
                    _next = 0.3f;
                    break;

                case State.Die:
                    break;

                   
            }
            yield return new WaitForSeconds(_next);  
        }
    }
    void LookatRotation()
    {
        Vector3 to = new Vector3(playerTr.position.x,0, playerTr.position.z);
        Vector3 from = new Vector3(transform.position.x,0,transform.position.z);

        transform.rotation = Quaternion.LookRotation(to - from);
    }


}
