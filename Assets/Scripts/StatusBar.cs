using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusBar : MonoBehaviour
{
    // Data�� 4�� ���� -> HeroStats
    // ���� ���� : 1. _currentHP 2. _maxHP = 100 3. _stamina  4. _maxStamina = 100
    // ���� data�� statusBar�� �̿��Ͽ� ��Ÿ��
    // HP�� Canvas HealthStatus Scrollbar size�� ���� (0 ~ 1) : ���氪 _currentHP / _maxHP 
    // Stamina�� Canvas StaminarStatus Scrollbar size �� ���� (0 ~ 1) : ���氪 _stamina / _maxStamina
    // 0���� ���� �� ���� �ʿ� (��ġ ����)

    [SerializeField] Image _staminaImg;
    [SerializeField] Image _hpImg;
    [SerializeField] GameObject _player;

    

    private void Start()
    {
        // Hp, stamina bar �ʱ�ȭ 
        _staminaImg.fillAmount = 1f;
        _hpImg.fillAmount = 1f;
    }

    
    void Update()
    {
        // �� ������ ���� hp, stamina bar �Լ� ����
        StaminaChange();
        HpChange();
    }
    void StaminaChange()
    {
        //    float _staminaFillAmount = (_stamina / _maxStamina);  ���� ���� ������ ����
        float _staminaFillAmount = (40f / 100f); // test��
        _staminaImg.fillAmount = (_staminaFillAmount);

    }

    void HpChange()
    {
        //    float _hpFillAmount = (_currentHP / _maxHP); ���� ���� ������ ����
        float _hpFillAmount = (70f / 100f);  // test ��
        _hpImg.fillAmount = (_hpFillAmount);

    }

    
}
