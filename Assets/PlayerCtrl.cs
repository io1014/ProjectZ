using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    Transform tr;
    Animation anim;

    float turnSpeed = 80f;
    void Start()
    {
        tr = GetComponent<Transform>();
        anim = GetComponent<Animation>();

    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        float r = Input.GetAxis("Mouse X");

        Vector3 moveDir = (Vector3.forward * v) + (Vector3.right * h);

        tr.Translate(moveDir.normalized * GetComponent<HeroStats>().getspeed() * Time.deltaTime);
        Rotate();
        PlayerAnim(h, v);
    
    }
    void Rotate()
    {
        RaycastHit hit;
        Vector3 scrrenpos = Input.mousePosition; // ½ºÅ©¸°
        Vector3 pos = Camera.main.ScreenToWorldPoint(scrrenpos);
        if (Physics.Raycast(pos, Camera.main.transform.forward, out hit, Mathf.Infinity, 1 << LayerMask.NameToLayer("Terriain")))
        {
            transform.LookAt(new Vector3(hit.point.x, transform.position.y, hit.point.z));
        }
    }
    void PlayerAnim(float h , float v)
    {
        if(v >= 0.1f)
        {
            anim.CrossFade("RunF", 0.25f);
        }
        else if (v <= -0.1f)
        {
            anim.CrossFade("RunB", 0.25f);
        }
        else if (h >= 0.1f)
        {
            anim.CrossFade("RunR", 0.25f);
        }
        else if (h <= -0.1f)
        {
            anim.CrossFade("RunL", 0.25f);
        }
        else
        {
            anim.CrossFade("Idle", 0.25f);
        }
    }
}
