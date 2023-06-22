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
        // player의 피가 1만큼 깎인다.
        // player의 속도가 1만큼 느려진다.
        // player는 출혈 UI가 생긴다.
        // monster의 피가 1만큼 깎인다.
        // monster의 속도가 1만큼 느려진다.
        // player가 출혈 상태이상에 걸린다.
        if(other.gameObject == _player)
        {
            // 들어온 충돌체가 플레이어일 경우
            HeroStats HeroStat = _player.GetComponent<HeroStats>();
            if(HeroStat != null)
            {
                //HeroStat.DecreaseHealth(1);     // 플레이어의 피가 1만큼 깎임
                //HeroStat.DecreaseSpeed(1);      // 플레이어의 속도가 1만큼 깎임
                //HeroStat.Bleeding(true);        // 플레이어가 출혈 상태이상을 가짐
            }
        }

        if(other.gameObject == _monster)
        {
            //MonsterInfo MonsterStat = _monster.GetComponent<MonsterInfo>();
            //if(MonsterStat != null)
            //{
            //    MonsterStat.DecreaseHealth(1);      // 몬스터의 피가 1만큼 깎임
            //    MonsterStat.DecreaseSpeed(1);       // 몬스터의 속도가 1만큼 깎임
        }
    }
}