using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bread : MonoBehaviour
{
    string _name = "Bread";         // �����̸�
    float _weight = 0.1f;           // ����
    float _increaseHP = 1f;         // ü�� ȸ�� ����
    float _increaseFull = 1f;       // ��θ� ����
    bool _isAte = false;            // �� �Ծ����� ����
    ItemObj _itemInfo;              // ������ ����

    public void Eat()
    {
        if(!_isAte)
        {
            //Player.IncreaseHealth(1) // �÷��̾��� ������ �ִ� ��ũ��Ʈ�� ���ڸ� �༭ �Ǹ� ä��
            _isAte = true;
            Invoke("DestroyBread", 2f);
        }
        _isAte = false;
    }
    void DestroyBread()
    {
        Destroy(gameObject);
    }
}
