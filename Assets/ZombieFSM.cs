using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    Dictionary<ZombieState, GameObjectFSM> _state = new Dictionary<ZombieState, GameObjectFSM>();
    Action _callback;
    void Awake()
    {
        //_state.Add(ZombieState.Idle, new ZombieIdleState(gameObject));
        //_state.Add(ZombieState.Patroll, new ZombiePatrollState(gameObject));
        //_state.Add(ZombieState.AttackMove, new ZombieAttackMoveState(gameObject));
        //_state.Add(ZombieState.Die, new ZombieDieState(gameObject));
        //_state.Add(ZombieState.Attack, new ZombieAttackState(gameObject));
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}

public enum ZombieState
{
    Idle,
    Attack,
    Patroll,
    Die,
}
