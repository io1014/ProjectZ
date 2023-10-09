using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestInven : MonoBehaviour
{

    [SerializeField] GameObject questInven;
    [SerializeField] GameObject basicInven;



    public void QuestToDisappear()
    {
        questInven.SetActive(false);
    }

    public void BasicToDisappear()
    {
        basicInven.SetActive(false);
    }



}
