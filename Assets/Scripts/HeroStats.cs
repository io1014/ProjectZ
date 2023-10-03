using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    public float _currentHP;

    private void Awake()
    {
        _instance = this;
    }
    private void Start()
    {
        _currentHP = _MaxHP;
        HpChange();
        StaminaChange();
    }

    void Update()
    {
        RunAndWalk();
        StaminaRecovery();
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
        //달리기
        if (Input.GetKey(KeyCode.LeftControl) && _stamina > 0)
        {
            _speed = 5;

            _stamina -= 20 * Time.deltaTime;
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
    private void OnTriggerEnter(Collider other) // 데미지
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
        if (_currentHP <= 0)
        {
            PlayerDie();
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
    void PlayerDie()
    {
        SceneManager.LoadScene("Gameover");
    }
}


