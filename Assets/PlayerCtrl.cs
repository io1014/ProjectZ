using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    public static PlayerCtrl instance;
    Transform tr;
    Animation anim;
    float turnSpeed = 80f;
    public bool _Gun = false;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        tr = GetComponent<Transform>();
        anim = GetComponent<Animation>();

    }
    void Update()
    {
        PlayerMotionBool();
        Debug.Log(_Gun);
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        float r = Input.GetAxis("Mouse X");
        Vector3 moveDir = (Vector3.forward * v) + (Vector3.right * h);
        tr.Translate(moveDir.normalized * GetComponent<HeroStats>().getspeed() * Time.deltaTime);
        Rotate();
        if (_Gun == true)
        { PlayerAnim(h, v); }   
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
            anim.CrossFade("WalkF", 0.25f);
            if (Input.GetKey(KeyCode.LeftControl))
            {
                //anim.Stop("WalkF");
                anim.CrossFade("SprintF", 0.25f);
            }
        }
        else if(v <= -0.1f)
        {
            anim.CrossFade("WalkB", 0.25f);
            if (Input.GetKey(KeyCode.LeftControl))
            {
                anim.Stop("WalkB");
                anim.CrossFade("RunB", 0.25f);
            }
        }
        else if ( h >= 0.1f)
        {
            anim.CrossFade("WalkR", 0.25f);
            if (Input.GetKey(KeyCode.LeftControl))
            {
                anim.Stop("WalkR");
                anim.CrossFade("RunR", 0.25f);
            }
        }
        else if( h <= -0.1f)
        {
            anim.CrossFade("WalkL", 0.25f);
            if (Input.GetKey(KeyCode.LeftControl))
            {
                anim.Stop("WalkL");
                anim.CrossFade("RunL", 0.25f);
            }
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            anim.Play("IdleReloadSMG");
        }
        else if(Input.GetMouseButtonDown(0))
        {
            anim.Play("IdleFireSMG");
            if(Input.GetKeyDown(KeyCode.LeftControl))
            {
                anim.Play("RunFireSMG");
            }
        }
        else
        {
            anim.CrossFade("Idle", 0.25f);
        }   
    }
    void PlayerMotionBool()
    {
        _Gun = GenericSingleton<PlayerItemInventory>._instance.GetComponent<PlayerItemInventory>().GetRangedEquip();
    }
  
}
