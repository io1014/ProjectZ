using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_playerCondition : MonoBehaviour

{

    // �÷��̾��� ������� 4�������� ��Ÿ��. 
    // 1. �Ƿ�(fatigue) 2 ����(bleeding) 3. �񸶸� (thirsty) 4. ����� (hungry)
    // �� ���°� Ȱ��ȭ �Ǹ� (false -> true�� ����) �� ui�� ������ red�� ����ǥ��
    // ���� ȸ���� �Ǹ� (true -> false) ���� ����

    [SerializeField] Image _fatigueImg;
    [SerializeField] Image _bleedingImg;
    [SerializeField] Image _thirsty;
    [SerializeField] Image _hungry;

    private void Start()
    {
        fatigueChange();
        bleedingChange();
        thirstyChange();
        hungryChange();
    }

    void Update()
    {

    }

    void fatigueChange()
    {
        //    _bool ���� _fatigue�� true�̸� ���� ���� ǥ��
        //    1�ʿ� �ѹ��� ���� ǥ���� ��� �� ���ΰ�?
        //     if(_fatigue = true)
        //     {
        //        _fatigueImg.color = Color.red;
        //        Invoke("fatigueResetColor", 0.5f);
        //     }
        //     return;

        _fatigueImg.color = Color.red;
        Invoke("fatigueResetColor", 0.5f);
    }

    void fatigueResetColor()
    {
        _fatigueImg.color = Color.white;
        Invoke("fatigueChange",0.5f);
    }


    void bleedingChange()
    {
        _bleedingImg.color = Color.red;
        Invoke("bleedingResetColor", 0.5f);
    }

    void bleedingResetColor()
    {
        _bleedingImg.color = Color.white;
        Invoke("bleedingChange", 0.5f);
    }

    void thirstyChange()
    { 
        _thirsty.color = Color.red;
        Invoke("thirstyResetColor", 0.5f);
    }
    void thirstyResetColor()
    {
        _thirsty.color = Color.white;
        Invoke("thirstyChange", 0.5f);
    }

    void hungryChange()
    {
        _hungry.color = Color.red;
        Invoke("hungryResetColor", 0.5f);
    }
    void hungryResetColor()
    {
        _hungry.color = Color.white;
        Invoke("hungryChange", 0.5f);
    }
}
