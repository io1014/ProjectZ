using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : MonoBehaviour
{
    // 무기의 정보를 담을 클래스
    int _sound;
    int _maxRange;
    int _reload;
    public void PistolInfo()
    {
        //한손으로 장착이 가능하다.
        //사용할 때 소리가 n만큼 난다.
        _sound = 0;
        //최대사거리가 n만큼 있다.
        _maxRange = 0;
        //재장전 할 때 시간이 n만큼 걸린다.
        _reload = 0;
        //n종류의 탄약만 사용이 가능하다.
        //몬스터에게 발사한 탄약이 닿을 경우 몬스터의 피가 n만큼 깎인다.
        //발사속도 n을 가진다.
        
    }
}

//public class BowData
//{
//    // Sprite  asset resource
//    // string
//    // distance
//    // damage
//    // 내구도
//    // 
//}
