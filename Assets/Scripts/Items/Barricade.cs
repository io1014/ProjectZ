using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barricade : MonoBehaviour
{
    BoxCollider _boxCollider;
    [SerializeField] GameObject _player;
    [SerializeField] GameObject _monster;
    private void OnCollisionEnter(Collision collision)
    {
        _boxCollider = GetComponent<BoxCollider>();
        // player�� �浹�ϸ� �����������ʴ´�.
        // monster�� �浹�ϸ� �����������ʴ´�.
        //
        // �Ǵٸ� ���
        // player�� monster�� gameobject tag�� �ٿ���
        // gameobject tag�� ���� gameobject�� �浹�� ��� �����������ʴ´�.
    }
}
