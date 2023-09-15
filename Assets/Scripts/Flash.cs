using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flash : MonoBehaviour
{
    [SerializeField] GameObject _flash;
   

   

    void Update()
    {
        


        if (GameObject.Find("Directional Light").GetComponent<DayAndNight>()._isNight == true)
        {
            _flash.SetActive(true);
        }
        else if(GameObject.Find("Directional Light").GetComponent<DayAndNight>()._isNight == false)
        {
   
            _flash.SetActive(false);
        }

        
    }
    
}

