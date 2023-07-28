using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieStateIdle : MonoBehaviour
{
    float timer = 0;
    private void OnEnable()
    {
        GetComponent<Animator>().Play("ZombieIdle");
    }
 
    void Update()
    {
        timer += Time.deltaTime;
        if(timer> 2)
        {
            timer = 0;
            Vector3 ranDir = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f));
            transform.rotation = Quaternion.LookRotation(ranDir);
            enabled = false;
            GetComponent<ZombieStatePatroll>().enabled = true; // 상태전이
        }

    }
        
    }
