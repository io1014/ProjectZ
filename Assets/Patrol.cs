using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    float speed = 0.2f;
    float starttime = 2f;
    float waittime;
    Vector3 moveSpot;
    Vector3 _startPos;
    void Start()
    {
        waittime = starttime;
        _startPos = transform.position;
        moveSpot = new Vector3(Random.Range(-5, 5), 50, Random.Range(-5, 5)) + new Vector3(_startPos.x,0,_startPos.z);
        
    }
    void Update()
    {

        if(Vector3.Distance(transform.position,moveSpot) < 0.5) 
        {
            if(waittime<=0)
            {
                moveSpot = new Vector3(Random.Range(-5,5),50,Random.Range(-5,5)) + new Vector3(_startPos.x, 0, _startPos.z);
                waittime = starttime;
            }
            else
            {
                waittime -= Time.deltaTime;
            }
        }
        else
        {
             transform.position += (moveSpot - transform.position).normalized * speed * Time.deltaTime; ;// Vector3.MoveTowards(transform.position, moveSpot, speed * Time.deltaTime);
        }

        
    }
}
