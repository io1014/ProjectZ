using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameObjectFSM : MonoBehaviour
{
    GameObjectFSMState _currentState;
    
    public void ChangeState(GameObjectFSMState nextstate)
    {
        _currentState?.OnExit();
        _currentState = nextstate;
        _currentState?.OnEnter();
    }    

    // Update is called once per frame
    void Update()
    {
        _currentState?.DoLoop();
      
    }
   
}
public abstract class GameObjectFSMState
{
    protected GameObject _obj;
    public GameObjectFSMState(GameObject obj) => _obj = obj;

    public abstract void OnEnter();
    public abstract void DoLoop();
    public abstract void OnExit();
}
public class ZombieIdleState : GameObjectFSMState
{
    ZombieController _baseComp;
    ZombieFSM _baseFSM;
    float _timer;
    public ZombieIdleState(GameObject obj) : base(obj) { }

    void CheckTransition()
    {
        _timer += Time.deltaTime;
        if(_timer > 1)
        {
            _baseFSM.ChangeByStateEnum(ZombieState.Patroll);
        }
    }
    public override void OnEnter()
    {
        _timer = 0;
        _baseComp = _obj.GetComponent<ZombieController>();
        _baseFSM = _obj.GetComponent<ZombieFSM>();
        _baseComp.StartAnim("Idle");

    }
    public override void DoLoop()
    {
        CheckTransition();
    }

    public override void OnExit()
    {
        
    }

}

public class ZombiePatrollState : GameObjectFSMState
{
    float _moveSpeed;
    ZombieController _baseComp;
    ZombieFSM _baseFSM;
    Vector3 _startPos;
    Vector3 _targetPos;
    TrackedReference _targetTransform;
    

    bool _isEndPoint = false;
    

    public ZombiePatrollState(GameObject obj) :base(obj) { }
    public override void OnEnter()
    {
        _baseComp = _obj.GetComponent<ZombieController>();
        _baseFSM = _obj.GetComponent<ZombieFSM>();
        _startPos = _baseComp.Getpos();
        _moveSpeed =_baseComp.GetMoveSpeed();
        _targetPos = new Vector3(Random.Range(-5,5),50,Random.Range(-5,5)) + new Vector3(_startPos.x,0,_startPos.z);
        _baseComp.StartAnim("Run");
    }
    public override void DoLoop()
    {
        _obj.transform.position += (_targetPos - _obj.transform.position).normalized * _moveSpeed * Time.deltaTime;

        CheckTransition();
    }
    void CheckTransition()
    {
        if(Vector3.Distance(_targetPos , _obj.transform.position) < 0.1f)
        {
            _isEndPoint = true;
            _baseFSM.ChangeByStateEnum(ZombieState.Idle);
        }
    }
    public override void OnExit()
    {
       
    }
}
