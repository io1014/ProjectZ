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
        _capsuleCollider = GetComponent<CapsuleCollider>();
        // player�� �ǰ� 1��ŭ ���δ�.
        // player�� �ӵ��� 1��ŭ ��������.
        // player�� ���� UI�� �����.
        // monster�� �ǰ� 1��ŭ ���δ�.
        // monster�� �ӵ��� 1��ŭ ��������.
    }
}
