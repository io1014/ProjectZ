using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireFence : MonoBehaviour
{
    CapsuleCollider _capsuleCollider;
    [SerializeField] GameObject _player;
    [SerializeField] GameObject _monster;
    private void OnTriggerEnter(Collider other)
    {
        // player�� �ǰ� 1��ŭ ���δ�.
        // player�� �ӵ��� 1��ŭ ��������.
        // player�� ���� UI�� �����.
        // monster�� �ǰ� 1��ŭ ���δ�.
        // monster�� �ӵ��� 1��ŭ ��������.
        // player�� ���� �����̻� �ɸ���.
        if(other.gameObject == _player)
        {
            // ���� �浹ü�� �÷��̾��� ���
            HeroStats HeroStat = _player.GetComponent<HeroStats>();
            if(HeroStat != null)
            {
                //HeroStat.DecreaseHealth(1);     // �÷��̾��� �ǰ� 1��ŭ ����
                //HeroStat.DecreaseSpeed(1);      // �÷��̾��� �ӵ��� 1��ŭ ����
                //HeroStat.Bleeding(true);        // �÷��̾ ���� �����̻��� ����
            }
        }

        if(other.gameObject == _monster)
        {
            //MonsterInfo MonsterStat = _monster.GetComponent<MonsterInfo>();
            //if(MonsterStat != null)
            //{
            //    MonsterStat.DecreaseHealth(1);      // ������ �ǰ� 1��ŭ ����
            //    MonsterStat.DecreaseSpeed(1);       // ������ �ӵ��� 1��ŭ ����
        }
    }
}