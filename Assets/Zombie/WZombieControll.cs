using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class WZombieControll : MonoBehaviour
{

    State state = State.Idle;

    float traceDist = 10f; //추적거리
    float attackDist = 2.0f; // 공격거리
    bool isDie = false; //죽은지 체크
    Transform monsterTr;
    public Transform playerTr;
    NavMeshAgent agent;
    Animator anim;
    void Start()
    {
        monsterTr = GetComponent<Transform>();
        playerTr = GameObject.FindWithTag("Hero").GetComponent<Transform>();
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();

        agent.destination = playerTr.position;
        StartCoroutine(CheckZombieState());
        StartCoroutine(ZombieAction());
    }

    // Update is called once per frame
    void Update()   
    {
        Debug.Log(state);
        Debug.Log(playerTr.position);
        //Debug.Log(state);
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

    //좀비 애니메이션 움직임
    IEnumerator ZombieAction()
    {
        while(!isDie)
        {
            switch(state) 
            {

                case State.Idle:
                    agent.isStopped = true; //추적여부
                    anim.SetBool("Run", false);
                    break;

                case State.Trace:
                    agent.SetDestination(playerTr.position); //추적 대상
                    agent.isStopped = false;
                    anim.SetBool("Run", true);
                    anim.SetBool("Attack", false);
                    break;
                
                case State.Attack:
                    anim.SetBool("Attack", false);
                    break;

                case State.Die:
                    break;

                   
            }
            yield return new WaitForSeconds(0.3f);  
        }
    }
}
