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
                //Player.IncreaseHealth(1) // �÷��̾��� ������ �ִ� ��ũ��Ʈ�� ���ڸ� �༭ �Ǹ� ä��
                Destroy(_bread);
            }
        }
    }
}
