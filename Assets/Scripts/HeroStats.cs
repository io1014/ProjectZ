using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroStats : GenericSingleton<HeroStats>
{

    float _Maxstamina = 100;
    float _stamina = 100;
    float _speed = 0.2f;
    float _MaxHP = 100;
    float _currentHP = 100;

    void Update()
    {
        RunAndWalk();
        StaminaRecovery();
        Debug.Log(_currentHP);
    }
    void RunAndWalk()
    {
        //달리기
        if (Input.GetKey(KeyCode.LeftControl) && _stamina > 0)
        {
            _speed = 5;

            _stamina -= 30 * Time.deltaTime;
        }
        if (_stamina < 0)
        {
            _speed = 2;
        }
        if (Input.GetKeyUp(KeyCode.LeftControl)) _speed = 2;

        //느리게 걷기
        if (Input.GetKeyDown(KeyCode.LeftShift)) _speed = 1;

        
        if (Input.GetKeyUp(KeyCode.LeftShift)) _speed = 2;
      
    }
    void StaminaRecovery()
    {
        //스태미너 자연회복
        if (_stamina < 100)
            _stamina += 0.1f * Time.deltaTime;
    }
    void setspeed(int speed)
    {
        _speed = speed;
    }
   public float getspeed()
    {
        return _speed;
    }

    public void Damage(float damage)
    {
        _currentHP -=  damage;
    }

    private void OnTriggerEnter(Collider other)
    {
        if ( _currentHP >= 0 && other.CompareTag("Hand"))
        {
            _currentHP -= 10;

        }
    }
}


