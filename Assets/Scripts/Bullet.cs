using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    int _damage;
    public void SetDamage(int damage)
    {
        // ���Ÿ� ������ damage�� ����
        _damage = damage;
    }
    private void OnTriggerEnter(Collider other)
    {
        // �Ѿ��� �浹���� ���� ���� ����
        if(other.CompareTag("Monster"))
        {
            // ���Ϳ� �浹���� �� �������� ����.
            // other.GetComponent<MonsterMove>().TakeDamage(_damage);
        }
    }
}
