using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExamPlayerMove : MonoBehaviour
{
    float rotY = 0f;

    private void FixedUpdate()
    {
        moving();

    }
    private void Update()
    {
        rotY += Input.GetAxis("Mouse X");
        Rotate();
    }
    void moving()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        Vector3 newVelocity = transform.forward * y * GetComponent<ExamPlayerInfo>().getspeed();
        newVelocity += transform.right * x * GetComponent<ExamPlayerInfo>().getspeed();
        GetComponent<Rigidbody>().velocity = newVelocity;
    }

    void Rotate()
    {
        transform.rotation = Quaternion.Euler(0, rotY, 0);
    }



}
