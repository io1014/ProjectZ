using UnityEngine;

public class ExamPlayerInfo : MonoBehaviour
{
    ItemParent _itemParent;

    float _stamina = 100;
    float _speed = 5;
    float _currentHP = 100;
    float _maxHP = 100;
    private void Start()
    {
        _itemParent = new ItemParent();
    }
    void Update()
    {
        //RunAndWalk();
        //StaminaRecovery();
        //Debug.Log(_currentHP);
        if (Input.GetMouseButtonDown(0))
        {
            if(/* ex : �κ��丮���� ���� ��ư�� �����ٰ� �������� �� */true)
            { 
                _itemParent.ItemAction();
                Debug.Log("�������� ������ �����մϴ�. ");
            }
        }
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
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            _speed = 2;
        }
        //������ �ȱ�
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            _speed = 1;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            _speed = 2;
        }
    }
    void StaminaRecovery()
    {
        //���¹̳� �ڿ�ȸ��
        if (_stamina < 100)
            _stamina += 0.1f * Time.deltaTime;
    }
    public void setspeed(float speed)
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
        if (_currentHP <= 0)
        {
            Destroy(gameObject);
        }
    }
    public void IncHp(float incHp)
    {
        _currentHP += incHp;
        if(_currentHP >= 100)
        {
            _currentHP = 100;
        }
        Debug.Log(_currentHP);
    }
}