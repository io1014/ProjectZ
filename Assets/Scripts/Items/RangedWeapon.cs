using UnityEngine;

public class RangedWeapon : ItemParent, IItem
{
    // ������ �Ӽ��� ������ �����ϴ� ��ũ��Ʈ
    string _name = "Pistol";         // �����̸�
    float _weight = 1.5f;            // ����
    int _attackDamage = 1;           // ���ݷ�
    float _range = 3f;               // �����Ÿ�
    float _reloadTime = 1.5f;        // ������ �ð�
    float _bulletSpeed = 50f;        // ź �ӵ�
    bool _isReloading = false;       // ������ ����
    int _magAmmo = 30;               // źȯ ��
    public bool _isEquipped = false; // ���� ����

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
            // źȯ ���� 0�̸� ������
            Reload();
        }

        if (_isReloading)
        {
            // ������ ���� �� �߻��� �� ����
            Debug.Log(" ������ ��, �߻��� �� �����ϴ�. ");
            return;
        }

        GameObject bullet = Instantiate(_bulletPrefab);                               // źȯ ����
        bullet.GetComponent<Bullet>().SetDamage(_attackDamage);                       // Pistol�� ���ݷ��� Bullet�� ����
        bullet.GetComponent<Bullet>().SetRange(_range);                               // Pistol�� �����Ÿ��� Bullet�� ����
        bullet.GetComponent<Rigidbody>().velocity = transform.forward * _bulletSpeed; // źȯ�� ������ ���ư��� ����� �ӵ�
        bullet.transform.position = transform.position;                               // źȯ�� Pistol�� ��ġ�� �Ҵ�
        _magAmmo--;                                                                   // źȯ ����
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