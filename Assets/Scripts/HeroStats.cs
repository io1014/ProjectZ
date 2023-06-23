using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroStats : MonoBehaviour
{
    float _stamina = 100;
    int _speed = 2;
    float _currentHP = 100;
    void Update()
    {
        RunAndWalk();
        StaminaRecovery();
        Debug.Log(_currentHP);
    }
    void RunAndWalk()
    {
        //�޸���
        if (Input.GetKey(KeyCode.LeftControl) && _stamina > 0)
        {
            _speed = 5;

            _stamina -= 30 * Time.deltaTime;
        }
        if (_stamina < 0)
        {
            _speed = 2;
        }
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            _speed = 2;
        }
        //������ �ȱ�
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            _speed = 1;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            _speed = 2;
        }
    }
    void StaminaRecovery()
    {
        //���¹̳� �ڿ�ȸ��
        if (_stamina < 100)
            _stamina += 0.1f * Time.deltaTime;
    }
    void setspeed(int speed)
    {
        _speed = speed;
    }
   public int getspeed()
    {
        return _speed;
    }

    public void Damage(float damage)
    {
        _currentHP -=  damage;

    }
}

