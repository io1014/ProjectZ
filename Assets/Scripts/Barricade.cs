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
        // player가 충돌하면 지나가지지않는다.
        // monster가 충돌하면 지나가지지않는다.
        //
        // 또다른 방법
        // player와 monster를 gameobject tag를 붙여서
        // gameobject tag가 붙은 gameobject는 충돌할 경우 지나가지지않는다.
    }
}
