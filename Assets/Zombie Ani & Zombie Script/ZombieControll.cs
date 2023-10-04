using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class ZombieControll : MonoBehaviour
{

    public State state = State.Idle;

    float traceDist = 5f; //�����Ÿ�
    float attackDist = 0.5f; // ���ݰŸ�
    float attackdamage = 5f;
    public float Hp = 50f;
    bool isDie = false; //������ üũ
    Transform monsterTr;
    public Transform playerTr;
    NavMeshAgent agent;
    Animator anim;
    private GameObject bloodEffect;
    private readonly int hit = Animator.StringToHash("Hit");
    private readonly int die = Animator.StringToHash("Die");
    bool _isAttackStart = false;
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
        //���������� �����Ÿ��� ȸ������
        if(agent.remainingDistance  >= 0.5f)
        {
            //������Ʈ�� �̵�����
            Vector3 direction = agent.desiredVelocity;

            if(direction.sqrMagnitude >= 0.1f * 0.1f)
            {
                //ȸ������
                Quaternion rot = Quaternion.LookRotation(direction);
                //ȸ��ó��
                monsterTr.rotation = Quaternion.Slerp(monsterTr.rotation, rot, Time.deltaTime * 10);
            }
        }
        if (state == State.Attack && _isAttackStart == false ) // attack �ִϸ��̼��� �ƴҶ�
        {
            LookatRotation();
        }

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

            if (state == State.Die) yield break;

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

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Bullet"))
        {
            Hp -= collision.collider.GetComponent<Bullet>().getDamage();
            Destroy(collision.gameObject);
            anim.SetTrigger(hit);

            //�ش� �浹 �߻� ���� üũ
            Vector3 pos = collision.GetContact(0).point;

            //�ش� �浹 �߻����� �ݴ�������� �ٶ󺸰� ����
            Quaternion rot = Quaternion.LookRotation(-collision.GetContact(0).normal);

            ShowBloodEffect(pos, rot);

            if(Hp <= 0)
            {
                if (Hp <= 0)
                {
                    state = State.Die;
                }
            }
        }
    }
    void ShowBloodEffect(Vector3 pos, Quaternion rot)
    {
        GameObject blood = Instantiate<GameObject>(bloodEffect, pos, rot, monsterTr);
        Destroy(blood,0.5F);
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
                    _next = 0.3f;
                    break;

                case State.Trace:

                    //LookatRotation();
                    agent.SetDestination(playerTr.position); //���� ���
                    agent.isStopped = false;
                    anim.SetBool("Run", true);
                    anim.SetBool("Attack", false);
                    _next = 0.3f;
                    break;
                
                case State.Attack:
                    //LookatRotation();
                    anim.SetBool("Attack", true);
                    _isAttackStart = true;
                    _next = 0.3f;
                    break;

                case State.Die:
                    isDie = true;
                    agent.isStopped = true;

                    anim.SetTrigger(die);
                    GetComponent<CapsuleCollider>().enabled = false;

                    yield return new WaitForSeconds(1.0f);
                    Destroy(gameObject);
                    break;

                   
            }
            yield return new WaitForSeconds(_next);  
        }
    }

    void AttackAniEnd()
    {
        _isAttackStart = false;
    }

    void LookatRotation()
    {
        Vector3 to = new Vector3(playerTr.position.x, 0, playerTr.position.z);
        Vector3 from = new Vector3(transform.position.x, 0, transform.position.z);

        transform.rotation = Quaternion.LookRotation(to - from);
    }

}
