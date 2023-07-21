using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExamPlayerInfo : MonoBehaviour
{
    [SerializeField] GameObject _pistolPrefab;
    [SerializeField] GameObject _breadPrefab;
    [SerializeField] GameObject _bandPrefab;
    GameObject _pistol;
    GameObject _bread;
    GameObject _band;
    ItemParent _itemParent;

    float _stamina = 100;
    float _speed = 5;
    float _currentHP = 100;
    float _maxHP = 100;
    private void Start()
    {
        ItemParent ip = new ItemParent();
        _itemParent = ip;
    }
    void Update()
    {
        //RunAndWalk();
        //StaminaRecovery();
        //Debug.Log(_currentHP);
        if (Input.GetMouseButtonDown(0))
        {
            CreatPistol();
        }
    }
    void CreatPistol()
    {
        if (_pistol == null)
        {
            _pistol = Instantiate(_pistolPrefab);
            Pistol pistolComponont = _pistol.GetComponent<Pistol>();
            if (_pistol != null)
            {
                _itemParent.SetPistol(pistolComponont);
                _itemParent.Equip();
            }
        }
    }
    void CreatBread()
    {
        // HP�� 100 �̻��ϰ�� �κ��丮���� '�Ա�' ��� ������ Ȱ��ȭ ���� �ʰ� �� ��
        if (_bread == null)
        {
            _bread = Instantiate(_breadPrefab);
            Bread breadComponont = _bread.GetComponent<Bread>();
            if (breadComponont != null)
            {
                _itemParent.SetBread(breadComponont);
            }
            _itemParent.Eat();
        }
    }
    void CreatBand()
    {
        if (_band == null)
        {
            _band = Instantiate(_bandPrefab);
            Bandage bandComponont = _band.GetComponent<Bandage>();
            // �ش� ���� �� ����
            if(bandComponont != null)
            {
                _itemParent.SetBand(bandComponont);
            }
            _itemParent.Heal();
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