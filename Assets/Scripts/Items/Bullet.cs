using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    int _damage;
    float _lifetime;              // 탄환 수명시간
    float _timer = 0f;
    // 경과 되어가는 시간 저장
    private void Update()
    {
        // 탄환이 3초가 지나면 사라지는 동작
        _timer += Time.deltaTime; // 경과 시간을 업데이트

        if (_timer >= _lifetime)
        {
            Destroy(gameObject);  // 경과 시간이 수명을 초과하면 탄환을 삭제
        }
    }
    public void SetDamage(int damage)
    {
        // 원거리 무기의 damage값 저장
        _damage = damage;
    }
    public void SetRange(float range)
    {
        // 원거리 무기의 사정거리값 저장
        _lifetime = range;
    }
    private void OnTriggerEnter(Collider other)
    {
        // 총알이 충돌했을 때의 동작
        if(other.CompareTag("Monster"))
        {
           //other.GetComponent<WZombieControll>().GetDamage(_damage);
           Destroy(gameObject);
        }
    }
}
