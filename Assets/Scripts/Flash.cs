using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flash : MonoBehaviour
{

   
   

    void Update()
    {
        


        if (GameObject.Find("Directional Light").GetComponent<DayAndNight>()._isNight == true)
        {
            Debug.Log("���Դϴ�.");
            gameObject.SetActive(true);
        }
        else if(GameObject.Find("Directional Light").GetComponent<DayAndNight>()._isNight == false)
        {
            Debug.Log("���Դϴ�.");
            gameObject.SetActive(false);
        }

        
    }
    
}

