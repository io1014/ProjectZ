using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawn : MonoBehaviour
{
    [SerializeField] Transform _hero;
    [SerializeField] GameObject[] Monster;
    [SerializeField] Transform[] spawnPoints;
    List<GameObject> _monsterList = new List<GameObject>();
    float spawnCount = 100;
    float time = 0.2f, spawntime;

    
     

    Vector3 _patrolTarget;


    private void Start()
    {
        spawntime = time;
        _patrolTarget= transform.position;
      
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
        //setRandomPosition();
        spawntime -= Time.deltaTime;
        spawn();
        //Move();
        transform.position = _patrolTarget;
    }

    //void Move()
    //{
    //    if (Vector3.Distance(transform.position, _patrolTarget) < 0.1f)
    //    {
    //        setRandomPosition();
    //    }
    //    else
    //    {
    //        Vector3 move = (transform.position - _patrolTarget).normalized;
    //        _patrolTarget = _patrolTarget + move;
    //    }
    //}

    void spawn()
    {
        if (spawnCount > 0 & spawnCount <= 50 && spawntime < 0)
        {
            GameObject temp = Instantiate(Monster[Random.Range(0,Monster.Length)], spawnPoints[Random.Range(0, spawnPoints.Length)].transform.position, Quaternion.identity);
            temp.transform.position += new Vector3(Random.Range(-10,10f), 0, Random.Range(-10,10f));
            //temp.GetComponent<MonsterMove>().Init(_hero);
            //temp.GetComponent<Patrol>().Init(_hero);
            //temp.GetComponent<ZombieStatePatroll>().Init(_hero);

            _monsterList.Add(temp);
            spawnCount--;
            spawntime = time;
        }
        if(spawnCount == 0)
        {
            Destroy(gameObject);
        }
    }
}
