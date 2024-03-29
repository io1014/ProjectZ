using System;
using System.Collections;
using UnityEngine;

[Serializable]
public enum RangedWeaponType
{
    None,
    Pistol,
    Rifle,
    Shotgun,
}
public class RangedWeapon : ItemParent, IItem
{
    string _name = "";
    float _weight;
    int _attackDamage;
    float _range;
    float _reloadTime;
    float _bulletSpeed;
    int _magAmmo;
    bool _isReloading = false;
    bool _isEquipped = false;
    public RangedWeaponType _rwType;
    bool mousepos = true;
    AudioSource _audio;
    

    [SerializeField] GameObject _bulletPrefab;
    [SerializeField] GameObject firePos;
    [SerializeField] MeshRenderer muzzleFlash;
    [SerializeField] AudioClip fire;
    Transform PlayerTr;
    
    private void Start()
    {
        PlayerTr = GameObject.FindWithTag("Hero").GetComponent<Transform>();
        muzzleFlash = firePos.GetComponentInChildren<MeshRenderer>();
        muzzleFlash.enabled = false;
        _audio = GetComponent<AudioSource>();
    }
    public override void Init(ItemObj data)
    {
        // instantiate 위치 찾아서 setStatData실행
        RangedWeaponData rd = (RangedWeaponData)data;
        _itemObj = data;
        _name = data._name;
        _weight = data._weight;

        _attackDamage = rd._attackDamage;
        _range = rd._range;
        _reloadTime = rd._reloadTime;
        _bulletSpeed = rd._bulletSpeed;
        _magAmmo = rd._magAmmo;
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
        mouseposition();
    }
    void mouseposition() // 인벤토리를 누르면 총알이 같이나가는거 방지
    {

        Vector3 mpos = Input.mousePosition;
        Vector3 cpoint = Camera.main.ScreenToWorldPoint(mpos);
        
        if(cpoint.y >  77.35)
        {
            mousepos = false;
        }
        else
        {
            mousepos = true;
        }
    }
    void Shoot()
    {
        //if (_magAmmo <= 0 && _isReloading == false)
        //{
        //    // 탄환 수가 0이면 재장전
        //    Reload();    
        //}

        if (_isReloading)
        {
            // 재장전 중일 때 발사할 수 없음
            Debug.Log(" 재장전 중, 발사할 수 없습니다. ");
            return;
        }
        if (mousepos == true)
        {
            GameObject bullet = Instantiate(_bulletPrefab, firePos.transform.position, Quaternion.identity);
            _audio.PlayOneShot(fire, 1.0f);
            bullet.transform.up = transform.forward;

            bullet.GetComponent<Bullet>().SetDamage(_attackDamage);                       // Pistol의 공격력을 Bullet에 전달
            bullet.GetComponent<Bullet>().SetRange(_range);                               // Pistol의 사정거리를 Bullet에 전달
            bullet.GetComponent<Rigidbody>().velocity = transform.forward * _bulletSpeed; // 탄환이 앞으로 날아가는 방향과 속도
                                                                                          //bullet.transform.position = transform.position;                               // 탄환에 Pistol의 위치를 할당
            _magAmmo--;                                                                   // 탄환 감소
            StartCoroutine(ShowMuzzleFlash());
        }
    }

    IEnumerator ShowMuzzleFlash()
    {
        muzzleFlash.enabled = true;
        yield return new WaitForSeconds(0.3f);
        muzzleFlash.enabled = false;
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