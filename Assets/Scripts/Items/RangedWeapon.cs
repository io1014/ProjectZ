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
    void mouseposition() // �κ��丮�� ������ �Ѿ��� ���̳����°� ����
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
        //    // źȯ ���� 0�̸� ������
        //    Reload();    
        //}

        if (_isReloading)
        {
            // ������ ���� �� �߻��� �� ����
            Debug.Log(" ������ ��, �߻��� �� �����ϴ�. ");
            return;
        }
        if (mousepos == true)
        {
            GameObject bullet = Instantiate(_bulletPrefab, firePos.transform.position, Quaternion.identity);
            _audio.PlayOneShot(fire, 1.0f);
            bullet.transform.up = transform.forward;

            bullet.GetComponent<Bullet>().SetDamage(_attackDamage);                       // Pistol�� ���ݷ��� Bullet�� ����
            bullet.GetComponent<Bullet>().SetRange(_range);                               // Pistol�� �����Ÿ��� Bullet�� ����
            bullet.GetComponent<Rigidbody>().velocity = transform.forward * _bulletSpeed; // źȯ�� ������ ���ư��� ����� �ӵ�
                                                                                          //bullet.transform.position = transform.position;                               // źȯ�� Pistol�� ��ġ�� �Ҵ�
            _magAmmo--;                                                                   // źȯ ����
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