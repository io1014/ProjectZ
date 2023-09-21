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
    bool blood;
    float time = 0;
    float blinktime = 0.1f;
    float xtime = 0;
    float waittime = 0.2f;
    [SerializeField] Image _fatigueImg;
    [SerializeField] Image _blood;
    [SerializeField] Image _thirsty;
    [SerializeField] Image _hungry;

    private void Start()
    {
      blood = HeroStats._instance.GetComponent<HeroStats>().bloodEnabled;
    }

    void Update()
    {
        if ( blood ==false && time < 7f)
        {
            _blood.color = new Color(1, 1, 1, 1);

        }
        else
        {
            if (xtime < blinktime)
            {
                _blood.color = new Color(1, 1, 1, 1 - xtime * 10);

            }
            else
            {
                _blood.color = new Color(1, 1, 1, (xtime - (waittime * blinktime)) * 10);

                if (xtime > waittime + blinktime * 2)
                {
                    xtime = 0;
                    waittime *= 0.8f;
                    if (waittime < 0.02f)
                    {
                        time = 0;
                        waittime = 0.2f;
                        _blood.gameObject.SetActive(false);
                    }
                }
            }
            xtime += Time.deltaTime;
        }
        time += Time.deltaTime;
    }
}
//    void fatigueChange()
//    {
//        //    _bool ���� _fatigue�� true�̸� ���� ���� ǥ��
//        //    1�ʿ� �ѹ��� ���� ǥ���� ��� �� ���ΰ�?
//        //     if(_fatigue = true)
//        //     {
//        //        _fatigueImg.color = Color.red;
//        //        Invoke("fatigueResetColor", 0.5f);
//        //     }
//        //     return;

//        _fatigueImg.color = Color.red;
//        Invoke("fatigueResetColor", 0.5f);
//    }

//    void fatigueResetColor()
//    {
//        _fatigueImg.color = Color.white;
//        Invoke("fatigueChange",0.5f);
//    }


//    void bleedingChange()
//    {
//        _bleedingImg.color = Color.red;
//        Invoke("bleedingResetColor", 0.5f);
//    }

//    void bleedingResetColor()
//    {
//        _bleedingImg.color = Color.white;
//        Invoke("bleedingChange", 0.5f);
//    }

//    void thirstyChange()
//    { 
//        _thirsty.color = Color.red;
//        Invoke("thirstyResetColor", 0.5f);
//    }
//    void thirstyResetColor()
//    {
//        _thirsty.color = Color.white;
//        Invoke("thirstyChange", 0.5f);
//    }

//    void hungryChange()
//    {
//        _hungry.color = Color.red;
//        Invoke("hungryResetColor", 0.5f);
//    }
//    void hungryResetColor()
//    {
//        _hungry.color = Color.white;
//        Invoke("hungryChange", 0.5f);
//    }
//}
