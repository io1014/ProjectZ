using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MonsterMove : MonoBehaviour
{
    [SerializeField] Transform _Hero;
    Transform _Monster;
    [SerializeField] float _speed;
    [SerializeField] float damage;
    public int _health = 10;
    float time = 2;
    public float currenttime ;

    private void Start()
    {
        
        _Monster = transform;
    }
    void Update()
    {
        currenttime += Time.deltaTime;
        if (Vector3.Distance(_Hero.position, _Monster.position) < 5f && Vector3.Distance(_Hero.position, _Monster.position) > 1.1f)
        {
            follow();
        }
        else  
        {
            if (currenttime >= time)
            {

                patrol();

                Invoke("Resettime", 1f);
            }
            
        }
    }
    void Resettime()
    {
        currenttime = 0;
    }

    void follow()
    {
        Vector3 move = (_Hero.position - _Monster.position).normalized * _speed;
        _Monster.position = _Monster.position + move * Time.deltaTime;
    }

    void patrol()
    {
        Vector3 random = new Vector3(Random.Range(-10f,10f),0,Random.Range(-10f,10f)).normalized * 0.5f;
        _Monster.position = _Monster.position + random * Time.deltaTime;
        Debug.Log(random);
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

   

    
  
}
