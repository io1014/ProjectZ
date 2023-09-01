using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExamMonsterMove : MonoBehaviour
{
    [SerializeField] Transform _Hero;
    Transform _Monster;
    float _speed = 3;
    [SerializeField] float damage;
    public int _health = 100;

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

    public void GetDamage(int damage)
    {
        _health -= damage;
        if (_health < 0)
        {
            Destroy(gameObject);
        }
    }
    public void SetSpeed(float speed)
    {
        _speed = speed;
    }
}
