using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMove : MonoBehaviour
{
    [SerializeField] Transform _Hero;
    Transform _Monster;
    [SerializeField] float _speed ;
    [SerializeField] float damage ;

    private void Start()
    {
        _Monster = transform;
    }
    void Update()
    {
        if (Vector3.Distance(_Hero.position, _Monster.position) < 5f && Vector3.Distance(_Hero.position, _Monster.position) > 1.1f)
        {
            follow();
        }
       
    }

    void follow()
    {
        Vector3 move = (_Hero.position - _Monster.position).normalized * _speed;
        _Monster.position = _Monster.position + move * Time.deltaTime;
    }

    public void Init(Transform hero)
    {
        _Hero = hero;
    }

    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<HeroStats>().Damage(damage);
    }


}
