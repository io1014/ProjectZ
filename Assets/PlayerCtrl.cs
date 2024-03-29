using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    public static PlayerCtrl instance;
    Transform tr;
    Animation anim;
    Animator animator;
    float turnSpeed = 80f;
    float stamina;
    public bool _Gun = true;
    public bool _Weapon = false;
    public bool Attackon = false;
    bool mousepos = true;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        tr = GetComponent<Transform>();
        anim = GetComponent<Animation>();
        animator = GetComponent<Animator>();
        stamina = GenericSingleton<HeroStats>._instance.GetComponent<HeroStats>()._stamina;
        
        

    }
    void Update()
    {
        PlayerMotionBool();
        mouseposition();
        Attack();
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        float r = Input.GetAxis("Mouse X");
        Vector3 moveDir = (Vector3.forward * v) + (Vector3.right * h);
        tr.Translate(moveDir.normalized * GetComponent<HeroStats>().getspeed() * Time.deltaTime);
        Rotate();
        if (_Gun == false)
        {
            GetComponent<Animator>().enabled = true;
            GetComponent<Animator>().SetFloat("x", h);
            GetComponent<Animator>().SetFloat("y", v);
        }
        if (_Gun == true)
        {
            GetComponent<Animator>().enabled = false;
            GunPlayerAnim(v,h);
        }
        Debug.Log(v);
    }
    void Attack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (mousepos == true && _Weapon == true)
            {
                animator.SetTrigger("Attack");
            }
        }
    }
    void Rotate()
    {
        RaycastHit hit;
        Vector3 scrrenpos = Input.mousePosition; // 스크린
        Vector3 pos = Camera.main.ScreenToWorldPoint(scrrenpos);
        if (Physics.Raycast(pos, Camera.main.transform.forward, out hit, Mathf.Infinity, 1 << LayerMask.NameToLayer("Terriain")))
        {
            transform.LookAt(new Vector3(hit.point.x, transform.position.y, hit.point.z));
        }
    }
    void GunPlayerAnim(float v , float h)
    {
        if (v>=0.1f)
        {
          anim.CrossFade("RunF",0.25f);
        }
        else if (v <= -0.1f)
        {
            anim.CrossFade("RunB", 0.25f);
        }
        else if (h >= 0.1f)
        {
            anim.CrossFade("WalkR", 0.25f);
            if (Input.GetKey(KeyCode.LeftControl))
            {
                anim.Stop("WalkR");
                anim.CrossFade("RunR", 0.25f);
            }
        }
        else if (h <= -0.1f)
        {
            anim.CrossFade("WalkL", 0.25f);
            if (Input.GetKey(KeyCode.LeftControl))
            {
                anim.Stop("WalkL");
                anim.CrossFade("RunL", 0.25f);
            }
        }
        else if (Input.GetMouseButtonDown(0))
        {
            anim.Play("IdleFireSMG");
            if (Input.GetKeyDown(KeyCode.LeftControl))
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
        _Weapon = GenericSingleton<PlayerItemInventory>._instance.GetComponent<PlayerItemInventory>().GetMeleeEquip();
    }
    void mouseposition() // 인벤토리를 누르면 총알이 같이나가는거 방지
    {
        Vector3 mpos = Input.mousePosition;
        Vector3 cpoint = Camera.main.ScreenToWorldPoint(mpos);

        if (cpoint.y > 76.35)
        {
            mousepos = false;
        }
        else
        {
            mousepos = true;
        }
    }

}

