using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour
{
    [SerializeField] float _speed;
    Vector3 _pos;
    // Start is called before the first frame update
    
    
    void Start()
    {
        _pos = transform.position;
        GetComponent<ZombieFSM>().ChangeByStateEnum(ZombieState.Idle);
        GetComponent<ZombieFSM>().ChangeByStateEnum(ZombieState.Patroll);

     
    }
    void Update()
    {
        
    }
    public void StartAnim(string AniName)
    {
        GetComponent<Animator>().Play("Idle");
        
        if(AniName.Equals("Run"))
        {
            GetComponent<Animator>().SetTrigger("Run");
        }
   

    }

    public Vector3 Getpos()
    {
        return _pos;
    }
    public float GetMoveSpeed() => _speed;
}
