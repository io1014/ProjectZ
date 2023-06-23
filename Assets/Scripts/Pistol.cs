using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : MonoBehaviour
{
    // ������ �Ӽ��� ������ �����ϴ� ��ũ��Ʈ
    string _name = "Pistol";        // �����̸�
    float _weight = 1.5f;           // ����
    int _attackDamage = 1;          // ���ݷ�
    float _range = 3f;              // �����Ÿ�
    float _reloadTime = 1.5f;       // ������ �ð�
    float _bulletSpeed = 100f;      // ź �ӵ�
    bool _isReloading = false;      // ������ ����
    int _magAmmo = 30;              // źȯ ��
    public bool _equipped = false;         // ���� ����


    [SerializeField] GameObject _bulletPrefab;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }
    }
    void Shoot()
    {
        if (_magAmmo <= 0 &&  _isReloading == false)
        {
            // źȯ ���� 0�̸� ������
            Reload();
        }

        if (_isReloading)
        {
            // ������ ���� �� �߻��� �� ����
            Debug.Log(" ������ ��, �߻��� �� �����ϴ�. ");
            return;
        }

        GameObject bullet = Instantiate(_bulletPrefab);                               // źȯ ����
        bullet.GetComponent<Bullet>().SetDamage(_attackDamage);                       // Pistol�� ���ݷ��� Bullet�� ����
        bullet.GetComponent<Bullet>().SetRange(_range);                               // Pistol�� �����Ÿ��� Bullet�� ����
        bullet.GetComponent<Rigidbody>().velocity = transform.forward * _bulletSpeed; // źȯ�� ������ ���ư��� ����� �ӵ�
        bullet.transform.position = transform.position;                               // źȯ�� Pistol�� ��ġ�� �Ҵ�
        _magAmmo--;                                                                   // źȯ ����
    }
    void Reload()
    {
        // ������ �ϴ� ��
        if (_isReloading || _magAmmo == 30)
        {
            Debug.Log(" �̹� �����Ǿ��ֽ��ϴ�. ");
            return;
        }

        _isReloading = true;
        Debug.Log(" ������ ��... ");

        Invoke("FinishReloading", _reloadTime);
    }
    void FinishReloading()
    {
        // źȯ�� ������ ��
        _magAmmo = 30;
        _isReloading = false;
        Debug.Log(" ������ �Ϸ�! ");
    }
    void equipped()
    {
        if(_equipped)
        {
            GameObject Pistol = Instantiate(gameObject);
            _equipped = false;
        }
    }
}

//public class BowData
//{
//    // Sprite  asset resource
//    // string
//    // distance
//    // damage
//    // ������
//    // 
//}
