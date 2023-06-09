using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawn : MonoBehaviour
{
    [SerializeField] Transform _hero;
    [SerializeField] GameObject Monster;
    List<GameObject> _monsterList = new List<GameObject>();
        float spawnCount = 50;

    Vector3 _patrolTarget;


    private void Start()
    {
        _patrolTarget= transform.position;
        setRandomPosition();
    }

    void setRandomPosition()
    {
        float x = Random.Range(transform.position.x - 5f, transform.position.x + 5f);
        float y = Random.Range(transform.position.z - 5f, transform.position.z + 5f);

        _patrolTarget.x = x;
        _patrolTarget.z = y;
    }

    void Update()
    {

        spawn();
        Move();
    }

    void Move()
    {
        if (Vector3.Distance(transform.position, _patrolTarget) < 0.1f)
        {
            setRandomPosition();
        }
        else
        {
            Vector3 move = (transform.position - _patrolTarget).normalized;
            _patrolTarget = _patrolTarget + move;
        }
    }

    void spawn()
    {
        if (spawnCount > 0 & spawnCount <= 50)
        {
            GameObject temp =  Instantiate(Monster);
            temp.transform.position = transform.position;
            temp.GetComponent<MonsterMove>().Init(_hero);
            _monsterList.Add(temp);
            spawnCount--;
        }
    }
}
