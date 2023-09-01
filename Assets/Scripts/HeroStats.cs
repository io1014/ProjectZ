using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroStats : GenericSingleton<HeroStats>
{

    [SerializeField] Image _staminaImg;
    [SerializeField] Image _hpImg;
    [SerializeField] GameObject _player;

    float _Maxstamina = 100;
    float _stamina = 100;
    float _speed = 2f;
    float _MaxHP = 100;
    public float _currentHP = 100;

    private void Start()
    {
        // Hp, stamina bar �ʱ�ȭ 
        _staminaImg.fillAmount = 1f;
        _hpImg.fillAmount = 1f;
    }

    void Update()
    {
        RunAndWalk();
        StaminaRecovery();
        StaminaChange();
        HpChange();
        Debug.Log(_currentHP);
    }

    
    void StaminaChange()
    {
        //    float _staminaFillAmount = (_stamina / _maxStamina);  ���� ���� ������ ����
        float _staminaFillAmount = (_stamina / _Maxstamina); // test��
        _staminaImg.fillAmount = (_staminaFillAmount);

    }

    void HpChange()
    {
        //    float _hpFillAmount = (_currentHP / _maxHP); ���� ���� ������ ����
        float _hpFillAmount = (_currentHP / _MaxHP);  // test ��
        _hpImg.fillAmount = (_hpFillAmount);

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
        if (Input.GetKeyUp(KeyCode.LeftControl)) _speed = 2;

        //������ �ȱ�
        if (Input.GetKeyDown(KeyCode.LeftShift)) _speed = 1;

        
        if (Input.GetKeyUp(KeyCode.LeftShift)) _speed = 2;
      
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
    public void IncHp(float incHp)
    {
        _currentHP += incHp;
        if (_currentHP >= 100)
        {
            _currentHP = 100;
        }
        Debug.Log(_currentHP);
    }
}


