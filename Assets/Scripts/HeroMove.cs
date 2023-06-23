using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroMove : MonoBehaviour
{
    float rotX = 0f;
    float rotY = 0f;

    private void FixedUpdate()
    {
        moving();
  
    }
    private void Update()
    {
        rotX = Input.GetAxis("Mouse Y");
        rotY = Input.GetAxis("Mouse X");
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
        transform.rotation = Quaternion.Euler(rotX, rotY, 0);
    }

   
}
