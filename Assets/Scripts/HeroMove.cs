using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroMove : MonoBehaviour
{

    float _speed = 2;
    float _stamina = 100;
    private void FixedUpdate()
    {
        //���� ������
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(x, 0,y) *Time.deltaTime *_speed);
    }
    void Update()
    {
        RunAndWalk();
        StaminaRecovery();
    }

    void RunAndWalk()
    {
        //�޸���
        if (Input.GetKey(KeyCode.LeftControl) && _stamina > 0)
        {
            _speed = 5;

            _stamina -= 30  *Time.deltaTime;
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
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            _speed = 1;
        }
        if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            _speed = 2;
        }
    }
    void StaminaRecovery()
    {
        //���¹̳� �ڿ�ȸ��
        if(_stamina < 100)
        _stamina += 0.1f *Time.deltaTime;
    }
}
