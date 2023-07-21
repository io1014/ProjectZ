using UnityEngine;

public class WireFence : ItemParent
{
    [SerializeField] GameObject _player;
    ExamMonsterMove _monster;
    float _lastHitTime = 0;
    private void Start()
    {
        _monster = GameObject.FindGameObjectWithTag("Monster").GetComponent<ExamMonsterMove>();
        _lastHitTime = Time.realtimeSinceStartup;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == _player)
        {
            ExamPlayerInfo epi = _player.GetComponent<ExamPlayerInfo>();
            epi.setspeed(1);
        }
        else if(other.gameObject == _monster.gameObject)
        {
            //ExamMonsterMove emm = _monster.GetComponent<ExamMonsterMove>();
            //emm.SetSpeed(1);
            _monster.SetSpeed(1);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        // player의 피가 1만큼 깎인다.
        // player의 속도가 1만큼 느려진다.
        // player는 출혈 UI가 생긴다.
        // monster의 피가 1만큼 깎인다.
        // monster의 속도가 1만큼 느려진다.
        // player가 출혈 상태이상에 걸린다.
        if(_lastHitTime + 2 > Time.realtimeSinceStartup)
        {
            return;
        }
        if ((other.gameObject == _player) && (_player != null))
        {
            // 들어온 충돌체가 플레이어일 경우
            //HeroStat.DecreaseHealth(1); // 플레이어의 피가 1만큼 깎임
            //HeroStat.DecreaseSpeed(1);  // 플레이어의 속도가 1만큼 깎임
            //HeroStat.Bleeding(true);    // 플레이어가 출혈 상태이상을 가짐
            ExamPlayerInfo epi = _player.GetComponent<ExamPlayerInfo>();
            epi.Damage(10);
            Debug.Log(epi.name+"의 체력이 깎입니다. ");
            _lastHitTime = Time.realtimeSinceStartup;
        }

        else if(other.gameObject == _monster.gameObject)
        {
            //MonsterInfo MonsterStat = _monster.GetComponent<MonsterInfo>();
            //if(MonsterStat != null)
            //{
            //    MonsterStat.DecreaseHealth(1);      // 몬스터의 피가 1만큼 깎임
            //    MonsterStat.DecreaseSpeed(1);       // 몬스터의 속도가 1만큼 깎임
            //ExamMonsterMove emm = _monster.GetComponent<ExamMonsterMove>();
            //emm.GetDamage(10);
            _monster.GetDamage(10);
            Debug.Log(_monster.name+"의 체력이 깎입니다. ");
            _lastHitTime = Time.realtimeSinceStartup;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject == _player)
        {
            ExamPlayerInfo epi = _player.GetComponent<ExamPlayerInfo>();
            epi.setspeed(5);
        }
        else if(other.gameObject == _monster.gameObject)
        {
            //ExamMonsterMove emm = _monster.GetComponent<ExamMonsterMove>();
            //emm.SetSpeed(3);
            _monster.SetSpeed(3);
        }
    }
}