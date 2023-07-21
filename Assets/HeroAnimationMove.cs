using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroAnimationMove : MonoBehaviour
{
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Rigidbody rig = GetComponent<Rigidbody>();

        GetComponent<Animator>().SetFloat("x", x);
        GetComponent<Animator>().SetFloat("y", y);
        
    }
}
