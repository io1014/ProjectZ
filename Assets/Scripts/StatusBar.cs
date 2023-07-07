using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusBar : MonoBehaviour
{
    // Data는 4개 받음 -> HeroStats
    // 받을 변수 : 1. _currentHP 2. _maxHP = 100 3. _stamina  4. _maxStamina = 100
    // 받은 data를 statusBar를 이용하여 나타냄
    // HP는 Canvas HealthStatus Scrollbar size를 조정 (0 ~ 1) : 변경값 _currentHP / _maxHP 
    // Stamina는 Canvas StaminarStatus Scrollbar size 를 조정 (0 ~ 1) : 변경값 _stamina / _maxStamina
    // 0에서 남는 거 조정 필요 (위치 조정)

    [SerializeField] Image _staminaImg;
    [SerializeField] Image _hpImg;
    [SerializeField] GameObject _player;

    

    private void Start()
    {
        // Hp, stamina bar 초기화 
        _staminaImg.fillAmount = 1f;
        _hpImg.fillAmount = 1f;
    }

    
    void Update()
    {
        // 매 프레임 마다 hp, stamina bar 함수 실행
        StaminaChange();
        HpChange();
    }
    void StaminaChange()
    {
        //    float _staminaFillAmount = (_stamina / _maxStamina);  변수 값을 받으면 수정
        float _staminaFillAmount = (40f / 100f); // test용
        _staminaImg.fillAmount = (_staminaFillAmount);

    }

    void HpChange()
    {
        //    float _hpFillAmount = (_currentHP / _maxHP); 변수 값을 받으면 수정
        float _hpFillAmount = (70f / 100f);  // test 용
        _hpImg.fillAmount = (_hpFillAmount);

    }

    
}
