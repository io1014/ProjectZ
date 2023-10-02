using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class MZombieControll : MonoBehaviour
{

    State state = State.Idle;

    float traceDist = 5f; //추적거리
    float attackDist = 0.4f; // 공격거리
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

        //agent.destination = playerTr.position;
        StartCoroutine(CheckZombieState());
        StartCoroutine(ZombieAction());
    }

    // Update is called once per frame
    void Update()   
    {

    }

    //애니메이션 타입
    public enum State
    {
        Idle,
        walk,
        attack,
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
                state = State.attack;
            }
            else if (distance <= traceDist )
            {
                state = State.walk;
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
        float _nextStateDelay = 0.3f;
        while(!isDie)
        {
            switch(state) 
            {

                case State.Idle:
                    //agent.isStopped = true; //추적여부
                    anim.SetBool("walk", false);
                    _nextStateDelay = 0.3f;
                    break;
                  

                case State.walk:
                    LookatRotation();
                    agent.SetDestination(playerTr.position); //추적 대상
                    agent.isStopped = false;
                    anim.SetBool("walk", true);
                    anim.SetBool("attack", false);
                    _nextStateDelay = 0.3f;
                    break;
                
                case State.attack:
                    anim.SetBool("attack", true);
                    _nextStateDelay = 0.3f;
                    break;

                case State.Die:
                    _nextStateDelay = 0.3f;
                    break;

                   
            }
            yield return new WaitForSeconds(_nextStateDelay);  
        }
    }
    void LookatRotation()
    {
        Vector3 to = new Vector3(playerTr.position.x, 0, playerTr.position.z);
        Vector3 from = new Vector3(transform.position.x, 0, transform.position.z);

        transform.rotation = Quaternion.LookRotation(to - from);
    }
}
