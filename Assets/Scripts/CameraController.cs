using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform Hero;
    void Update()
    {
      Vector3 a = new Vector3(Hero.transform.position.x, 10f, Hero.transform.position.z);
      transform.position = a;

    }
}
