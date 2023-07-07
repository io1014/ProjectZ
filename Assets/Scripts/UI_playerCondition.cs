using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_playerCondition : MonoBehaviour

{

    // 플레이어의 컨디션은 4개항으로 나타냄. 
    // 1. 피로(fatigue) 2 출혈(bleeding) 3. 목마름 (thirsty) 4. 배고픔 (hungry)
    // 각 상태가 활성화 되면 (false -> true로 변경) 각 ui의 색상을 red로 점멸표시
    // 상태 회복이 되면 (true -> false) 점멸 중지

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
        //    _bool 변수 _fatigue가 true이면 색깔 점멸 표시
        //    1초에 한번씩 점멸 표현을 어떻게 할 것인가?
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
