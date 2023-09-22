using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroStats : GenericSingleton<HeroStats>

{

   
    [SerializeField] GameObject _player;
    [SerializeField] Slider _HPSlider;
    [SerializeField] Slider _staminaSlider;
    [SerializeField] Image[] Conditions;
    float blood;
    public bool bloodEnabled = false;

    float _Maxstamina = 100;
    float _stamina = 100;
    float _speed = 2f;
    float _MaxHP = 100;
    public float _currentHP = 100;

    private void Awake()
    {
        _instance = this;
    }
    private void Start()
    {
     
        HpChange();
        StaminaChange();
    }

    void Update()
    {
        RunAndWalk();
        StaminaRecovery();
        //Debug.Log(_currentHP);
        HpChange();
        StaminaChange();
        blood = Random.Range(1, 10);
    }
    
    void HpChange()
    {
        _HPSlider.maxValue = _MaxHP;
        _HPSlider.value = _currentHP;
       
    }
    void StaminaChange()
    {
        _staminaSlider.maxValue = _Maxstamina;
        _staminaSlider.value = _stamina;
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
            _stamina += 1f * Time.deltaTime;
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
        _currentHP -= damage;
    }

    private void OnTriggerEnter(Collider other) // ������
    {
        if (blood < 10 && _currentHP >= 0 && other.CompareTag("Hand"))
        {
            _currentHP -= 10;

        }
        else if(blood == 10 && _currentHP >= 0 && other.CompareTag("Hand"))
        {
            bloodEnabled = true;
            _currentHP -= 10;
        }
    }
    public void bloodUUI()
    {
        if(bloodEnabled == true)
        {
            Conditions[3].gameObject.SetActive(true);
        }

    }
    public void IncHp(float incHp)
    {
        _currentHP += incHp;
        if (_currentHP >= 100)
        {
            _currentHP = 100;
        }
    }
}


