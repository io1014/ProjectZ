using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    
    Transform _tele2;
    GameObject _Player;

    private void Start()
    {
        //_tele1 = GameObject.Find("Tele").GetComponent<Transform>();
        _tele2 = GameObject.Find("Tele2").GetComponent<Transform>();
        _Player = GameObject.Find("Player").GetComponent<GameObject>();
    }

    

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Player")
        {
            Debug.Log("Collision");
            Invoke("TP", 5f);
        }
    }

    void TP()
    {
        _Player.transform.position = _tele2.transform.position;
    }
}
