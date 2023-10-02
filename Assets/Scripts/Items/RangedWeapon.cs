using System;
using System.Collections;
using UnityEngine;
[Serializable]
public enum RangedWeaponType
{
    None,
    Pistol,
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
   

    [SerializeField] GameObject _bulletPrefab;
    [SerializeField] GameObject firePos;
    [SerializeField] MeshRenderer muzzleFlash;
    private void Start()
    {
        muzzleFlash = firePos.GetComponentInChildren<MeshRenderer>();
        muzzleFlash.enabled = false;


    }
    public override void Init(ItemObj data)
    {
        // instantiate ��ġ ã�Ƽ� setStatData����
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
    private void Awake()
    {
       // _itemObj = new ItemObj(_name, EItemType.Weapon, _weight, 1f, 1);
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
            // źȯ ���� 0�̸� ������
            Reload();
        }

        if (_isReloading)
        {
            // ������ ���� �� �߻��� �� ����
            Debug.Log(" ������ ��, �߻��� �� �����ϴ�. ");
            return;
        }
       
        GameObject bullet = Instantiate(_bulletPrefab, firePos.transform.position , firePos.transform.rotation);  
        // źȯ ����
        bullet.GetComponent<Bullet>().SetDamage(_attackDamage);                       // Pistol�� ���ݷ��� Bullet�� ����
        bullet.GetComponent<Bullet>().SetRange(_range);                               // Pistol�� �����Ÿ��� Bullet�� ����
        bullet.GetComponent<Rigidbody>().velocity = transform.forward * _bulletSpeed; // źȯ�� ������ ���ư��� ����� �ӵ�
        bullet.transform.position = transform.position;                               // źȯ�� Pistol�� ��ġ�� �Ҵ�
        _magAmmo--;                                                                   // źȯ ����
        StartCoroutine(ShowMuzzleFlash());
        }

    IEnumerator ShowMuzzleFlash()
    {
        muzzleFlash.enabled = true;
        yield return new WaitForSeconds(0.2f);
        muzzleFlash.enabled = false;
    }
    void Reload()
    {
        // ������ �ϴ� ��
        if (_isReloading || _magAmmo == 30)
        {
            Debug.Log(" �̹� �����Ǿ��ֽ��ϴ�. ");
            return;
        }

        _isReloading = true;
        Debug.Log(" ������ ��... ");

        Invoke("FinishReloading", _reloadTime);
    }
    void FinishReloading()
    {
        // źȯ�� ������ ��
        _magAmmo = 30;
        _isReloading = false;
        Debug.Log(" ������ �Ϸ�! ");
    }
    public void IsEquipped(bool isEquipped) => _isEquipped = isEquipped;
    public void Use()
    {
        IsEquipped(true);
        Debug.Log(_name);
    }
}