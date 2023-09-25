using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gizimo : MonoBehaviour
{
    public Color _color;
    public float _width = 0.1f;
    void Start()
    {

    }
    void Update()
    {
  
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = _color;
        Gizmos.DrawSphere(transform.position, _width);
    }
}
