using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakGlass : MonoBehaviour
{
    BoxCollider _boxCollider;
    [SerializeField] GameObject _player;
    [SerializeField] GameObject _monster;
    private void OnTriggerEnter(Collider other)
    {
        _boxCollider = GetComponent<BoxCollider>();
        // player�� �ǰ� 1��ŭ ���δ�.
        // player�� �ӵ��� 1��ŭ ��������.
        // player�� ���� UI�� �����.
        // monster�� �ǰ� 1��ŭ ���δ�.
        // monster�� �ӵ��� 1��ŭ ��������.
        // player�� ���� �����̻� �ɸ���.
    }
}
