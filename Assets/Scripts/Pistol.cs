using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : MonoBehaviour
{
    // ������ �Ӽ��� ������ �����ϴ� ��ũ��Ʈ
    string _name = "Pistol";        // �����̸�
    float _weight = 1.5f;           // ����
    bool _equippedOneHand = true;   // ���� ����
    int _durability = 10;           // ������
    int _maxDurability = 10;        // �ִ� ������
    int _attackDamage = 1;          // ���ݷ�
    float _range = 6;               // �����Ÿ�
    float _reload = 1.5f;           // ������ �ð�
    float _bulletSpeed = 100f;      // ź �ӵ�

    GameObject _bulletPrefab;

    void Shoot()
    {
        GameObject bullet = Instantiate(_bulletPrefab);                               // źȯ ����
        bullet.GetComponent<Bullet>().SetDamage(_attackDamage);                       // Pistol�� ���ݷ��� Bullet�� ����
        bullet.GetComponent<Rigidbody>().velocity = transform.forward * _bulletSpeed; // źȯ�� ������ ���ư��� �ӵ�
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
