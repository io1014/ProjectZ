using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    int _damage;
    public void SetDamage(int damage)
    {
        // 원거리 무기의 damage값 저장
        _damage = damage;
    }
    private void OnTriggerEnter(Collider other)
    {
        // 총알이 충돌했을 때의 동작 구현
        if(other.CompareTag("Monster"))
        {
            // 몬스터와 충돌했을 때 데미지를 입힘.
            // other.GetComponent<MonsterMove>().TakeDamage(_damage);
        }
    }
}
