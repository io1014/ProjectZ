using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieFSM : GameObjectFSM
{
    Dictionary<ZombieState, GameObjectFSMState> _state = new Dictionary<ZombieState, GameObjectFSMState>();
    Action _callback;
    void Awake()
    {
        _state.Add(ZombieState.Idle, new ZombieIdleState(gameObject));
        _state.Add(ZombieState.Patroll, new ZombiePatrollState(gameObject));
        
    }

    public void ChangeByStateEnum(ZombieState type)
    {
        _callback = null;
        ChangeState(_state[type]);
    }
    void AnimCallback()
    {
        _callback?.Invoke();
    }
    public void SetAnimStateCallback(Action action)
    {
        _callback = action;
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
