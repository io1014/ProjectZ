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
        _bread = GetComponent<GameObject>();
    }
    void Update()
    {
        /*if(// �κ��丮���� ���� '�Ա�' ��ư�� ������)
        {
            bread�� �������� player�� ü���� 1��ŭ ä������.
        }*/
    }
}
