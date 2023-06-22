using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : MonoBehaviour
{
    // ������ �Ӽ��� ������ �����ϴ� ��ũ��Ʈ
    string _name = "Pistol";        // �����̸�
    float _weight = 1.5f;           // ����
    bool _equippedOneHand = true;   // ���� ����
    int _attackDamage = 1;          // ���ݷ�
    float _range = 3f;              // �����Ÿ�
    float _reloadTime = 1.5f;       // ������ �ð�
    float _bulletSpeed = 100f;      // ź �ӵ�
    bool _isReloading = false;      // ������ ����
    int _magAmmo = 30;              // źȯ ��


    [SerializeField] GameObject _bulletPrefab;


    void Shoot()
    {
        if (_isReloading)
        {
            // ������ ���� �� �߻��� �� ����
            Debug.Log(" ������ ��, �߻��� �� �����ϴ�. ");
            return;
        }

        if (_magAmmo <= 0)
        {
            // źȯ ���� 0�̸� ������
            Reload();
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
