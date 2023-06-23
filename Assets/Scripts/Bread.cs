using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bread : MonoBehaviour
{
    GameObject _bread;
    [SerializeField] Image _player;

    private void Start()
    {
        _bread = gameObject;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            HeroStats Player = other.GetComponent<HeroStats>();
            if(Player != null)
            {
                //Player.IncreaseHealth(1) // 플레이어의 정보가 있는 스크립트에 인자를 줘서 피를 채움
                Destroy(_bread);
            }
        }
    }
}
