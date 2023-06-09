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
        // player의 피가 1만큼 깎인다.
        // player의 속도가 1만큼 느려진다.
        // player는 출혈 UI가 생긴다.
        // monster의 피가 1만큼 깎인다.
        // monster의 속도가 1만큼 느려진다.
    }
}
