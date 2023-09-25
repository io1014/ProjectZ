using UnityEngine;

public class RangedWeapon : ItemParent, IItem
{
    // 무기의 속성과 동작을 관리하는 스크립트
    string _name = "Pistol";         // 무기이름
    float _weight = 1.5f;            // 무게
    int _attackDamage = 1;           // 공격력
    float _range = 3f;               // 사정거리
    float _reloadTime = 1.5f;        // 재장전 시간
    float _bulletSpeed = 50f;        // 탄 속도
    bool _isReloading = false;       // 재장전 여부
    int _magAmmo = 30;               // 탄환 수
    public bool _isEquipped = false; // 장착 여부

    [SerializeField] GameObject _bulletPrefab;
    private void Awake()
    {
        _itemObj = new ItemObj(_name, EItemType.Weapon, _weight, 1f, 1);
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(_isEquipped)
            {
                Shoot();
            }
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }
    }
    void Shoot()
    {
        if (_magAmmo <= 0 && _isReloading == false)
        {
            // 탄환 수가 0이면 재장전
            Reload();
        }

        if (_isReloading)
        {
            // 재장전 중일 때 발사할 수 없음
            Debug.Log(" 재장전 중, 발사할 수 없습니다. ");
            return;
        }

        GameObject bullet = Instantiate(_bulletPrefab);                               // 탄환 생성
        bullet.GetComponent<Bullet>().SetDamage(_attackDamage);                       // Pistol의 공격력을 Bullet에 전달
        bullet.GetComponent<Bullet>().SetRange(_range);                               // Pistol의 사정거리를 Bullet에 전달
        bullet.GetComponent<Rigidbody>().velocity = transform.forward * _bulletSpeed; // 탄환이 앞으로 날아가는 방향과 속도
        bullet.transform.position = transform.position;                               // 탄환에 Pistol의 위치를 할당
        _magAmmo--;                                                                   // 탄환 감소
    }
    void Reload()
    {
        // 재장전 하는 중
        if (_isReloading || _magAmmo == 30)
        {
            Debug.Log(" 이미 장전되어있습니다. ");
            return;
        }

        _isReloading = true;
        Debug.Log(" 재장전 중... ");

        Invoke("FinishReloading", _reloadTime);
    }
    void FinishReloading()
    {
        // 탄환이 재장전 됨
        _magAmmo = 30;
        _isReloading = false;
        Debug.Log(" 재장전 완료! ");
    }
    public void IsEquipped(bool isEquipped) => _isEquipped = isEquipped;
    public void Use()
    {
        IsEquipped(true);
        Debug.Log(_name);
    }
}