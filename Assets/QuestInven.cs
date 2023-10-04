using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestInven : MonoBehaviour
{

    [SerializeField] GameObject questInven;
 

   
    public void QuestToDisappear()
    {
        questInven.SetActive(false);
    }


}
