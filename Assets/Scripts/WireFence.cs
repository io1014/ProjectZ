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
        // player�� �ǰ� 1��ŭ ���δ�.
        // player�� �ӵ��� 1��ŭ ��������.
        // player�� ���� UI�� �����.
        // monster�� �ǰ� 1��ŭ ���δ�.
        // monster�� �ӵ��� 1��ŭ ��������.
        // player�� ���� �����̻� �ɸ���.
        if(_lastHitTime + 2 > Time.realtimeSinceStartup)
        {
            return;
        }
        if ((other.gameObject == _player) && (_player != null))
        {
            // ���� �浹ü�� �÷��̾��� ���
            //HeroStat.DecreaseHealth(1); // �÷��̾��� �ǰ� 1��ŭ ����
            //HeroStat.DecreaseSpeed(1);  // �÷��̾��� �ӵ��� 1��ŭ ����
            //HeroStat.Bleeding(true);    // �÷��̾ ���� �����̻��� ����
            ExamPlayerInfo epi = _player.GetComponent<ExamPlayerInfo>();
            epi.Damage(10);
            Debug.Log(epi.name+"�� ü���� ���Դϴ�. ");
            _lastHitTime = Time.realtimeSinceStartup;
        }

        else if(other.gameObject == _monster.gameObject)
        {
            //MonsterInfo MonsterStat = _monster.GetComponent<MonsterInfo>();
            //if(MonsterStat != null)
            //{
            //    MonsterStat.DecreaseHealth(1);      // ������ �ǰ� 1��ŭ ����
            //    MonsterStat.DecreaseSpeed(1);       // ������ �ӵ��� 1��ŭ ����
            //ExamMonsterMove emm = _monster.GetComponent<ExamMonsterMove>();
            //emm.GetDamage(10);
            _monster.GetDamage(10);
            Debug.Log(_monster.name+"�� ü���� ���Դϴ�. ");
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