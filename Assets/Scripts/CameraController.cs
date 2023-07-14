using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    [SerializeField] Transform Hero;
    [SerializeField] Material _seeThrough;
    Material _tempMat;
    bool _isObstacleBuilding = false;
    GameObject _building;
    void Update()
    {
        //rotX -= Input.GetAxis("Mouse Y");
        //rotY += Input.GetAxis("Mouse X");

        //transform.rotation = Quaternion.Euler(rotX, rotY, 0);
        //transform.position = Hero.position;

        transform.position = Hero.transform.position;
        Transform camTrans = Camera.main.transform;
        RaycastHit hit;
        if(Physics.Raycast(camTrans.position, (Hero.position - camTrans.position), out hit,Mathf.Infinity,  1 << LayerMask.NameToLayer("BuildingLayer")))
        {
            if (_isObstacleBuilding == false)
            {
                Debug.Log("Input buiding");
                // 해당 건물의 매터리얼을 임시 저장하고 대체함
                _tempMat =  hit.collider.GetComponent<Renderer>().material;
                _seeThrough.SetTexture("_Albedo", _tempMat.GetTexture("_MainTex"));
                _seeThrough.SetTexture("_Metalic", _tempMat.GetTexture("_Metallic"));
                hit.collider.GetComponent<Renderer>().material = _seeThrough;
                _building = hit.collider.gameObject;
                _isObstacleBuilding = true;
            }
        }
        else
        {
            if(_isObstacleBuilding == true)
            {
                _building.GetComponent<Renderer>().material = _tempMat;
                _isObstacleBuilding = false;
            }
        }
    }
}
