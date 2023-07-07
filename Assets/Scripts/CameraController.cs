using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    [SerializeField] Transform Hero;
    void Update()
    {
        //rotX -= Input.GetAxis("Mouse Y");
        //rotY += Input.GetAxis("Mouse X");

        //transform.rotation = Quaternion.Euler(rotX, rotY, 0);
        //transform.position = Hero.position;

      transform.position = Hero.transform.position;

    }
}
