using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class WZombieControll : MonoBehaviour
{

    State state = State.Idle;

    float traceDist = 5f; //�����Ÿ�
    float attackDist = 0.4f; // ���ݰŸ�
    bool isDie = false; //������ üũ
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
        //Debug.Log(state);
        //Debug.Log(playerTr.position);
        //Debug.Log(state);
    }

    //�ִϸ��̼� Ÿ��
    public enum State
    {
        Idle,
        Trace,
        Attack,
        Die,
    }

    //���� ���� üũ
    IEnumerator CheckZombieState()
    {
        while (!isDie)
        {
            yield return new WaitForSeconds(0.3f); //3�� �������� üũ


            float distance = Vector3.Distance(playerTr.position, monsterTr.position); // �Ÿ����

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

    //���� �ִϸ��̼� ������
    IEnumerator ZombieAction()
    {
        float _next = 0.3f;
        while(!isDie)
        {
            switch(state) 
            {

                case State.Idle:
                    agent.isStopped = true; //��������
                    anim.SetBool("Run", false);
                    _next = 1f;
                    break;

                case State.Trace:
                    transform.LookAt(playerTr.position);
                    agent.SetDestination(playerTr.position); //���� ���
                    agent.isStopped = false;
                    anim.SetBool("Run", true);
                    anim.SetBool("Attack", false);
                    _next = 3f;
                    break;
                
                case State.Attack:
                    anim.SetBool("Attack", true);
                    _next = 1f;
                    break;

                case State.Die:
                    break;

                   
            }
            yield return new WaitForSeconds(_next);  
        }
    }
}
