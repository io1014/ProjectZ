using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : MonoBehaviour
{
    // 무기의 속성과 동작을 관리하는 스크립트
    string _name = "Pistol";        // 무기이름
    float _weight = 1.5f;           // 무게
    bool _equippedOneHand = true;   // 장착 여부
    int _durability = 10;           // 내구도
    int _maxDurability = 10;        // 최대 내구도
    int _attackDamage = 1;          // 공격력
    float _range = 6;               // 사정거리
    float _reload = 1.5f;           // 재장전 시간
    float _bulletSpeed = 100f;      // 탄 속도

    GameObject _bulletPrefab;

    void Shoot()
    {
        GameObject bullet = Instantiate(_bulletPrefab);                               // 탄환 생성
        bullet.GetComponent<Bullet>().SetDamage(_attackDamage);                       // Pistol의 공격력을 Bullet에 전달
        bullet.GetComponent<Rigidbody>().velocity = transform.forward * _bulletSpeed; // 탄환이 앞으로 날아가는 속도
    }
}

//public class BowData
//{
//    // Sprite  asset resource
//    // string
//    // distance
//    // damage
//    // 내구도
//    // 
//}
