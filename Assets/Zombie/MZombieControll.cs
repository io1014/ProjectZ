using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class MZombieControll : MonoBehaviour
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

        //agent.destination = playerTr.position;
        StartCoroutine(CheckZombieState());
        StartCoroutine(ZombieAction());
    }

    // Update is called once per frame
    void Update()   
    {

    }

    //�ִϸ��̼� Ÿ��
    public enum State
    {
        Idle,
        walk,
        attack,
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

    //���� �ִϸ��̼� ������
    IEnumerator ZombieAction()
    {
        float _nextStateDelay = 0.3f;
        while(!isDie)
        {
            switch(state) 
            {

                case State.Idle:
                    //agent.isStopped = true; //��������
                    anim.SetBool("walk", false);
                    _nextStateDelay = 0.3f;
                    break;
                  

                case State.walk:
                    LookatRotation();
                    agent.SetDestination(playerTr.position); //���� ���
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
