using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flash : MonoBehaviour
{

    bool _night;
    private void Start()
    {
        _night = GameObject.Find("Directional Light").GetComponent<DayAndNight>()._isNight;
    }

    void Update()
    {
       
       
        
        if(_night == true)
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }

        
    }
    
}

