using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroMove : MonoBehaviour
{

    float _speed = 2;
    float _stamina = 100;
    private void FixedUpdate()
    {
        //영웅 움직임
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(x, 0,y) *Time.deltaTime *GetComponent<HeroStats>().getspeed());
    }
 }
