using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    int _damage;
    float _lifetime;              // źȯ ����ð�
    float _timer = 0f;
    // ��� �Ǿ�� �ð� ����
    private void Update()
    {
        // źȯ�� 3�ʰ� ������ ������� ����
        _timer += Time.deltaTime; // ��� �ð��� ������Ʈ

        if (_timer >= _lifetime)
        {
            Destroy(gameObject);  // ��� �ð��� ������ �ʰ��ϸ� źȯ�� ����
        }
    }
    public void SetDamage(int damage)
    {
        // ���Ÿ� ������ damage�� ����
        _damage = damage;
    }
    public void SetRange(float range)
    {
        // ���Ÿ� ������ �����Ÿ��� ����
        _lifetime = range;
    }
    private void OnTriggerEnter(Collider other)
    {
        // �Ѿ��� �浹���� ���� ����
        if(other.CompareTag("Monster"))
        {
           //other.GetComponent<WZombieControll>().GetDamage(_damage);
           Destroy(gameObject);
        }
    }
}
