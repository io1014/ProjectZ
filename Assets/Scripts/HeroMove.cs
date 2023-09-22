using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroMove : MonoBehaviour
{
    float rotY = 0f;

    private void FixedUpdate()
    {
        moving();
  
    }
    private void Update()
    {
        rotY -= Input.GetAxis("Mouse X");
        Rotate();
    }
    void moving()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        Vector3 newVelocity = transform.forward * y * GetComponent<HeroStats>().getspeed();
        newVelocity += transform.right * x * GetComponent<HeroStats>().getspeed();
        GetComponent<Rigidbody>().velocity = newVelocity;
    }

    void Rotate()
    {
        RaycastHit hit;
        Vector3 scrrenpos = Input.mousePosition; // ½ºÅ©¸°
        Vector3 pos = Camera.main.ScreenToWorldPoint(scrrenpos);
        if(Physics.Raycast(pos, Camera.main.transform.forward, out hit, Mathf.Infinity, 1 << LayerMask.NameToLayer("Terriain")))
        {
            Debug.Log("input rotate");
            transform.LookAt(new Vector3(hit.point.x, transform.position.y, hit.point.z));
        }
        


    }


   
}
